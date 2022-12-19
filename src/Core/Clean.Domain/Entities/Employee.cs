using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace Clean.Domain.Entities
{
    public class Employee
    {
        public int Id { get; set; }
        public string  Name { get; set; }
        public string JobTitle { get; set; }
        public string EmailAddress { get; set; }
    }
}
