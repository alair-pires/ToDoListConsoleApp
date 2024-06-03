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

            toDoList.PrintTaskList();
            
            Console.WriteLine("\n\n\n");
            
            toDoList.PrintMenuOptions();
            int optionSelected = toDoList.ConvertToInt(Console.ReadLine());
            
            while (optionSelected != 5)
            {
                switch (optionSelected)
                {
                    case 1://1. Alterar status de uma tarefa.
                        toDoList.PrintTaskList();
                        Console.WriteLine("\n");
                        
                        Console.WriteLine("Selecione a tarefa para alterar: ");
                        optionSelected = toDoList.ConvertToInt(Console.ReadLine());
                        
                        toDoList.AlterStatus(optionSelected);
                        Console.WriteLine("\n");
                        
                        toDoList.PrintTaskList();
                        break;
                    case 2://2. Criar uma tarefa nova.
                        Console.WriteLine("Nome da tarefa: ");
                        string taskName = toDoList.ValidateName(Console.ReadLine());
                        
                        toDoList.AddTask(taskName);
                        Console.WriteLine("\n");
                        
                        toDoList.PrintTaskList();
                        break;
                    case 3://3. Editar uma tarefa.
                        Console.WriteLine("Informar o ID da task para edição:");
                        optionSelected = toDoList.ConvertToInt(Console.ReadLine());
                        
                        toDoList.EditTask(optionSelected);
                        Console.WriteLine("\n");
                        
                        toDoList.PrintTaskList();
                        break;
                    case 4://4. Excluir uma tarefa.
                        Console.WriteLine("Selecione a tarefa para excluir: ");
                        optionSelected = toDoList.ConvertToInt(Console.ReadLine());

                        toDoList.DeleteTask(optionSelected);
                        Console.WriteLine("\n");
                        
                        toDoList.PrintTaskList();
                        Console.WriteLine("\n");
                        break;
                    case 5://5. Sair do programa.
                        Console.WriteLine("Fim do programa!");
                        break;
                    default:
                        Console.WriteLine("Opção inválida, favor informar uma opção possível!");
                        break;
                }

                toDoList.PrintMenuOptions();
                optionSelected = toDoList.ConvertToInt(Console.ReadLine());
            }            
        }
    }
}
