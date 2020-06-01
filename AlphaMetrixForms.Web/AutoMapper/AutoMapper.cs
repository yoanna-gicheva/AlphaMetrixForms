using AlphaMetrixForms.Data.Entities;
using AlphaMetrixForms.Services.DTOs;
using AlphaMetrixForms.Web.Models.Form;
using AlphaMetrixForms.Web.Models.Question;
using AlphaMetrixForms.Web.Models.Response;
using AlphaMetrixForms.Web.Models.User;
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
            CreateMap<FormDTO, FormViewModel>();
            CreateMap<FormViewModel, FormDTO>();
            CreateMap<ResponseViewModel, ResponseDTO>();
            CreateMap<ResponseDTO, ResponseViewModel>();

            CreateMap<Form, FormDTO>().ReverseMap();

            CreateMap<QuestionViewModel, TextQuestionDTO>();
            CreateMap<TextQuestionDTO, QuestionViewModel>();
            CreateMap<QuestionViewModel, OptionQuestionDTO>();
            CreateMap<OptionQuestionDTO, QuestionViewModel>();
            CreateMap<QuestionViewModel, DocumentQuestionDTO>();
            CreateMap<DocumentQuestionDTO, QuestionViewModel>();
            //CreateMap<string, OptionDTO>().ForMember(dest => dest.Text,
            //   opts => opts.MapFrom(src => src)).ReverseMap();
            //CreateMap<string, string>().ReverseMap();
            CreateMap<OptionViewModel, OptionDTO>().ReverseMap();

            CreateMap<User, UserDTO>().ReverseMap();
            CreateMap<UserDTO, UserViewModel>();

        }
    }
}
