using AlphaMetrixForms.Data.Entities;
using AlphaMetrixForms.Services.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AlphaMetrixForms.Services.DTOmappers
{
    public static class TextQuestionAnswerMapper
    {
        public static TextQuestionAnswerDTO GetDto(this TextQuestionAnswer entity)
        {
            if (entity == null)
            {
                throw new ArgumentException();
            };

            return new TextQuestionAnswerDTO
            {
                TextQuestionId = entity.TextQuestionId,
                TextQuestion = entity.TextQuestion.Text,
                ResponseId = entity.ResponseId,
                Answer = entity.Answer
            };
        }

        public static ICollection<TextQuestionAnswerDTO> GetDtos(this ICollection<TextQuestionAnswer> entities)
        {
            return entities.Select(GetDto).ToList();
        }
        //public static TextQuestionAnswer GetEntity(this TextQuestionAnswerDTO textQuestionAnswerDTO)
        //{
        //    if (textQuestionAnswerDTO == null)
        //    {
        //        throw new ArgumentException();
        //    };

        //    return new TextQuestionAnswer
        //    {
        //        TextQuestionId = textQuestionAnswerDTO.TextQuestionId,
        //        ResponseId = textQuestionAnswerDTO.ResponseId,
        //        Answer = textQuestionAnswerDTO.Answer
        //    };
        //}
        //public static ICollection<TextQuestionAnswer> GetEntities(this ICollection<TextQuestionAnswerDTO> dtos)
        //{
        //    return dtos.Select(GetEntity).ToList();
        //}
    }
}
