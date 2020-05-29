using AlphaMetrixForms.Data.Entities;
using AlphaMetrixForms.Services.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AlphaMetrixForms.Services.DTOmappers
{
    public static class DocumentQuestionMapper
    {
        public static DocumentQuestionDTO GetDto(this DocumentQuestion entity)
        {
            if (entity == null)
            {
                throw new ArgumentException();
            };

            return new DocumentQuestionDTO
            {
                Id = entity.Id,
                FormId = entity.FormId,
                Form = entity.Form.Title,
                OrderNumber = entity.OrderNumber,
                Text = entity.Text,
                IsRequired = entity.IsRequired,
                FileNumberLimit = entity.FileNumberLimit,
                FileSizeLimit = entity.FileSizeLimit,
                //Answers = entity.Answers.GetDtos()
            };
        }

        public static ICollection<DocumentQuestionDTO> GetDtos(this ICollection<DocumentQuestion> entities)
        {
            return entities.Select(GetDto).ToList();
        }

        //public static DocumentQuestion GetEntity(this DocumentQuestionDTO documentQuestionDTO)
        //{
        //    if (documentQuestionDTO == null)
        //    {
        //        throw new ArgumentException();
        //    };

        //    return new DocumentQuestion
        //    {
        //        Id = documentQuestionDTO.Id,
        //        FormId = documentQuestionDTO.FormId,
        //        Text = documentQuestionDTO.Text,
        //        IsRequired = documentQuestionDTO.IsRequired,
        //        FileNumberLimit = documentQuestionDTO.FileNumberLimit,
        //        FileSizeLimit = documentQuestionDTO.FileSizeLimit,
        //    };
        //}
        //public static ICollection<DocumentQuestion> GetEntities(this ICollection<DocumentQuestionDTO> dtos)
        //{
        //    return dtos.Select(GetEntity).ToList();
        //}
    }
}
