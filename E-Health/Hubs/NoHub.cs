using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.SignalR;

namespace E_Health.Hubs
{
    public class NoHub : Hub
    {
        public void Hello()
        {
            Clients.All.hello();
        }
    }
}