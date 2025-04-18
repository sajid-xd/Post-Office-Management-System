using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Post_Office_Management.Models;

namespace Post_Office_Management.Controllers;

public class HomeController : Controller
{
    readonly MyContext hh;
    private readonly string _uploadsFolderPath;
    public HomeController(IWebHostEnvironment env, MyContext dd)
    {
        _uploadsFolderPath = Path.Combine(env.WebRootPath, "images");
        hh = dd;
    }

    public IActionResult Index()
    {
        return View();
    }

    public IActionResult Register()
    {
        return View();
    }
    [HttpPost]
    public IActionResult Register(Register us)
    {
        if (ModelState.IsValid)
        {
            var obj = new Register();
            obj.email = us.email;
            obj.name = us.name;
            obj.password = us.password;
            obj.Role = "user";
            hh.register.Add(obj);
            hh.SaveChanges();
            return RedirectToAction("Index");

        }
        return View(us);
    }
    public IActionResult Login()
    {
        return View();
    }
    [HttpPost]
    public IActionResult Login(Login u)
    {
        var obj = hh.register.FirstOrDefault(x => x.email == u.email && x.password == u.password);
        if (obj != null)
        {
            if (obj.Role == "user")
            {
                return RedirectToAction("Index");
            }
            else
            {
                if (obj.Role == "admin")
                {
                    return RedirectToAction("dashboard");
                }
            }
        }
        return View();
    }

    public IActionResult dashboard()
    {
        return View();
    }
}
