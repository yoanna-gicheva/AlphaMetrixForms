using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AlphaMetrixForms.Data.Context;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AlphaMetrixForms.Web.Controllers.API
{
    [Route("api/[controller]")]
    [ApiController]
    public class SearchController : ControllerBase
    {
        private readonly FormsContext _context;
        public SearchController(FormsContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> Search()
        {
            try
            {
                string term = HttpContext.Request.Query["term"].ToString();
                var postTitle = _context.Forms.Where(f=>f.IsClosed== false && f.IsDeleted== false && f.Title.Contains(term))
                    .Select(f=>f.Title).ToList();
                return Ok(postTitle);
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpPost]
        public string FillAutoComplete(string value)
        {
            Dictionary<string, string> dataDictionary = new Dictionary<string, string>();
            dataDictionary.Add("jQuery Validation of Email, Number, Checkbox and More", "https://www.yogihosting.com/using-jquery-to-validate-a-form/");
            dataDictionary.Add("jQuery Uncheck Checkbox Tutorial", "https://www.yogihosting.com/check-uncheck-all-checkbox-using-jquery/");
            dataDictionary.Add("Free WordPress Slider Built In jQuery", "https://www.yogihosting.com/wordpress-image-slider-effect-with-meta-slider/");
            dataDictionary.Add("Creating jQuery Expand Collapse Panels In HTML", "https://www.yogihosting.com/creating-expandable-collapsible-panels-in-jquery/");
            dataDictionary.Add("jQuery AJAX Events Complete Guide for Beginners and Experts", "https://www.yogihosting.com/jquery-ajax-events/");
            dataDictionary.Add("How to Create a Web Scraper in ASP.NET MVC and jQuery", "https://www.yogihosting.com/web-scraper/");
            dataDictionary.Add("CRUD Operations in Entity Framework and ASP.NET MVC", "https://www.yogihosting.com/crud-operations-entity-framework/");
            dataDictionary.Add("Implementing TheMovieDB (TMDB) API in ASP.NET MVC", "https://www.yogihosting.com/implement-themoviedb-api/");
            dataDictionary.Add("ASP.NET MVC Data Annotation – Server Side Validation of Controls", "https://www.yogihosting.com/server-side-validation-asp-net-mvc/");
            dataDictionary.Add("How to use CKEditor in ASP.NET MVC", "https://www.yogihosting.com/ckeditor-tutorial-asp-net-mvc/");

            StringBuilder sb = new StringBuilder();
            sb.Append("<select id=\"autoCompleteSelect\" size=\"5\">");

            foreach (KeyValuePair<string, string> entry in dataDictionary)
            {
                if (entry.Key.IndexOf(value, 0, StringComparison.CurrentCultureIgnoreCase) != -1)
                    sb.Append("<option value=\"" + entry.Value + "\">" + entry.Key + "</option>");
            }

            sb.Append("</select>");
            return sb.ToString();
        }
    }
}