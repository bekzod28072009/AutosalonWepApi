using Autosalon.Domain.Commons;

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
