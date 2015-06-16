using System;

namespace WorkerDelegates
{
    class Program
    {
        static void Main(string[] args)
        {

            var worker = new Worker();
            worker.WorkPerformed += new EventHandler<WorkPerformedEventArgs>(WorkPerformed);
            worker.WorkCompleted += WorkCompleted;
            worker.DoWork(8, WorkType.Cycling);
            Console.ReadKey();
        }

        static void WorkPerformed(object sender, WorkPerformedEventArgs e)
        {
            Console.WriteLine("Hours worked: {0} - {1}", e.Hours, e.WorkType);
        }

        static void WorkCompleted(object sender, EventArgs e)
        {
            Console.WriteLine("Work Completed");
        }

    }
}
