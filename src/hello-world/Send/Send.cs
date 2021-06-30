using System;
using System.Text;
using System.Text.Json;
using RabbitMQ.Client;

namespace Send
{
    class Program
    {
        const string QUEUE_NAME = "0-800-hello";
        static void Main(string[] args)
        {
            var factory = new ConnectionFactory()
            {
                HostName = "localhost"
            };
            using (var conn = factory.CreateConnection())
            using (var channel = conn.CreateModel())
            {
                channel.QueueDeclare(QUEUE_NAME, false, false, false, arguments: null);

                string message = JsonSerializer.Serialize(new
                {
                    IssuedBy = "Sender",
                    IssuedAt = DateTime.UtcNow,
                    Body = "Hello, world from Sender"
                });
                byte[] body = Encoding.UTF8.GetBytes(message);

                channel.BasicPublish(exchange: "", routingKey: QUEUE_NAME, basicProperties: null, body: body);

                Console.WriteLine("Message sent to queue \"{0}\"", QUEUE_NAME);
            }
            Console.ReadLine();
        }
    }
}
