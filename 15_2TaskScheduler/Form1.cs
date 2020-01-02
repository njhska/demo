using System;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _15_2TaskScheduler
{
    public partial class MainForm : Form
    {
        private readonly TaskScheduler syncContextTaskScheduler;
        private CancellationTokenSource cts;
        public MainForm()
        {
            InitializeComponent();
            syncContextTaskScheduler = TaskScheduler.FromCurrentSynchronizationContext();
            Text = "initial";
        }

        protected override void OnMouseClick(MouseEventArgs e)
        {
            if (cts == null)
            {
                cts = new CancellationTokenSource();
                var task = Task.Run(() => Dosth(cts.Token, 10000000), cts.Token);

                //后面三个任务由于ui线程对应的同步上下文任务调度器来调度，将任务调度给ui线程队列，来更新ui
                task.ContinueWith(t => { Text = $"run to completed,result = {t.Result}"; }, CancellationToken.None, TaskContinuationOptions.OnlyOnRanToCompletion, syncContextTaskScheduler);

                task.ContinueWith(t => { Text = $"task cancel"; }, CancellationToken.None, TaskContinuationOptions.OnlyOnCanceled, syncContextTaskScheduler);

                task.ContinueWith(t => { Text = $"task error"; }, CancellationToken.None, TaskContinuationOptions.OnlyOnFaulted, syncContextTaskScheduler);
            }
            else
            {
                cts.Cancel();
                cts = null;
            }

            base.OnMouseClick(e);
        }

        private int Dosth(CancellationToken ct, int n)
        {
            var result = 0;
            for (int i = 0; i < n; i++)
            {
                ct.ThrowIfCancellationRequested();
                result += i;
            }
            return result;
        }
    }
}
