using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ToDoListConsoleApp
{
    public class ToDoList
    {
        public List<TasksModel> taskList  = new List<TasksModel>();
        public ToDoList()
        {
            AddTask("Limpar o quarto");
            AddTask("Jogar fora o lixo");
            AddTask("Estudar");
        }
        public void AddTask(string taskName)
        {
            taskList.Add(new TasksModel(taskName));
        }
        public void PrintTaskList()
        {
            Console.WriteLine("To do List:");
            foreach (var task in taskList)
            {
                string status = task.Status ? "FEITO" : "A FAZER";

                Console.WriteLine($"{task.TaskId}: {task.TaskName} - {status}");
            }
        }
        public void PrintMenuOptions()
        {
            Console.WriteLine("Opções:\n" +
                "1. Alterar status de uma tarefa.\n" +
                "2. Criar uma tarefa nova.\n" +
                "3. Editar uma tarefa.\n" +
                "4. Excluir uma tarefa.\n" +
                "5. Sair do programa.\n");
        }
        public int ConvertToInt(string input)
        {
            int num = 0;
            while (!int.TryParse(input, out num))
            {
                Console.WriteLine("Favor inserir número inteiro!");
                input = Console.ReadLine();
            }
            return num;
        }
        public void AlterStatus(int opcao)
        {
            var task = FindTaskById(opcao);
            if (task.Status)
            {
                task.Status = false;
            }
            else
            {
                task.Status = true;
            }
            Console.WriteLine("Alterado com sucesso.");
        }
        public string ValidateName(string nome)
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
        public void EditTask(int id)
        {
            var taskToEdit = FindTaskById(id);
            Console.WriteLine("Informe o nome: ");
            taskToEdit.TaskName = ValidateName(Console.ReadLine());
        }
        public TasksModel FindTaskById(int id)
        {
            var task = taskList.FirstOrDefault(t => t.TaskId == id);

            while (task is null)
            {
                Console.WriteLine("nenhuma tarefa encontrada, insira uma opção válida: ");
                id = ConvertToInt(Console.ReadLine());
                task = taskList.FirstOrDefault(t => t.TaskId == id);
            }
            return task;
        }        
        public void DeleteTask(int id)
        {
            var taskToDelete = FindTaskById(id);

            Console.WriteLine($"Você esta excluindo a tarefa: {taskToDelete.TaskName}");
            taskList.Remove(taskToDelete);
        }
    }
}