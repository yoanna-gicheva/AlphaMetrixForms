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
                ResponseId = entity.ResponseId,
                Answer = entity.Answer
            };
        }

        public static ICollection<TextQuestionAnswerDTO> GetDtos(this ICollection<TextQuestionAnswer> entities)
        {
            return entities.Select(GetDto).ToList();
        }
    }
}
