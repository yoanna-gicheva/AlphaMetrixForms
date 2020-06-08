using AlphaMetrixForms.Services.DTOs;
using AlphaMetrixForms.Web.Models.Enums;
using AlphaMetrixForms.Web.Models.Form;
using AlphaMetrixForms.Web.Models.Question;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AlphaMetrixForms.Web.Utils
{
    public class ModelGenerator
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
    }

}
