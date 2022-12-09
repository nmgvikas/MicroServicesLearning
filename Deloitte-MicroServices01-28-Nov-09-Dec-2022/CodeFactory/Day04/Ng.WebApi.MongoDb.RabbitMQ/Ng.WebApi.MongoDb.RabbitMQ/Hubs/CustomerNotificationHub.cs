using Microsoft.AspNetCore.SignalR;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using System.Threading;

namespace Ng.WebApi.MongoDb.RabbitMQ.Hubs
{
    public class CustomerNotificationHub: Hub
    {
        private static IHubCallerClients callers = null;

        //subscriber
        public async Task SubscribeToNewCustomers(string user, string message)
        {
            callers = Clients;
            /*
            for(int i=1; i <=20; i++)
            {
                Thread.Sleep(3000);
                await NotifySubscribers("New Customer");
            }
            */
        }
        //notifier
        public static async Task NotifySubscribers(string message)
        {
            await callers.All.SendAsync("NewCustomerNotification", message);
        }
    }
}
