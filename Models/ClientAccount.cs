namespace LargeScaleAccountingSystemAPI.Models
{
    public class ClientAccount
    {

        public Guid Id { get; set; }
        public string AccountNumber { get; set; }
        public string CurrentBalance { get; set; }       
       
        public enum Type
        {
            Demand = 1,
            Time = 2,
            Scheme=3,
            Loan=4

        }





    }
}
