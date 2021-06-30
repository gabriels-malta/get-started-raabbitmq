using System;
using System.Text;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;

namespace Receive
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

                EventingBasicConsumer consumer = new EventingBasicConsumer(channel);
                consumer.Received += (model, ea) =>
                {
                    byte[] body = ea.Body.ToArray();
                    string message = Encoding.UTF8.GetString(body);
                    Console.WriteLine($"Message received at {DateTime.UtcNow.ToString()}");
                    Console.WriteLine("Content: {0}", message);
                };

                channel.BasicConsume(QUEUE_NAME, true, consumer: consumer);

                Console.WriteLine("Listening the queue \"{0}\"", QUEUE_NAME);
                Console.ReadLine();
            }
        }
    }
}
