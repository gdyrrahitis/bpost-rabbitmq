using MediatR;
using Microsoft.Extensions.Logging;
using System.Threading;
using System.Threading.Tasks;

namespace Rmq.Application.Consumer.Commands.Handlers
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
