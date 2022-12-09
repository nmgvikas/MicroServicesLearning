using System;
using System.Text;
using RabbitMQ.Client;

public class PublisherApp
{

    public static void Main()
    {


        var connectionFactory = new ConnectionFactory() { HostName = "localhost", Port = 5672 };
        using (var connection = connectionFactory.CreateConnection())
        using (var channel = connection.CreateModel())
        {
            channel.QueueDeclare(queue: "newcustomers",
                durable: false,
                exclusive: false,
                autoDelete: false,
                arguments: null

                );
            //always use Date and Time in UTF for JSON
            for (int i = 1; i <= 20; i++)
            {
                string strNow = DateTime.Now.ToUniversalTime().ToString();
                string newCustomer = $"'id':{300 + i},'name':'Customer {i.ToString()}','location':'Chennai','customerSince':{strNow},'totalPurchases':{321 * (i + 14.2)}";
                string newCustomerJson = "{" + newCustomer + "}";
                var msgBody = Encoding.UTF8.GetBytes(newCustomerJson);

                //publish the message 1 by 1
                Thread.Sleep(5000);
                channel.BasicPublish(exchange: "",
                    routingKey: "newcustomers",
                    basicProperties: null,
                    body: msgBody
                    );

                Console.WriteLine($"Sent message with id{300+i.ToString()}");

            }
        }
    }

}