using JH.Monitor.Retriever.ServiceBusPublisher.Interfaces;
using System;
using System.Threading.Tasks;
using Azure.Messaging.ServiceBus;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using JH.Monitor.Retriever.Common;


namespace JH.Monitor.Retriever.ServiceBusPublisher
{
    public class TopicServices : ITopicServices
    {
        private readonly ILogger<TopicServices> Logger;
        private ServiceBusClient? Client;
        private ServiceBusSender? Sender;
        private readonly IConfiguration _configuration;

        public TopicServices(IConfiguration configuration, ILogger<TopicServices> logger)
        {
            this._configuration = configuration;
            this.Logger = logger;
        }
        public async Task<string> SendMessage(string topicName, string redditSubs)
        {
            Client = new ServiceBusClient(_configuration.GetValue<string>(ConfigurationKeys.ServiceBusConnectionString));
            Sender = Client.CreateSender(topicName);

            using ServiceBusMessageBatch messageBatch = await Sender.CreateMessageBatchAsync();
            if (!messageBatch.TryAddMessage(new ServiceBusMessage(redditSubs)))
            {
                throw new Exception($"The message is too large to fit in the batch.");
            }

            try
            {
                await Sender.SendMessagesAsync(messageBatch);
                return ($"The Message has been published to the queue.");
            }
            catch (Exception ex)
            {
                Logger.LogError($"There was an error sending the message to the queue", topicName, ex.Message, ex.ToString());
                throw;
            }
        }

    }

}
