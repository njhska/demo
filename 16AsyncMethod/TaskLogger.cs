using System;
using System.Linq;
using System.Threading;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
namespace _16AsyncMethod
{
    public static class TaskLogger
    {
        public enum TaskLogLevel
        {
            None,
            Pending
        }
        public static TaskLogLevel LogLevel { get; set; }

        public sealed class TaskLogEntity
        {
            public Task Task { get; internal set; }
            public string Tag { get; internal set; }
            public DateTime LogTime { get; internal set; }
            public string CallerMemberName { get; internal set; }
            public string CallerFilePath { get; internal set; }
            public int CallerLineNumber { get; internal set; }
            public override string ToString()
            {
                var none = "none";
                return $"LogTime={LogTime},Tag={Tag ?? none},Member={CallerMemberName},File={CallerFilePath}({CallerLineNumber})";
            }
        }

        private static readonly ConcurrentDictionary<Task, TaskLogEntity> s_log = new ConcurrentDictionary<Task, TaskLogEntity>();
        public static IEnumerable<TaskLogEntity> GetLogEntities()
        {
            return s_log.Values;
        }
        //记录日志：尚未完成的task的名字和代码位置
        public static Task Log(this Task task, string tag = null,
            [CallerMemberName] string callerMemberName = null,
            [CallerFilePath] string callerFilePath = null,
            [CallerLineNumber] int callerLineNumber = -1)
        {
            if (LogLevel == TaskLogLevel.None)
            {
                return task;
            }
            var logEntity = new TaskLogEntity
            {
                Task = task,
                LogTime = DateTime.Now,
                CallerFilePath = callerFilePath,
                CallerLineNumber = callerLineNumber,
                CallerMemberName = callerMemberName,
                Tag = tag
            };
            s_log[task] = logEntity;
            //如果task已经完成，则把这个task从记录中移除
            task.ContinueWith(t =>
            {
                TaskLogEntity entity;
                s_log.TryRemove(t, out entity);
            });
            return task;
        }
        public static Task<TResult> Log<TResult>(this Task<TResult> task, string tag = null,
            [CallerMemberName] string callerMemberName = null,
            [CallerFilePath] string callerFilePath = null,
            [CallerLineNumber] int callerLineNumber = -1)
        {
            return (Task<TResult>)Log((Task)task, tag, callerMemberName, callerFilePath, callerLineNumber);
        }

        public static async Task Go()
        {
            TaskLogger.LogLevel = TaskLogger.TaskLogLevel.Pending;
            var tasks = new List<Task> {
                Task.Delay(2000).Log("2s op"),
                Task.Delay(5000).Log("5s op"),
                Task.Delay(6000).Log("6s op")
            };
            try
            {
                await Task.WhenAll(tasks).WithCancellation(new CancellationTokenSource(3000).Token);
            }
            catch (OperationCanceledException)
            {
                foreach (var item in TaskLogger.GetLogEntities().OrderBy(t => t.LogTime))
                {
                    Console.WriteLine(item);
                }
            }          
        }
    }
}
