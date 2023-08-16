namespace LargeScaleAccountingSystemAPI.Models
{
    public class Transaction
    {
        public Guid Id { get; set; }
        public string AccountNumber { get; set; }
        public string CurrencyCode { get; set; }
        public double Amount { get; set; }
        public string DrCr { get; set; }



    }
}
