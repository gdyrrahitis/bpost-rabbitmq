using Microsoft.Extensions.Logging;
using RabbitMQ.Client;
using Rmq.Common;
using Rmq.Common.IntegrationEvents;

namespace Rmq.Producer
{
    public class LogProducer : ProducerBase<LogIntegrationEvent>
    {
        public LogProducer(
            ConnectionFactory connectionFactory, 
            ILogger<RabbitMqClientBase> logger, 
            ILogger<ProducerBase<LogIntegrationEvent>> producerBaseLogger) : 
            base(connectionFactory, logger, producerBaseLogger)
        {
        }
    }
}
