using System;
using System.Security.Cryptography;
using System.Text;
using RabbitMQ.Client;

namespace send
{
    class Send
    {
        static void Main(string[] args)
        {
            var factory = new ConnectionFactory()
            {
                // UserName = "guest",
                // Password = "guest",
                // HostName = "127.0.0.1",
                // Port = 5672

                Uri = new Uri($"amqp://guest:guest@localhost:5672"),
            };

            using (var connection = factory.CreateConnection())
            {
                using (var channel = connection.CreateModel())
                {
                    channel.QueueDeclare(queue: "hello",
                                                     durable: false,
                                                     exclusive: false,
                                                     autoDelete: false,
                                                     arguments: null);

                    var message = args.Length > 0 ? args[0] : "Hello World!";
                    var body = Encoding.UTF8.GetBytes(message);

                    channel.BasicPublish(exchange: "",
                                         routingKey: "hello",
                                         basicProperties: null,
                                         body: body);
                    Console.WriteLine(" [x] Sent {0}", message);
                }
            }

            Console.WriteLine(" Press [enter] to exit.");
            Console.ReadLine();
        }
    }
}
