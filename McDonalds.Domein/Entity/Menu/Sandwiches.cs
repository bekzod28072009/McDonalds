using McDonalds.Domein.Common;

namespace McDonalds.Domein.Entity.Menu
{
    public class Sandwiches : Auditible
    {
        public string Name { get; set; }

        public string Description { get; set; }

        public int Value { get; set; }
    }
}
