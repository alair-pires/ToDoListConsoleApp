using System;
using System.Collections.Generic;

namespace ToDoListConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            List<TasksModel> tasks = new List<TasksModel>();
            
            Console.WriteLine("To do List:");

            foreach(var task in tasks)
            {
                Console.WriteLine(task);
            }


        }
    }
}
