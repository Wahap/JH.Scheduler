using Azure.Messaging.ServiceBus;
using JH.Scheduler.Requester.Common;
using JH.Scheduler.Requester.Queue.Interfaces;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;

namespace JH.Scheduler.Requester.Queue
{
    public class QueueServices : IQueueServices
    {
        private readonly ILogger<QueueServices> Logger;
        private ServiceBusClient? Client;
        private ServiceBusSender? Sender;
        private readonly IConfiguration _configuration;

        public QueueServices(IConfiguration configuration, ILogger<QueueServices> logger)
        {
            this._configuration = configuration;
            this.Logger = logger;
        }
        public async Task<string> SendMessage(string queueName, string message)
        {
            Client = new ServiceBusClient(_configuration.GetValue<string>(ConfigurationKeys.ServiceBusConnectionString));
            Sender = Client.CreateSender(queueName);

            using ServiceBusMessageBatch messageBatch = await Sender.CreateMessageBatchAsync();
            if (!messageBatch.TryAddMessage(new ServiceBusMessage(message)))
            {
                throw new Exception($"The message is too large to fit in the batch.");
            }

            try
            {
                await Sender.SendMessagesAsync(messageBatch);
                return ($"The Message {message} has been published to the queue.");
            }
            catch (Exception ex)
            {
                Logger.LogError($"There was an error sending the message to the queue", queueName, ex.Message, ex.ToString());
                throw;
            }
        }
    }

}
