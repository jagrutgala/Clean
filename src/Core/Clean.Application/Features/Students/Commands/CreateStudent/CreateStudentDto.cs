using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clean.Application.Features.Students.Commands.CreateStudent
{
    public class CreateStudentDto
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Course { get; set; }
    }
}
