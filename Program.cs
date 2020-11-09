using MessagingPOC.Messages;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace MessagingPOC
{
    class Program
    {

        static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args)
            => Host.CreateDefaultBuilder(args)
                .ConfigureServices((hostContext, services) =>
            {
                services.AddTnfAspNetCore((options =>
                {
                    options.ConfigureServiceQueueInfraDependency();
                }));
                services.AddInfra1Dependency();
                services.AddHostedService<Worker>();
            });

    }

}