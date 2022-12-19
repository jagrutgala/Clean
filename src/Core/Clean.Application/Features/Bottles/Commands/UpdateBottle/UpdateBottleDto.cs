using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clean.Application.Features.Bottles.Commands.UpdateBottle
{
    public class UpdateBottleDto
    {
        public string Brand { get; set; }
        public double Capacity { get; set; }
    }
}
