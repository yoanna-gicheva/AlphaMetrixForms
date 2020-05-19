using AlphaMetrixForms.Services.DTOs;
using AlphaMetrixForms.Web.Models.DocumentQuestion;
using AlphaMetrixForms.Web.Models.Form;
using AlphaMetrixForms.Web.Models.OptionsQuestion;
using AlphaMetrixForms.Web.Models.TextQuestion;
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
            CreateMap<TextQuestionViewModel, TextQuestionDTO>();
            CreateMap<OptionsQuestionViewModel, OptionQuestionDTO>();
            CreateMap<DocumentQuestionViewModel, DocumentQuestionDTO>();
        }
    }
}
