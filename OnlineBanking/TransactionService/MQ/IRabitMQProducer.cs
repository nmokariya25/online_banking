﻿namespace TransactionService.MQ
{
    public interface IRabitMQProducer
    {
        public void SendMessage<T>(T message, string queueName);
    }
}
