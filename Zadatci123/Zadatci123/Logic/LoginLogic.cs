using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zadatci123.Models;

namespace Zadatci123.Logic
{
    public class LoginLogic
    {
        public static async Task<bool> Login(string email, string password)
        {
            User user = (await Constants.MobileService.GetTable<User>().Where(u => u.Email == email && u.Password == password).ToListAsync()).FirstOrDefault();

            if (user != null)
            {
                Constants.CurrentUser = user;
                Constants.TasksList = await TaskLogic.GetTasks();
                return true;
            }
            else return false;
        }
    }
}
