using AlphaMetrixForms.Services.DTOs;
using AlphaMetrixForms.Web.Models.Form;
using AlphaMetrixForms.Web.Models.Question;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AlphaMetrixForms.Web.AutoMapper
{
    public class AutoMapper : Profile
    {
        public AutoMapper()
        {
            CreateMap<FormViewModel, FormDTO>();
            CreateMap<QuestionViewModel, TextQuestionDTO>();
            CreateMap<QuestionViewModel, OptionQuestionDTO>();
            CreateMap<QuestionViewModel, DocumentQuestionDTO>();
        }
    }
}
