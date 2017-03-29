using System;

namespace MyBooks.Model.Entities
{
    public class DiscountZeroRate : EntityBase
    {
        public Guid AccountId { get; set; }

        public DateTime StartDateTime { get; set; }

        public DateTime EndDateTime { get; set; }
    }
}