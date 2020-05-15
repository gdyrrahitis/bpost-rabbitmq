using System;
using System.Reflection;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using RabbitMQ.Client;
using Rmq.Application.Consumer.CommandHandlers;
using Rmq.Common.Commands;

namespace Rmq.Application.Consumer
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services
                .AddMediatR(Assembly.GetExecutingAssembly())
                .AddTransient<IRequestHandler<LogCommand, Unit>, LogCommandHandler>()
                .AddHostedService<LogConsumer>().AddSingleton(serviceProvider =>
                {
                    var uri = new Uri("amqp://guest:guest@rabbit:5672/CUSTOM_HOST");
                    return new ConnectionFactory
                    {
                        Uri = uri,
                        DispatchConsumersAsync = true
                    };
                });
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
        }
    }
}
