using McDonalds.Domein.Common;

namespace McDonalds.Domein.Entity.Menu
{
    public class Desserts_Bakery : Auditible
    {
        public string Name { get; set; }

        public string Description { get; set; }

        public int Value { get; set; }
    }
}
