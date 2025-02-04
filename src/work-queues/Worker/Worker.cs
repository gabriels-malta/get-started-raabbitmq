﻿using System;
using System.Text;
using System.Threading;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;

namespace Worker
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
                channel.QueueDeclare("task_queue", true, false, false, arguments: null);
                channel.BasicQos(0, 1, false);
                
                EventingBasicConsumer consumer = new EventingBasicConsumer(channel);
                consumer.Received += (model, ea) =>
                {
                    var body = ea.Body.ToArray();
                    var message = Encoding.UTF8.GetString(body);
                    Console.WriteLine(" [x] Received {0}", message);

                    int dots = message.Split('.').Length - 1;
                    int milliseconds = dots * 1000;

                    Console.WriteLine(" [X] Will be processed for {0} milliseconds", milliseconds);
                    Thread.Sleep(milliseconds);
                    Console.WriteLine(" [x] Done\n     ------");

                    channel.BasicAck(ea.DeliveryTag, false);
                };
                channel.BasicConsume("task_queue", false, consumer: consumer);
                Console.WriteLine("Listening...");
                Console.ReadLine();
            }
        }
    }
}
