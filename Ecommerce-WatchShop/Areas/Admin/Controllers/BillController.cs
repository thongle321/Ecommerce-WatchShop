﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DongHo_Admin.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class BillController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
