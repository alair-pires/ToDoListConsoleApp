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

            opcao = Options();            

            while (opcao != 5)
            {
                switch (opcao)
                {
                    case 1:
                        TaskList(tasks);
                        Console.WriteLine("\n");
                        Console.WriteLine("Selecione a tarefa para alterar: ");
                        opcao = ToInt(Console.ReadLine());
                        AlterStatus(opcao, tasks);
                        Console.WriteLine("\n");
                        TaskList(tasks);
                        break;
                    case 2:
                        Console.WriteLine("Nome da tarefa: ");
                        string taskName = NameValidate(Console.ReadLine());
                        tasks.Add(new TasksModel(taskName));
                        Console.WriteLine("\n\n\n");
                        TaskList(tasks);
                        break;
                    default:
                        break;
                }

                opcao = Options();
            }            
        }

        public static int Options()
        {
            Console.WriteLine("Opções:\n" +
                "1. Alterar status de uma tarefa.\n" +
                "2. Criar uma tarefa nova.\n" +
                "3. Editar uma tarefa.\n" +
                "4. Excluir uma tarefa.\n" +
                "5. Sair do programa.\n");
            int op = ToInt(Console.ReadLine());
            return op;
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

        public static string NameValidate(string nome)
        {
            string nomeAux = nome;
            Console.WriteLine("");
            if (!string.IsNullOrWhiteSpace(nomeAux))
            {
                nomeAux = nomeAux.Trim();
                return nomeAux;
            }
            while (string.IsNullOrWhiteSpace(nomeAux))
            {
                Console.WriteLine("Não é possível inserir tarefa sem nome, insira um nome valido: ");
                nomeAux = Console.ReadLine();                
            }
            nomeAux = nomeAux.Trim();
            return nomeAux;
        }

        public static void AlterStatus(int opcao, List<TasksModel> tasks)
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
