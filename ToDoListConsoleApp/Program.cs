using System;
using System.Collections.Generic;
using System.Linq;

namespace ToDoListConsoleApp
{
    public class Program
    {
        static void Main(string[] args)
        {
            ToDoList toDoList = new ToDoList();
            Console.WriteLine("To do List:");
            Console.WriteLine("\n\n\n");
            int optionSelected = toDoList.ShowOptions();
            while (optionSelected != 5)
            {
                switch (optionSelected)
                {
                    case 1:
                        toDoList.PrintTaskList();
                        Console.WriteLine("\n");
                        Console.WriteLine("Selecione a tarefa para alterar: ");
                        optionSelected = toDoList.ConvertToInt(Console.ReadLine());
                        toDoList.AlterStatus(optionSelected);
                        Console.WriteLine("\n");
                        toDoList.PrintTaskList();
                        break;
                    case 2:
                        Console.WriteLine("Nome da tarefa: ");
                        string taskName = toDoList.ValidateName(Console.ReadLine());
                        toDoList.AddTask(taskName);
                        Console.WriteLine("\n");
                        toDoList.PrintTaskList();
                        break;
                    case 3:
                        toDoList.EditTask();
                        Console.WriteLine("\n");
                        toDoList.PrintTaskList();
                        break;
                    case 4:
                        Console.WriteLine("Selecione a tarefa para excluir: ");
                        optionSelected = toDoList.ConvertToInt(Console.ReadLine());
                        toDoList.DeleteTask(optionSelected);
                        Console.WriteLine("\n");
                        toDoList.PrintTaskList();
                        Console.WriteLine("\n");
                        break;
                    case 5:
                        Console.WriteLine("Fim do programa!");
                        break;
                    default:
                        Console.WriteLine("Opção inválida, favor informar uma opção possível!");
                        break;
                }

                optionSelected = toDoList.ShowOptions();
            }            
        }
    }
}
