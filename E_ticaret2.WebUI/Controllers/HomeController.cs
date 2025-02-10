using System.Diagnostics;
using E_ticaret2.Core.Entities;
using E_ticaret2.Data;
using E_ticaret2.Service.Abstract;
using E_ticaret2.WebUI.Models;
using Microsoft.AspNetCore.Mvc;

namespace E_ticaret2.WebUI.Controllers
{
    public class HomeController : Controller
    {
        //private readonly DatabaseContext _context;

        //public HomeController(DatabaseContext context)
        //{
        //    _context = context;
        //}

        private readonly IService<Product> _serviceProduct;
        private readonly IService<News> _serviceNews;
        private readonly IService<Slider> _serviceSlider;
        private readonly IService<Contact> _serviceContact;
        private readonly DatabaseContext _databaseContext;

        public HomeController(IService<Product> serviceProduct, IService<News> serviceNews, IService<Slider> serviceSlider, IService<Contact> serviceContact, DatabaseContext databaseContext)
        {
            _serviceProduct = serviceProduct;
            _serviceNews = serviceNews;
            _serviceSlider = serviceSlider;
            _serviceContact = serviceContact;
            _databaseContext = databaseContext;
        }


        public async Task<IActionResult> Index()
        {

            var model = new HomePageViewModel()
            {
                //Sliders = await _context.Sliders.ToListAsync(),
                //Products = await _context.Products.Where(p => p.IsActive && p.IsHome).ToListAsync(),
                //News = await _context.News.ToListAsync()

                Sliders = await _serviceSlider.GetAllAsync(),
                Products = await _serviceProduct.GetAllAsync(p => p.IsActive && p.IsHome),
                News = await _serviceNews.GetAllAsync(n => n.IsActive)
            };
            return View(model);
        }

        [HttpGet]
        public IActionResult ContactUs()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> ContactUs(Contact contact)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    // await _context.Contacts.AddAsync(contact);
                    await _serviceContact.AddAsync(contact);
                    var sonuc = await _serviceContact.SaveChangesAsync();
                    if (sonuc > 0)
                    {
                        TempData["Message"] = @"<div class=""alert alert-success alert-dismissible fade show"" role=""alert"">
                        <strong>Mesaj�n�z Ba�ar�yla �letilmi�tir!</strong>
    <button type=""button"" class=""btn-close"" data-bs-dismiss=""alert"" aria-label=""Close""></button>
    </div>";
                        // await MailHelper.SendMailAsync(contact);
                        return RedirectToAction("ContactUs");
                    }
                }
                catch (Exception)
                {
                    ModelState.AddModelError("", "Hata Olu�tu!");
                }
            }
            return View(contact);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        [Route("AccessDenied")] // Buraya �zel bir route ile geliecek yani /Home/AccessDenied de�ilde direk /AccessDenied ile gelinebilr.
        public IActionResult AccessDenied()
        {
            return View();
        }
    }
}
