﻿using E_ticaret2.Core.Entities;
using E_ticaret2.Service.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace E_ticaret2.WebUI.Controllers
{
    public class NewsController : Controller
    {
        //private readonly DatabaseContext _context;

        //public NewsController(DatabaseContext context)
        //{
        //    _context = context;
        //}

        private readonly IService<News> _service;

        public NewsController(IService<News> service)
        {
            _service = service;
        }

        public async Task<IActionResult> IndexAsync()
        {
            // return View(await _context.News.ToListAsync());
            return View(await _service.GetAllAsync());
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            // var news = await _context.News.FirstOrDefaultAsync(m => m.Id == id);
            var news = await _service.GetAsync(m => m.Id == id && m.IsActive);
            if (news == null)
            {
                return NotFound("Geçerli Kampanya Bulunamadı");
            }

            return View(news);
        }
    }
}
