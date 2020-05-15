using MediatR;
using Microsoft.Extensions.Logging;
using Rmq.Common.Commands;
using System.Threading;
using System.Threading.Tasks;

namespace Rmq.Application.Consumer.CommandHandlers
{
    public class LogCommandHandler : IRequestHandler<LogCommand>
    {
        private readonly ILogger<LogCommandHandler> _logger;

        public LogCommandHandler(ILogger<LogCommandHandler> logger) => _logger = logger;

        public Task<Unit> Handle(LogCommand request, CancellationToken cancellationToken)
        {
            _logger.LogInformation("---- Received message: {Message} ----", request.Message);
            return Task.FromResult(Unit.Value);
        }
    }
}
