using AlphaMetrixForms.Data.Entities;
using AlphaMetrixForms.Services.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AlphaMetrixForms.Services.DTOmappers
{
    public static class FormMapper
    {
        public static FormDTO GetDto(this Form entity)
        {
            if (entity == null)
            {
                throw new ArgumentException();
            };

            return new FormDTO
            {
                Id = entity.Id,
                Title = entity.Title,
                Description = entity.Description,
                OwnerId = entity.OwnerId,
                Owner = entity.Owner.UserName,
                TextQuestions = entity.TextQuestions.GetDtos(),
                OptionQuestions = entity.OptionQuestions.GetDtos(),
                DocumentQuestions = entity.DocumentQuestions.GetDtos(),
                Responses = entity.Responses.GetDtos()
            };
        }

        public static ICollection<FormDTO> GetDtos(this ICollection<Form> entities)
        {
            return entities.Select(GetDto).ToList();
        }
    }
}
