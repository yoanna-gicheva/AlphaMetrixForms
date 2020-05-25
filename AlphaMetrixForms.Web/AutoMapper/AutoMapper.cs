﻿using AlphaMetrixForms.Data.Entities;
using AlphaMetrixForms.Services.DTOs;
using AlphaMetrixForms.Web.Models.Form;
using AlphaMetrixForms.Web.Models.Question;
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
            CreateMap<FormDTO, FormViewModel>().ReverseMap();
            CreateMap<FormViewModel, FormDTO>();
            CreateMap<Form, FormDTO>().ReverseMap();

            CreateMap<QuestionViewModel, TextQuestionDTO>();
            CreateMap<TextQuestionDTO, QuestionViewModel>();
            CreateMap<QuestionViewModel, OptionQuestionDTO>();
            CreateMap<OptionQuestionDTO, QuestionViewModel>();
            CreateMap<QuestionViewModel, DocumentQuestionDTO>();
            CreateMap<DocumentQuestionDTO, QuestionViewModel>();

            CreateMap<User, UserDTO>().ReverseMap();
            CreateMap<UserDTO, UserViewModel>();

        }
    }
}
