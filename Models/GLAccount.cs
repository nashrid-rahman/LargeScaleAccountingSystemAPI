namespace LargeScaleAccountingSystemAPI.Models
{
    public class GLAccount
    {
        public Guid Id { get; set; }
        public string AccountNumber { get; set; }
        public string CurrentBalance { get; set; }
        public string DrCr { get; set; }

        public string GlType { get; set; }

        public enum Type
        {
            Assets = 1,
            Liabilities = 2,
            Income=3,
            Expenses=4

        }





    }
}
