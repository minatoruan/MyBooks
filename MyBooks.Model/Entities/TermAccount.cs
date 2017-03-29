namespace MyBooks.Model.Entities
{
    public class TermAccount
    {
        public Account Account { get; set; }

        public DiscountZeroRate DiscountRate { get; set; }

        public TermBalance Balance { get; set; }
    }
}