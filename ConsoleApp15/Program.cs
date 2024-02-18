using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ConsoleApp15
{
    internal class Program
    {
        static void Main(string[] args)
        {
            
            Poetry poetry = new Poetry();
           
            Task<string> task1 = Task.Run(poetry.StringTask);
            StringTask(task1);
            Task<string> task2 = Task.Run(poetry.StringTask);
            StringTask(task2);
            Task<string> task3 = Task.Run(poetry.StringTask);
            StringTask(task3);
            Task<string> task4 = Task.Run(poetry.StringTask);
            StringTask(task4);

            Console.ReadKey();
        }

        private async static void StringTask(Task<string> res)
        {           
            await res;
            PrintString($"{res.Result} <- выполнил поток {res.Id}");
        }

        private static void PrintString(string data)
        {
            Console.WriteLine(data);
        }
    }
}
