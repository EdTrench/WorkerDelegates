using System;

namespace WorkerDelegates
{
    public class ProcessData
    {
        public void ProcessDelegte(int x, int y, BizRulesDelegate del)
        {
            var result = del(x, y);
            Console.WriteLine(result);
        }

        public void ProcessAction(int x, int y, Action<int, int> action)
        {
            action(x, y);
            Console.WriteLine("Action processed!");
        }
    }
}