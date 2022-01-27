using ChatHubWebApplication.Models;
using Microsoft.AspNet.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace ChatHubWebApplication
{
    public class EmpChatPer : PersistentConnection
    {
        protected override Task OnConnected(IRequest request, string connectionId)
        {
            return Connection.Send(connectionId, "Welcome!");
        }

        protected override Task OnReceived(IRequest request, string connectionId, string data)
        {
            EmpChatMessage empChatMessage = new EmpChatMessage();
            
            empChatMessage.Message = data;

            ApplicationDbContext db = new ApplicationDbContext();
            db.EmpChatMessages.Add(empChatMessage);
            db.SaveChanges();
            return Connection.Broadcast(data);
        }
    }
}