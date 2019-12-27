using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Threading.Tasks;

namespace _16AsyncMethod
{
    internal class AsyncFuncCodeTransformation
    {
        public static void Go()
        {
            var s = MyMethodAsync_ActualImplementation(5).Result;
        }
        private sealed class Type1 { }
        private sealed class Type2 { }
        private static Task<Type1> Method1Async()
        {
            return Task.Run(() => { return new Type1(); });
        }
        private static Task<Type2> Method2Async()
        {
            return Task.Run(() => { return new Type2(); });
        }
        private static async Task<string> MyMethodAsync(int argument)
        {
            int local = argument;
            try
            {
                Type1 result1 = await Method1Async();
                for (int i = 0; i < 3; i++)
                {
                    Type2 result2 = await Method2Async();
                }
            }
            catch (Exception)
            {
                Console.WriteLine("Catch");
            }
            finally
            {
                Console.WriteLine("Finally");
            }
            return "Done";
        }
        [DebuggerStepThrough, AsyncStateMachine(typeof(StateMachine))]
        private static Task<string> MyMethodAsync_ActualImplementation(int argument)
        {
            StateMachine stateMachine = new StateMachine {
                m_builder = AsyncTaskMethodBuilder<string>.Create(),
                m_state = -1,
                m_argument = argument
            };
            stateMachine.m_builder.Start(ref stateMachine);
            return stateMachine.m_builder.Task;
        }

        private struct StateMachine : IAsyncStateMachine
        {
            public AsyncTaskMethodBuilder<string> m_builder;
            public int m_state;

            public int m_argument, m_local, m_i;
            public Type1 m_result1;
            public Type2 m_result2;

            private TaskAwaiter<Type1> m_awaiterType1;
            private TaskAwaiter<Type2> m_awaiterType2;

            void IAsyncStateMachine.MoveNext()
            {
                string result = null;
                try
                {
                    bool executeFinally = true;
                    if (m_state == -1)
                    {
                        m_local = m_argument;
                    }
                    try
                    {
                        TaskAwaiter<Type1> awaiterType1;
                        TaskAwaiter<Type2> awaiterType2;
                        switch (m_state)
                        {
                            case -1:
                                awaiterType1 = Method1Async().GetAwaiter();
                                if (!awaiterType1.IsCompleted)
                                {
                                    m_state = 0;
                                    m_awaiterType1 = awaiterType1;
                                    //把Method1Async的continue方法设置为调用this.movenext
                                    m_builder.AwaitUnsafeOnCompleted(ref awaiterType1, ref this);
                                    executeFinally = false;
                                    return;
                                }
                                break;
                            case 0:
                                awaiterType1 = m_awaiterType1;
                                break;
                            case 1:
                                awaiterType2 = m_awaiterType2;
                                goto ForLoopEpilog;
                        }

                        m_result1 = awaiterType1.GetResult();

                        m_i = 0;
                        goto ForLoopBody;

                    ForLoopEpilog:
                        m_result2 = awaiterType2.GetResult();
                        m_i++;

                    ForLoopBody:
                        if (m_i < 3)
                        {
                            awaiterType2 = Method2Async().GetAwaiter();
                            if (!awaiterType2.IsCompleted)
                            {
                                m_state = 1;
                                m_awaiterType2 = awaiterType2;
                                m_builder.AwaitUnsafeOnCompleted(ref awaiterType2, ref this);
                                executeFinally = false;
                                return;
                            }
                            goto ForLoopEpilog;
                        }
                    }
                    catch (Exception)
                    {
                        Console.WriteLine("Catch");
                    }
                    finally
                    {
                        if (executeFinally)
                        {
                            Console.WriteLine("Finally");
                        }
                    }
                }
                catch (Exception exception)
                {
                    // Unhandled exception: complete state machine's Task with exception
                    m_builder.SetException(exception);
                    return;
                }

                m_builder.SetResult(result);
            }

            void IAsyncStateMachine.SetStateMachine(IAsyncStateMachine stateMachine)
            {
                m_builder.SetStateMachine(stateMachine);
            }
        }
    }
}
