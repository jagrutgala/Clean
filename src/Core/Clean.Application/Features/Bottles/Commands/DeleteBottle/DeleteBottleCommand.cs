using Clean.Application.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Clean.Application.Features.Bottles.Commands.DeleteBottle
{
    public class DeleteBottleCommand : IRequest<Response<Unit>>
    {
        public string Id { get; set; }
    }
}
