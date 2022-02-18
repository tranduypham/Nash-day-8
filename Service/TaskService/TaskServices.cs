using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Day_8.Model;

namespace Day_8.Service.TaskService
{
    public class TaskServices : ITaskServices
    {
        public static List<TaskModel> taskList = new List<TaskModel>{
            new TaskModel{
                TaskId = 1,
                Title = "Task 1",
                IsComplete = true
            },
            new TaskModel{
                TaskId = 2,
                Title = "Task 2",
                IsComplete = false
            },
            new TaskModel{
                TaskId = 3,
                Title = "Task 3",
                IsComplete = false
            }
        };

        public void CreateTask(TaskModel newTask)
        {
            taskList.Add(newTask);
        }

        public void EditTask(int id, TaskModel editTask)
        {
            var task = taskList.Where(x=>x.TaskId == id).FirstOrDefault();
            if(task != null) {
                task.Title = editTask.Title;
                task.IsComplete = editTask.IsComplete;
            }
        }

        public List<TaskModel> GetAll()
        {
            return taskList;
        }

        public TaskModel GetById(int id)
        {
            return taskList.Where(x=>x.TaskId == id).FirstOrDefault();
        }
        public void DeleteById(int id)
        {
            var deleteTask = taskList.Where(x=>x.TaskId == id).FirstOrDefault();
            taskList.Remove(deleteTask);
        }

        public void BulkAdd(List<TaskModel> newTaskList)
        {
            foreach(TaskModel newTask in newTaskList) {
                taskList.Add(newTask);
            }
        }

        public void BulkDelete(List<int> deletedTaskIdList)
        {
            foreach(int deletedTaskId in deletedTaskIdList) {
                TaskModel task = taskList.Where(x=>x.TaskId == deletedTaskId).FirstOrDefault();
                if(task != null) {
                    taskList.Remove(task);
                }
            }
        }
    }
}