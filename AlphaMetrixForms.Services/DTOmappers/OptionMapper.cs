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

        public static Option GetEntity(this OptionDTO optionDTO)
        {
            if (optionDTO == null)
            {
                throw new ArgumentException();
            };

            return new Option
            {
                Id = optionDTO.Id,
                QuestionId = optionDTO.QuestionId,
                Text = optionDTO.Text
            };
        }
        public static ICollection<Option> GetEntities(this ICollection<OptionDTO> optionDTOs)
        {
            return optionDTOs.Select(GetEntity).ToList();
        }
    }
}
