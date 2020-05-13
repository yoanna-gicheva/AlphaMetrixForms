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
                Answers = entity.Answers.GetDtos()
            };
        }

        public static ICollection<OptionQuestionDTO> GetDtos(this ICollection<OptionQuestion> entities)
        {
            return entities.Select(GetDto).ToList();
        }
    }
}
