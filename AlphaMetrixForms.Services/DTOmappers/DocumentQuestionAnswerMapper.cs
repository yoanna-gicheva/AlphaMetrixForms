using AlphaMetrixForms.Data.Entities;
using AlphaMetrixForms.Services.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AlphaMetrixForms.Services.DTOmappers
{
    public static class DocumentQuestionAnswerMapper
    {
        public static DocumentQuestionAnswerDTO GetDto(this DocumentQuestionAnswer entity)
        {
            if (entity == null)
            {
                throw new ArgumentException();
            };

            return new DocumentQuestionAnswerDTO
            {
                DocumentQuestionId = entity.DocumentQuestionId,
                DocumentQuestion = entity.DocumentQuestion.Text,
                ResponseId = entity.ResponseId,
                Answer = entity.Answer
            };
        }

        public static ICollection<DocumentQuestionAnswerDTO> GetDtos(this ICollection<DocumentQuestionAnswer> entities)
        {
            return entities.Select(GetDto).ToList();
        }
    }
}
