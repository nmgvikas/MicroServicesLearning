using System;
using System.Text;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;

public class PublisherApp
{

    public static void Main()
    {


        var connectionFactory = new ConnectionFactory() { HostName = "localhost" };
        using (var connection = connectionFactory.CreateConnection())
        using (var channel = connection.CreateModel())
        {
         
            var consumer = new EventingBasicConsumer(channel);
            //assign call back anon method
            consumer.Received += (model, msg) =>
            {
                var msgBody = msg.Body.ToArray();
                var message = Encoding.UTF8.GetString(msgBody);
                Console.WriteLine($"Message Receive {message}");

            };
            //start consuming the messages
            channel.BasicConsume(queue: "newcustomers", autoAck: true, consumer: consumer);
            //keep waiting
            Console.ReadLine();


        }
    }
}
