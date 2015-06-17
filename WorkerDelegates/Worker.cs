using System;

namespace WorkerDelegates
{
    public delegate void WorkLunchHandler(int hours);

    public class Worker
    {
        public event EventHandler<WorkPerformedEventArgs> WorkPerformed;
        public event EventHandler WorkCompleted;
        public event WorkLunchHandler WorkLunch;

        public void DoWork(int hours, WorkType workType)
        {
            for (int i = 0; i < hours; i++)
            {
                System.Threading.Thread.Sleep(1000);
                if (hours/(float) (i + 1) == 2.0)
                {
                    OnWorkLunch(i + 1);
                }
                else
                {
                    OnWorkPerformed(i + 1, workType);
                }
            }
            OnWorkCompleted();
        }

        protected virtual void OnWorkLunch(int hours)
        {
            var del = WorkLunch as WorkLunchHandler;
            if (del != null)
            {
                del(hours);
            }
        }

        protected virtual void OnWorkPerformed(int hours, WorkType workType)
        {
            var del = WorkPerformed as EventHandler<WorkPerformedEventArgs>;
            if (del != null)
            {
                del(this, new WorkPerformedEventArgs(hours, workType));
            }
        }

        protected virtual void OnWorkCompleted()
        {
            var del = WorkCompleted as EventHandler;
            if (del != null)
            {
                del(this, EventArgs.Empty);
            }   
        }
        public void Test()
        {

        }
    }

    public enum WorkType
    {
        Cycling,
        ReportWriting,
        SmokingCigars
    }
}
