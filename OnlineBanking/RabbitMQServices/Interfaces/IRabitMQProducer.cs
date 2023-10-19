using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RabbitMQServices.Interfaces
{
    public interface IRabitMQProducer
    {
        public void SendMessage<T>(T message, string queueName);
    }
}
