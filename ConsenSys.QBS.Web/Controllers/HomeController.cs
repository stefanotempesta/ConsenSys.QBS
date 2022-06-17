﻿using ConsenSys.QBS.Web.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace ConsenSys.QBS.Web.Controllers;

public class HomeController : Controller
{
    public IActionResult Index()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error() => View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
}
