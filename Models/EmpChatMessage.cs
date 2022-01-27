using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ChatHubWebApplication.Models
{
    public class EmpChatMessage
    {
        public int ID { get; set; }
        public string UserName { get; set; }
        public string Message { get; set; }
    }
}