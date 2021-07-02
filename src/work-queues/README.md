# Work-Queues Tutorial

This tutorial follows the instructions provided by the RabbitMQ's [page](https://www.rabbitmq.com/tutorials/tutorial-two-dotnet.html).

> The main idea behind *Work Queues* (aka: Task Queues) is to avoid doing a 
> resource-intensive task immediately and having to wait for it to complete. 
> Instead we schedule the task to be done later. We encapsulate a task as a 
> message and send it to a queue. A worker process running in the background 
> will pop the tasks and eventually execute the job. When you run many 
> workers the tasks will be shared between them.

## Try it
Follow these steps to get this example running properly

*Note: you'll need, at least, four consoles*

1. Start Docker
2. Run file "rabbitmq-server.ps1" from the root folder
3. Run the script **start_receiver.ps1** twice to create multiple receivers
4. Run the script **start_producer.ps1** to start firing messages to the workers (aka receivers)
5. Check the results on the consoles of the receivers.