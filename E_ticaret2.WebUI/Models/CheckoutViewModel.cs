using E_ticaret2.Core.Entities;

namespace E_ticaret2.WebUI.Models
{
    public class CheckoutViewModel
    {
        public List<CartLine> CartProducts { get; set; }
        public decimal TotalPrice { get; set; }
        public List<Address>? Addresses { get; set; }
    }
}
