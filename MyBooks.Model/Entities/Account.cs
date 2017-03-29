using System;

namespace MyBooks.Model.Entities
{
    public class Account : EntityBase
    {
        public Guid LogOnId { get; set; }

        public string Code { get; set; }

        public DateTime OpenDate { get; set; }

        public byte ClosingDay { get; set; }

        public bool IsActive { get; set; }
    }
}
