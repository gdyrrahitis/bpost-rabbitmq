using System;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using RabbitMQ.Client;
using Rmq.Application.BackgroundTasks;
using Rmq.Application.Producer;
using Rmq.Common;
using Rmq.Common.IntegrationEvents;

namespace Rmq.Application
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services
                .AddHostedService<LogBackgroundTask>()
                .AddSingleton<IRabbitMqProducer<LogIntegrationEvent>, LogProducer>()
                .AddSingleton(serviceProvider =>
                {
                    var uri = new Uri("amqp://guest:guest@rabbit:5672/CUSTOM_HOST");
                    return new ConnectionFactory
                    {
                        Uri = uri
                    };
                });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
        }
    }
}
