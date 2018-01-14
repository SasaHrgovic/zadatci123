using Microsoft.WindowsAzure.MobileServices;
using System;
using System.Collections.Generic;
using System.Text;
using Zadatci123.Models;

namespace Zadatci123
{
    public static class Constants
    {
        public static MobileServiceClient MobileService =
            new MobileServiceClient(
            "https://zadatci123.azurewebsites.net"
        );

        public static User CurrentUser { get; set; }
        public static List<Task> TasksList { get; set; }
    }
}
