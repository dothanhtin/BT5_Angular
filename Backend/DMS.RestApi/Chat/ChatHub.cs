using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR;

namespace DMS.RestApi.Chat
{
    public class ChatHub : Hub
    {
        
        public async Task SendNotification(string user, string message)
        {
            await Clients.All.SendAsync("NotificationReceived", user, message);
        }

        public async Task SendNotificationToClient (string user, Message message)
        {
            await Clients.All.SendAsync("NotificationToClient", user, message);
        }

        private static int Count;

        public override Task OnConnectedAsync()
        {
            Count++;
            base.OnConnectedAsync();
            this.Clients.All.SendAsync("updateCount", Count);
            return Task.CompletedTask;
        }

        public override Task OnDisconnectedAsync(Exception exception)
        {
            Count--;
            base.OnDisconnectedAsync(exception);
            this.Clients.All.SendAsync("updateCount", Count);
            return Task.CompletedTask;
        }
    }
}
