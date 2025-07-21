using System;

namespace testGPBA.Models
{
    public class Supplier
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime CreatedDate { get; set; }

        public ICollection<Offer> Offers { get; set; }
    }
}
