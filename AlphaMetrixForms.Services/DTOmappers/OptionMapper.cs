using AlphaMetrixForms.Data.Entities;
using AlphaMetrixForms.Services.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AlphaMetrixForms.Services.DTOmappers
{
    public static class OptionMapper
    {
        public static OptionDTO GetDto(this Option entity)
        {
            if (entity == null)
            {
                throw new ArgumentException();
            };

            return new OptionDTO
            {
                Id = entity.Id,
                QuestionId = entity.QuestionId,
                Question = entity.Question.Text,
                Text = entity.Text
            };
        }

        public static ICollection<OptionDTO> GetDtos(this ICollection<Option> entities)
        {
            return entities.Select(GetDto).ToList();
        }
    }
}
