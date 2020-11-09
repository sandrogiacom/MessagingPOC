using Microsoft.Extensions.DependencyInjection;
using System;
using System.Threading;
using Tnf.Bus.Queue;
using Tnf.Bus.Queue.Interfaces;
using Tnf.Bus.Queue.RabbitMQ;

namespace MessagingPOC.Messages
{
    public static class QueuConfiguration
    {


        public static void ConfigureServiceQueueInfraDependency(this ITnfBuilder builder)
        {
            Console.WriteLine("$$$ ConfigureServiceQueueInfraDependency...");
            var exchangeRouter = GetExchangeRouterConfiguration();
            builder.BusClient(busClient =>
            {
                busClient.AddPublisher(
                    exBuilder: e => exchangeRouter,
                    listener: er => new PublisherListener(
                    exchangeRouter: er,
                    serviceProvider: busClient.ServiceProvider));
            }
            );
        }

        public static IExchangeRouter GetExchangeRouterConfiguration()
        {
            var groupCreatedEventTopicToPublish = TopicSetup.Builder
    .New(s =>
            s.Message<GroupCreateEvent>()
            .AddKey("CreateGroup.Message"));


            var queue = QueueSetup.Builder
   .New(s => s
        .QueueName("MessagingQueue")
        .Reliability(r => r
            .AutoAck(false)
            .AutoDeleteQueue(true)
            .MaxMessageSize(256)
            .PersistMessage(false))
        .QoS(q => q
            .PrefetchGlobalLimit(true)
            .PrefetchLimit(100)
            .PrefetchSize(0))
        .AddTopics(groupCreatedEventTopicToPublish));


            var exchangeRouter = ExchangeRouter
                .Builder
                .Factory()
                .Name("MessagingExchange")
                .ServerAddress("192.168.0.29")
                .Type(ExchangeType.topic)
                .QueueChannel(QueueChannel.Amqp)
                .Reliability(isDurable: false, isAutoDelete: false, isPersistent: true)
                .AddQueue(queue)
                .SetExclusive(false)
                .AutomaticRecovery(
                    isEnable: true,
                    connectionTimeout: 15000,
                    networkRecoveryInterval: TimeSpan.FromSeconds(10))
                .MessageCollector(
                    refreshInterval: TimeSpan.FromMilliseconds(value: 2000),
                    timeout: TimeSpan.FromSeconds(60))
                .ShutdownBehavior(
                    graceful: new CancellationTokenSource(),
                    forced: new CancellationTokenSource())
                .Build();


            return exchangeRouter;
        }


    }
}
