using System;
namespace Rmq.Common.IntegrationEvents
{
    public class LogIntegrationEvent
    {
        public Guid Id { get; set; }
        public string Message { get; set; }
    }
}
