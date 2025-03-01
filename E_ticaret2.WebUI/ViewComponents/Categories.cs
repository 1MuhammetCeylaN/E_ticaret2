﻿using E_ticaret2.Core.Entities;
using E_ticaret2.Service.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace E_ticaret2.WebUI.ViewComponents
{
    public class Categories : ViewComponent
    {
        //private readonly DatabaseContext _context;

        //public Categories(DatabaseContext context)
        //{
        //    _context = context;
        //}

        private readonly IService<Category> _service;

        public Categories(IService<Category> service)
        {
            _service = service;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            // return View(await _context.Categories.ToListAsync());
            return View(await _service.GetAllAsync(c => c.IsActive && c.IsTopMenu));
        }
    }
}
