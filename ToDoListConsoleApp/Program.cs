using System;
using System.Collections.Generic;

namespace ToDoListConsoleApp
{
    public class Program
    {
        static void Main(string[] args)
        {
            List<TasksModel> tasks = new List<TasksModel>
            {
                new TasksModel("Limpar o quarto"),
                new TasksModel("Jogar fora o lixo"),
                new TasksModel("Estudar")
            };

            int opcao = 0;

            Console.WriteLine("To do List:");

            TaskList(tasks);

            Console.WriteLine("\n\n\n");

            Console.WriteLine("Opções:");
            Console.WriteLine("1. Alterar status de uma tarefa.");
            Console.WriteLine("2. Criar uma tarefa nova.");
            Console.WriteLine("3. Editar uma tarefa.");
            Console.WriteLine("4. Excluir uma tarefa.");
            Console.WriteLine("5. Sair do programa.");
            opcao = ToInt(Console.ReadLine());

            switch (opcao)
            {
                case 1:
                    TaskList(tasks);
                    Console.WriteLine("Selecione a tarefa para alterar: ");
                    opcao = ToInt(Console.ReadLine());

                    AlteraStatus(opcao, tasks);
                    TaskList(tasks);
                    break;
                default:
                    break;
            }
        }

        public static void TaskList(List<TasksModel> tasksModel)
        {
            foreach (var task in tasksModel)
            {
                string status = task.Status ? "FEITO" : "A FAZER";

                Console.WriteLine($"{task.TaskId}: {task.TaskName} - {status}");
            }
        }

        public static int ToInt(string input)
        {
            bool validate = false;
            int num = 0;
            while (!validate)
            {
                if (int.TryParse(input, out num))
                {
                    if (!(num >= 1 && num <= 5))
                    {
                        Console.WriteLine("Opção inválida, favor informar uma opção possível!");
                        input = Console.ReadLine();
                    }
                    else
                    {
                        validate = true;
                    }
                }
            }
            return num;
        }

        public static void AlteraStatus(int opcao, List<TasksModel> tasks)
        {
            if (tasks[opcao - 1].Status)
            {
                tasks[opcao - 1].Status = false;
            }
            else
            {
                tasks[opcao - 1].Status = true;
            }
            Console.WriteLine("Alterado com sucesso.");
        }
    }
}
