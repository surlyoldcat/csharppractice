using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterviewWork
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Starting...");
            Run2StackQueueProblem(args);
            //DoTheThing();

            //var result = RansomNote.CanMakeNoteFromMagazine(SomeInputs.Magazine, SomeInputs.Note);
            //Console.WriteLine("Result: " + result);

            //Console.WriteLine("Hit Enter to exit...");
            //Console.ReadLine();
        }

        private static void Run2StackQueueProblem(string[] args)
        {
            TwoStackQueue<int> queue = new TwoStackQueue<int>();

            bool keepRunning = true;
            while (keepRunning)
            {
                string line = Console.ReadLine();
                string[] inputs = line.Split(' ');
                var action = inputs[0];
                switch(action)
                {
                    case "1":
                        if (inputs.Length < 2)
                        {
                            throw new ArgumentException("Expected 2 arguments!");
                        }
                        int numToAdd = Int32.Parse(inputs[1]);
                        queue.Enqueue(numToAdd);
                        break;
                    case "2":
                        int val = queue.Dequeue();
                        break;
                    case "3":
                        Console.WriteLine(queue.FrontOfQueue());
                        break;
                    case "x":
                        keepRunning = false;
                        break;
                    default:
                        //don't care
                        break;
                }
            }
        }

        private static void DoTheThing()
        {
            foreach (string s in SomeInputs.BracketStrings)
            {
                bool result = BalancedBrackets.IsBalanced(s);
                Console.WriteLine("String: {0} Result:{1}", s, result);
            }
            
        }
    }
}
