using Microsoft.WindowsAzure.MobileServices;
using System;
using System.Collections.Generic;
using System.Text;

namespace Zadatci123
{
    public static class Constants
    {
        public static MobileServiceClient MobileService =
            new MobileServiceClient(
            "https://zadatci123.azurewebsites.net"
        );
    }
}
