using System;

namespace WorkerDelegates
{
    public delegate int BizRulesDelegate(int x, int y);

    class Program
    {
        static void Main(string[] args)
        {
            BizRulesDelegate addDelegate = (x, y) => x + y;
            BizRulesDelegate multiplyDelegate = (x, y) => x * y;

            var data = new ProcessData();
            data.ProcessDate(2, 3, multiplyDelegate);
            
            Action<int, int> myAddAction = (x, y) => Console.WriteLine(x + y);
            Action<int, int> myMultiplyAction = (x, y) => Console.WriteLine(x * y);
            data.ProcessAction(2, 3, myAddAction);

            var worker = new Worker();
            worker.WorkPerformed += new EventHandler<WorkPerformedEventArgs>(WorkPerformed);
            worker.WorkCompleted += WorkCompleted;
            worker.WorkLunch += delegate(int hours)
            {
                Console.WriteLine("Hours lunch: {0} - yum, yum", hours);
            };
            worker.WorkCommute += (s, e) => Console.WriteLine("Driving in my car");
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