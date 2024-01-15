using System;
using System.Collections.Generic;
using System.Linq;

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
                        Console.WriteLine("\n");
                        TaskList(tasks);
                        break;
                    case 3:
                        EditTask(tasks);
                        Console.WriteLine("\n");
                        TaskList(tasks);
                        break;
                    case 4:
                        DeleteTask(tasks);
                        Console.WriteLine("\n");
                        TaskList(tasks);
                        Console.WriteLine("\n");
                        break;
                    case 5:
                        Console.WriteLine("Fim do programa!");
                        break;
                    default:
                        Console.WriteLine("Opção inválida, favor informar uma opção possível!");
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
            int num = 0;
            while (!int.TryParse(input, out num))
            {
                Console.WriteLine("Favor inserir número inteiro!");
                input = Console.ReadLine();
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

        public static TasksModel FindTaskById(List<TasksModel> tasks, int id)
        {
            var task = tasks.FirstOrDefault(t => t.TaskId == id);

            while (task is null)
            {
                Console.WriteLine("nenhuma tarefa encontrada, insira uma opção válida: ");
                id = ToInt(Console.ReadLine());
                task = tasks.FirstOrDefault(t => t.TaskId == id);
            }
            return task;
        }

        public static void EditTask(List<TasksModel> tasks)
        {
            Console.WriteLine("Informar o ID da task para edição:");
            int id = ToInt(Console.ReadLine());
            var taskToEdit = FindTaskById(tasks, id);


            Console.WriteLine("Informe o nome: ");
            taskToEdit.TaskName = NameValidate(Console.ReadLine());
        }

        public static void DeleteTask(List<TasksModel> tasks)
        {
            Console.WriteLine("Informar o ID da task para deleção:");
            int id = ToInt(Console.ReadLine());
            var taskToDelete = FindTaskById(tasks, id);

            Console.WriteLine($"Você esta excluindo a tarefa: {taskToDelete.TaskName}");
            tasks.Remove(taskToDelete);
        }
    }
}
