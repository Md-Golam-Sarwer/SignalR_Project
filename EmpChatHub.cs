using ChatHubWebApplication.Models;
using Microsoft.AspNet.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ChatHubWebApplication
{
    public class EmpChatHub : Hub
    {
        public void SendMessage(string name, string message)
        {
            EmpChatMessage empChatMessage = new EmpChatMessage();
            empChatMessage.UserName = name;
            empChatMessage.Message = message;

            ApplicationDbContext db = new ApplicationDbContext();
            db.EmpChatMessages.Add(empChatMessage);
            db.SaveChanges();

            Clients.All.broadcastMessage(name, message);

        }
    }
}