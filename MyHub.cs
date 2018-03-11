using Microsoft.AspNet.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SignalRProject
{
    public class MyHub : Hub
    {
        public void Allowclient(string message)
        {
            if(!string.IsNullOrEmpty(message))
            {
                message = "message from hub";
            }
            Clients.All.Allowclient(message);
        }

        public void Logoutall()
        {
            Clients.All.Logoutall();
        }
    }
}