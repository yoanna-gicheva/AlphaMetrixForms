using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace AlphaMetrixForms.Web.Controllers
{
    public class UserController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Account()
        {
            //UserViewModel user = service.UserDetails(id);
            //if (user == null)
            //    return RedirectToAction("Error");
            //return View(user);

            return View();
        }
        //public IActionResult UserForms()
        //{

        //}
    }
}