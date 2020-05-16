using MediatR;
using System;

namespace Rmq.Application.Consumer.Commands
{
    public class LogCommand : IRequest<Unit>
    {
        public Guid Id { get; set; }
        public string Message { get; set; }
    }
}
