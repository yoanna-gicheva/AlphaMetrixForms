using AlphaMetrixForms.Data.Entities;
using AlphaMetrixForms.Services.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AlphaMetrixForms.Services.DTOmappers
{
    public static class OptionQuestionMapper
    {
        public static OptionQuestionDTO GetDto(this OptionQuestion entity)
        {
            if (entity == null)
            {
                throw new ArgumentException();
            };

            return new OptionQuestionDTO
            {
                Id = entity.Id,
                FormId = entity.FormId,
                Form = entity.Form.Title,
                Text = entity.Text,
                IsRequired = entity.IsRequired,
                Options = entity.Options.GetDtos(),
                //Answers = entity.Answers.GetDtos()
            };
        }

        public static ICollection<OptionQuestionDTO> GetDtos(this ICollection<OptionQuestion> entities)
        {
            return entities.Select(GetDto).ToList();
        }
        //public static OptionQuestion GetEntity(this OptionQuestionDTO optionQuestionDTO)
        //{
        //    if (optionQuestionDTO == null)
        //    {
        //        throw new ArgumentException();
        //    };

        //    return new OptionQuestion
        //    {
        //        Id = optionQuestionDTO.Id,
        //        FormId = optionQuestionDTO.FormId,
        //        Text = optionQuestionDTO.Text,
        //        IsRequired = optionQuestionDTO.IsRequired,
        //        Options = OptionMapper.GetEntities(optionQuestionDTO.Options),
        //    };
        //}
        //public static ICollection<OptionQuestion> GetEntities(this ICollection<OptionQuestionDTO> dtos)
        //{
        //    return dtos.Select(GetEntity).ToList();
        //}
    }
}
