using E_ticaret2.Core.Entities;

namespace E_ticaret2.WebUI.Models
{
    public class HomePageViewModel
    {
        public List<Slider>? Sliders { get; set; }
        public List<Product>? Products { get; set; }
        public List<News>? News { get; set; }
        public List<Category>? Categories { get; set; }

    }
}
