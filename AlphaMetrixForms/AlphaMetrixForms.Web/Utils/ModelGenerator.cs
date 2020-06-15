using AlphaMetrixForms.Services.DTOs;
using AlphaMetrixForms.Web.Models.Enums;
using AlphaMetrixForms.Web.Models.Form;
using AlphaMetrixForms.Web.Models.Question;
using AlphaMetrixForms.Web.Models.Response;
using AlphaMetrixForms.Web.Utils.Contracts;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AlphaMetrixForms.Web.Utils
{
    public class ModelGenerator : IModelGenerator
    {
        public static void QuestionType_Set(ICollection<QuestionViewModel> questions, QuestionType type)
        {
            foreach (var question in questions)
            {
                if (question.Type == QuestionType.Text)
                {
                    question.Type = type;
                }
            }
        }
        public static FormViewModel ViewModel_Generator(FormDTO formDTO, IMapper _mapper)
        {
            FormViewModel result = _mapper.Map<FormViewModel>(formDTO);
            result.Questions.AddRange(_mapper.Map<ICollection<QuestionViewModel>>(formDTO.OptionQuestions));
            ModelGenerator.QuestionType_Set(result.Questions, QuestionType.Option);
            result.Questions.AddRange(_mapper.Map<ICollection<QuestionViewModel>>(formDTO.DocumentQuestions));
            ModelGenerator.QuestionType_Set(result.Questions, QuestionType.Document);
            result.Questions.AddRange(_mapper.Map<ICollection<QuestionViewModel>>(formDTO.TextQuestions));

            return result;
        }
        public static FormDTO DataTransferObject_Generator(FormViewModel form, IMapper _mapper)
        {
            FormDTO formDTO = _mapper.Map<FormDTO>(form);
            formDTO.TextQuestions = _mapper.Map<ICollection<TextQuestionDTO>>(form.Questions.Where(q => q.Type == QuestionType.Text));
            formDTO.OptionQuestions = _mapper.Map<ICollection<OptionQuestionDTO>>(form.Questions.Where(q => q.Type == QuestionType.Option));
            formDTO.DocumentQuestions = _mapper.Map<ICollection<DocumentQuestionDTO>>(form.Questions.Where(q => q.Type == QuestionType.Document));

            return formDTO;
        }

        public void Response_TextRelationship(FormDTO formDTO, ResponseDisplayModel vm)
        {
            foreach (var textQuestion in formDTO.TextQuestions)
            {
                var vm2 = new AnswerViewModel();
                vm2.Text = textQuestion.Text;
                vm2.OrderNumber = textQuestion.OrderNumber;
                vm2.Id = textQuestion.Id;
                vm2.Type = QuestionType.Text;
                foreach (var response in formDTO.Responses)
                {
                    foreach (var textQuestionAnswer in response.TextQuestionAnswers)
                    {
                        if (vm2.Id == textQuestionAnswer.TextQuestionId)
                        {
                            vm2.Answer = textQuestionAnswer.Answer;
                        }
                    }
                }
                vm.Answers.Add(vm2);
            }
        }
        public void Response_OptionRelationship(FormDTO formDTO, ResponseDisplayModel vm)
        {
            foreach (var documentQuestion in formDTO.DocumentQuestions)
            {
                var vm2 = new AnswerViewModel();
                vm2.Text = documentQuestion.Text;
                vm2.OrderNumber = documentQuestion.OrderNumber;
                vm2.Id = documentQuestion.Id;
                vm2.Type = QuestionType.Document;
                vm.Answers.Add(vm2);
                foreach (var response in formDTO.Responses)
                {
                    foreach (var documentQuestionAnswer in response.DocumentQuestionAnswers)
                    {
                        if (vm2.Id == documentQuestionAnswer.DocumentQuestionId)
                        {
                            vm2.Answers.Add(documentQuestionAnswer.Answer);
                        }
                    }
                }
            }
        }
        public void Response_DocumentRelationship(FormDTO formDTO, ResponseDisplayModel vm)
        {
            foreach (var optionQuestion in formDTO.OptionQuestions)
            {
                var vm2 = new AnswerViewModel();
                vm2.Text = optionQuestion.Text;
                vm2.OrderNumber = optionQuestion.OrderNumber;
                vm2.Id = optionQuestion.Id;
                vm2.Type = QuestionType.Option;
                vm.Answers.Add(vm2);
                foreach (var response in formDTO.Responses)
                {
                    foreach (var optionQuestionAnswer in response.OptionQuestionAnswers)
                    {
                        if (vm2.Id == optionQuestionAnswer.OptionQuestionId)
                        {
                            vm2.Answers.Add(optionQuestionAnswer.Answer);
                        }
                    }
                }
            }
        }
    }

}
