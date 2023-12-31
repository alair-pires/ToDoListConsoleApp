using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDoListConsoleApp
{
    public class TasksModel
    {
        private static int ID = 1;
        public int TaskId { get; private set; }
        public string TaskName { get; set; }

        public bool Status { get; set; }

        public TasksModel(string name)
        {
            TaskId = ID++;
            TaskName = name;
            Status = false;
        }
    }
}
