namespace Webbshop.Models
{
    public class AccountProduct
    {
        public int AccountID { get; set; }
        public Account Account { get; set; }

        public int ProductID { get; set; }
        public Product Product { get; set; }
    }
}
