﻿using Microsoft.AspNetCore.Mvc;

namespace ErrorHanding.Controllers
{
    public class ProductController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}