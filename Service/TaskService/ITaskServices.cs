using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Day_8.Model;


namespace Day_8.Service.TaskService
{
    public interface ITaskServices
    {
        
        public List<TaskModel> GetAll();
        public void CreateTask(TaskModel newTask);
        public void EditTask(int id, TaskModel editTask);
        public TaskModel GetById(int id);
        public void DeleteById(int id);
        public void BulkAdd(List<TaskModel> newTaskList);
        public void BulkDelete(List<int> deletedTaskIdList);
    }
}