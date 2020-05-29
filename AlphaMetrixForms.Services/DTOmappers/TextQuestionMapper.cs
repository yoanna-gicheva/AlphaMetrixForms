using AlphaMetrixForms.Data.Entities;
using AlphaMetrixForms.Services.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AlphaMetrixForms.Services.DTOmappers
{
    public static class TextQuestionMapper
    {
        public static TextQuestionDTO GetDto(this TextQuestion entity)
        {
            if (entity == null)
            {
                throw new ArgumentException();
            };

            return new TextQuestionDTO
            {
                Id = entity.Id,
                FormId = entity.FormId,
                OrderNumber = entity.OrderNumber,

                Form = entity.Form.Title,
                Text = entity.Text,
                IsRequired = entity.IsRequired,
                IsLongAnswer = entity.IsLongAnswer,
                //Answers = entity.Answers.GetDtos()
            };
        }

        public static ICollection<TextQuestionDTO> GetDtos(this ICollection<TextQuestion> entities)
        {
            return entities.Select(GetDto).ToList();
        }
        //public static TextQuestion GetEntity(this TextQuestionDTO textQuestionDTO)
        //{
        //    if (textQuestionDTO == null)
        //    {
        //        throw new ArgumentException();
        //    };

        //    return new TextQuestion
        //    {
        //        Id = textQuestionDTO.Id,
        //        FormId = textQuestionDTO.FormId,
        //        Text = textQuestionDTO.Text,
        //        IsRequired = textQuestionDTO.IsRequired,
        //        IsLongAnswer = textQuestionDTO.IsLongAnswer,
        //    };
        //}
        //public static ICollection<TextQuestion> GetEntities(this ICollection<TextQuestionDTO> dtos)
        //{
        //    return dtos.Select(GetEntity).ToList();
        //}
    }
}
