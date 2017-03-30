using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public class Message
    {
        public void ShowMessage()
        {
            string message = string.Format("\nAsync threadId is:{0}",
                                           Thread.CurrentThread.ManagedThreadId);
            Console.WriteLine(message);
            for (int n = 0; n < 10; n++)
            {
                Thread.Sleep(300);
                Console.WriteLine("The number is:" + n.ToString());
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Main threadId is:" +
                              Thread.CurrentThread.ManagedThreadId);

            Message message = new Message();
            Thread thread = new Thread(new ThreadStart(message.ShowMessage));
            thread.IsBackground = true;
            thread.Start();

            Console.WriteLine("Do something ..........!");
            Console.WriteLine("Main thread working is complete!");
            Console.WriteLine("Main thread sleep!");
            thread.Join();
        }
    }

}
