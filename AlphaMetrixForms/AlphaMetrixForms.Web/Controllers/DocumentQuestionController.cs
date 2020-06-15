using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AlphaMetrixForms.Services.Contracts;
using AlphaMetrixForms.Services.Providers.Contracts;
using AlphaMetrixForms.Web.Models.Enums;
using AlphaMetrixForms.Web.Models.Form;
using AlphaMetrixForms.Web.Models.Question;
using Microsoft.AspNetCore.Mvc;

namespace AlphaMetrixForms.Web.Controllers
{
    public class DocumentQuestionController : Controller
    {
        private readonly IBlobProvider _blob;
        private readonly Dictionary<string, string> _typesDictionary;

        public DocumentQuestionController(IBlobProvider blob)
        {
            _blob = blob ?? throw new ArgumentNullException(nameof(blob));
            _typesDictionary = _blob.TypeDict_Setter();
        }
        [HttpPost]
        public IActionResult CreateDocumentQuestion(FormViewModel form)
        {
            QuestionViewModel model = new QuestionViewModel();
            model.OrderNumber = form.Questions.Count;
            model.Type = QuestionType.Document;
            form.Questions.Add(model);

            return PartialView("_QuestionPartial", form);

        }
        public async Task<IActionResult> DownloadFile(string name)
        {
            try
            {
                var stream = await _blob.DownloadFileAsync(name);
                var array = name.Split('.');
                var fileExtension = array[array.Length - 1].ToLower();
                string contentType = _typesDictionary[fileExtension];
                string folderRef = name.Split('/')[0];
                string fileName = name.Substring(folderRef.Length + 1);
                return File(stream, contentType, fileName);
            }
            catch (Exception)
            {
                return NotFound();
            }
        }

    }
}