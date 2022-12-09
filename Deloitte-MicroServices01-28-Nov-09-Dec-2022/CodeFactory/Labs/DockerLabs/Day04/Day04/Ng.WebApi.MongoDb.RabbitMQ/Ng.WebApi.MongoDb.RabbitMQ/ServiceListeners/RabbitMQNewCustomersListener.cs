using Ng.WebApi.MongoDb.RabbitMQ.Hubs;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System.Text;

namespace Ng.WebApi.MongoDb.RabbitMQ.ServiceListeners
{
    public class RabbitMQNewCustomersListener
    {
        //public fields (you can load this from config)
        public ConnectionFactory factory { get; set; }
        public IConnection connection { get; set; }

        public IModel channel { get; set; }

        //c'tor
        public RabbitMQNewCustomersListener()
        {
            //to access from localhost
            //this.factory = new ConnectionFactory() { HostName = "localhost", Port=5672};
            //To access from docker container
            this.factory = new ConnectionFactory() { HostName = "172.17.0.3", Port=5672};
            
            this.connection = factory.CreateConnection();
            this.channel = connection.CreateModel();
        }
        //Called by the Extension Method when the App is starting
        //Start listening
        public void Register()
        {
            var consumer = new EventingBasicConsumer(channel);
            //assign call back anon method
            consumer.Received += (model, msg) =>
            {
                var msgBody = msg.Body.ToArray();
                var message = Encoding.UTF8.GetString(msgBody);
                //Console.WriteLine($"Message Receive {message}");
                //Relay the message to the notifier in CustomerNotificationHub
                Task.Factory.StartNew(() =>
                {
                     CustomerNotificationHub.NotifySubscribers(message);
                });

            };
            //start consuming the messages
            channel.BasicConsume(queue: "newcustomers", autoAck: true, consumer: consumer);
        }

        public void UnRegister()
        {
            //close the connections
            this.connection.Close();
        }
    }
}
