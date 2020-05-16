using System;
namespace Rmq.Application.Producer.IntegrationEvents
{
    public class LogIntegrationEvent
    {
        public Guid Id { get; set; }
        public string Message { get; set; }
    }
}
