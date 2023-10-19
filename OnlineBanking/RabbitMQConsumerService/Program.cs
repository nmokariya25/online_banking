//Here we specify the Rabbit MQ Server. we use rabbitmq docker image and use it
using Newtonsoft.Json;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System.Text;

var factory = new ConnectionFactory
{
    HostName = "localhost"
};
//Create the RabbitMQ connection using connection factory details as i mentioned above
var connection = factory.CreateConnection();
//Here we create channel with session and model
using
var channelOrderPayment = connection.CreateModel();
//declare the queue after mentioning name and a few property related to that
channelOrderPayment.QueueDeclare("ob_account_create", exclusive: false);
//Set Event object which listen message from chanel which is sent by producer
var consumerOrderPayment = new EventingBasicConsumer(channelOrderPayment);
consumerOrderPayment.Received += async (model, eventArgs) =>
{
    var body = eventArgs.Body.ToArray();
    var message = Encoding.UTF8.GetString(body);
};
//read the message
channelOrderPayment.BasicConsume(queue: "ob_account_create", autoAck: true, consumer: consumerOrderPayment);
