using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Zadatci123.Models;

namespace Zadatci123.Logic
{
    public class RegistrationLogic
    {
        public static async Task<bool> Register(string name, string email, string password)
        {
            User user = new User()
            {
                Name = name,
                Email = email,
                Password = password
            };

            await Constants.MobileService.GetTable<User>().InsertAsync(user);

            if (!String.IsNullOrEmpty(user.Id))
            {
                Constants.CurrentUser = user;
                return true;
            }
            else return false;
        }
    }
}
