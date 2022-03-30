using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVCConcepts_Learning.Models
{
    public class Chat:Hub
    {
        public async Task sendMessage(string sender,string receiver,string msgTitle,string MessageBody)
        {
            await Clients.All.SendAsync("Receive message", sender, receiver, msgTitle, MessageBody);
        }
    }
}
