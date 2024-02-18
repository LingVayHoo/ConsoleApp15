using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ConsoleApp15
{
    internal class Poetry
    {
        private static object o = new object();
        private static int numberOfString = 0;
        static int delay = 0;
        private string StringFromPoetry(int numberOfString)
        {
            // Для экономии времени не стал помещать все в файл
            string poetry = "#Буря мглою небо кроет,#" +
                "Вихри снежные крутя;#" +
                "То, как зверь, она завоет,#" +
                "то заплачет как дитя,";
            string[] poetryStrings = poetry.Split('#');
            return poetryStrings[numberOfString];
        }

        public string StringTask()
        {            
            lock (this)
            {
                Random rnd = new Random();
                if (delay == 0) delay = rnd.Next(1000, 4000);
                else delay += rnd.Next(-2000, 2000);
                Thread.Sleep(100);
                Console.WriteLine($"Поток {Task.CurrentId} начал работу. Задержка {delay}");
            }

            Thread.Sleep(delay);

            lock (this)
            {
                numberOfString++;
                return StringFromPoetry(numberOfString);
            }            
        }
    }
}
