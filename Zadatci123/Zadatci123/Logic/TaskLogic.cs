using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Zadatci123.Models;

namespace Zadatci123.Logic
{
    public class TaskLogic
    {
        public static async Task<List<TaskItem>> GetTasks()
        {
            return await Constants.MobileService.GetTable<TaskItem>().Where(t => t.UserId == Constants.CurrentUser.Id).ToListAsync();
        }

        public static async Task<bool> AddTask(TaskItem taskItem)
        {
            taskItem.UserId = Constants.CurrentUser.Id;

            await Constants.MobileService.GetTable<TaskItem>().InsertAsync(taskItem);

            if (!String.IsNullOrEmpty(taskItem.Id))
            {
                Constants.TasksList = await GetTasks();
                return true;
            }
            else return false;
        }

        public static async Task<bool> EditTask(TaskItem taskItem, TaskItem existingTask)
        {
            existingTask.Name = taskItem.Name;
            existingTask.Priority = taskItem.Priority;
            existingTask.PriorityText = taskItem.PriorityText;
            existingTask.DueDate = taskItem.DueDate;
            existingTask.RemindMe = taskItem.RemindMe;

            await Constants.MobileService.GetTable<TaskItem>().UpdateAsync(existingTask);
            Constants.TasksList = await GetTasks();

            return true;
        }

        public static async Task DeleteTask(TaskItem taskItem)
        {
            await Constants.MobileService.GetTable<TaskItem>().DeleteAsync(taskItem);
            Constants.TasksList = await GetTasks();
        }

        public static async Task CompleteTask(TaskItem taskItem)
        {
            taskItem.IsCompleted = true;
            await Constants.MobileService.GetTable<TaskItem>().UpdateAsync(taskItem);
            Constants.TasksList = await GetTasks();
        }
    }
}
