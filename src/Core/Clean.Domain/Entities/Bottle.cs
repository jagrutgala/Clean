using Clean.Domain.Common;

namespace Clean.Domain.Entities
{
    public class Bottle : AuditableEntity
    {
        public string Id { get; set; }
        public string Brand { get; set; }
        public double Capacity { get; set; }

    }
}
