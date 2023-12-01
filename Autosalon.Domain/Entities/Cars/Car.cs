using Autosalon.Domain.Commons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Autosalon.Domain.Entities.Cars
{
    public class Car : Auditable
    {
        public string Name { get; set; }

        public string Model { get; set; }

        public string Country { get; set; }

        public int Payment { get; set; }
    }
}
