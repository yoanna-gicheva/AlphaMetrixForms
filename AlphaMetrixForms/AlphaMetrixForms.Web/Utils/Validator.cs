using AlphaMetrixForms.Web.Models;
using AlphaMetrixForms.Web.Models.Enums;
using AlphaMetrixForms.Web.Models.Form;
using AlphaMetrixForms.Web.Models.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AlphaMetrixForms.Web.Utils
{
    public class Validator
    {
        public static string ModifyModelValidation_Message(FormViewModel form)
        {
            if(form.Questions.Count == 0)
            {
                return "Please, add at least one question!";
            }
            if (form.Title == null)
            {
                return "Please, insert a title!";
            }
            else if (form.Title.Count() > 150)
            {
                return "A form title should be less than 150 symbols.";
            }
            foreach (var question in form.Questions)
            {
                if (question.Text == null)
                {
                    return "Oops, there is a question without text.";
                }
            }
            foreach (var question in form.Questions.Where(q => q.Type == QuestionType.Option))
            {
                foreach (var option in question.Options)
                {
                    if (option.Text == null)
                    {
                        return "Please, provide a text for each option.";
                    }
                }
            }
            return null;
        }
        public static string ResponseValidation_Message(ResponseViewModel response)
        {
            string _textQuestionMessage = ResponseTextQuestion_Validation(response);
            if(_textQuestionMessage != null)
            {
                return _textQuestionMessage;
            }

            string _optionQuestionMessage = ResponseOptionQuestion_Validation(response);
            if (_optionQuestionMessage != null)
            {
                return _optionQuestionMessage;
            }

            string _documentQuestionMessage = ResponseDocumentQuestion_Validation(response);
            if (_documentQuestionMessage != null)
            {
                return _documentQuestionMessage;
            }
            return null;
        }
        private static string ResponseTextQuestion_Validation(ResponseViewModel response)
        {
            foreach(var textQuestion in response.Questions.Where(q=>q.Type == QuestionType.Text))
            {
                if(textQuestion.TextAnswer == null && textQuestion.IsRequired)
                {
                    return $"Please, provide answer for question #{textQuestion.OrderNumber + 1}";
                }
            }
            return null;
        }
        private static string ResponseOptionQuestion_Validation(ResponseViewModel response)
        {
            foreach (var optionQuestion in response.Questions.Where(q => q.Type == QuestionType.Option))
            {
                if (optionQuestion.IsMultipleAnswerAllowed && !optionQuestion.OptionQuestionAnswerCheckbox.Any(o=>o == true) && optionQuestion.IsRequired)
                {
                    return $"Please, provide answer for question #{optionQuestion.OrderNumber + 1}";
                }
                if (!optionQuestion.IsMultipleAnswerAllowed && optionQuestion.OptionQuestionAnswerRadio == null && optionQuestion.IsRequired)
                {
                    return $"Please, provide answer for question #{optionQuestion.OrderNumber + 1}";
                }
            }
            return null;
        }
        private static string ResponseDocumentQuestion_Validation(ResponseViewModel response)
        {
            foreach (var documentQuestion in response.Questions.Where(q => q.Type == QuestionType.Document))
            {
                if(documentQuestion.IsRequired && (documentQuestion.DocumentAnswer == null || documentQuestion.DocumentAnswer.Count() == 0))
                {
                    return $"Please, provide answer for question #{documentQuestion.OrderNumber + 1}";
                }
                if (documentQuestion.DocumentAnswer != null && documentQuestion.DocumentAnswer.Count() > documentQuestion.FileNumberLimit)
                {
                    return $"There is a file number limit of {documentQuestion.FileNumberLimit} for question #{documentQuestion.OrderNumber + 1}";
                }
                if(documentQuestion.DocumentAnswer != null && documentQuestion.DocumentAnswer.Count() > 0)
                {
                    foreach(var document in documentQuestion.DocumentAnswer)
                    {
                        if(document.Length/ (1024 * 1024) > documentQuestion.FileSizeLimit)
                        {
                            return $"There is a file size limit of {documentQuestion.FileSizeLimit} for question #{documentQuestion.OrderNumber + 1}";
                        }
                    }
                }
            }
            return null;
        }

        public static string ContactModelValidation_Message(ContactUsViewModel vm)
        {
            if (vm.Sender == null)
            {
                return "Please share your name!";
            }
            else if (vm.Subject == null)
            {
                return "Please add a subject!";
            }
            else if (vm.Content == null)
            {
                return "Please add body of your message!";
            }
            else if (vm.CallBackInfo == null)
            {
                return "Please add contact back details!";
            }
            return null;
        }
    }
}
