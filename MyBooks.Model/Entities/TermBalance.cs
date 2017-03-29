using System;

namespace MyBooks.Model.Entities
{
    public class TermBalance : EntityBase
    {
        public Guid AccountId { get; set; }

        public string Term { get; set; }

        public decimal Balance { get; set; }
    }
}