using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AlphaMetrixForms.Web.Models.Form;
using Microsoft.AspNetCore.Mvc;

namespace AlphaMetrixForms.Web.Controllers
{
    public class FormController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public async Task<IActionResult> Post()
        {
            var model = new FormViewModel();
            return View("CreateFormView", model);
        }

    }
}