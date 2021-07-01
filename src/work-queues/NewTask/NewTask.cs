using System;
using System.Text;
using RabbitMQ.Client;

namespace NewTask
{
    class Program
    {
        static void Main(string[] args)
        {
            var factory = new ConnectionFactory()
            {
                HostName = "localhost"
            };
            using (var conn = factory.CreateConnection())
            using (var channel = conn.CreateModel())
            {
                channel.QueueDeclare("task_queue", false, false, false, arguments: null);

                string message = GetMessage(args);
                byte[] body = Encoding.UTF8.GetBytes(message);
                
                var properties = channel.CreateBasicProperties();
                properties.Persistent = true;
                
                channel.BasicPublish(exchange: "", routingKey: "task_queue", basicProperties: properties, body: body);
            }
        }
        static string GetMessage(string[] args)
        {
            return ((args.Length > 0) ? string.Join(" ", args) : "Hello World!");
        }
    }
}
