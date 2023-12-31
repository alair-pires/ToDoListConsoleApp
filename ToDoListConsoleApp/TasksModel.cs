﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDoListConsoleApp
{
    public class TasksModel
    {
        public int TaskId { get; set; }
        public string TaskName { get; set; }

        public TasksModel(string name)
        {
            TaskId++;
            TaskName = name;
        }
    }
}