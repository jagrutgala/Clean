using Clean.Application.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Clean.Application.Features.Bottles.Commands.UpdateBottle
{
    public class UpdateBottleCommand: IRequest<Response<UpdateBottleDto>>
    {
        public string Id { get; set; }
        public string Brand { get; set; }
        public double Capacity { get; set; }
    }
}
