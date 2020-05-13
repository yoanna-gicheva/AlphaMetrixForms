﻿using AlphaMetrixForms.Data.Entities;
using AlphaMetrixForms.Services.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AlphaMetrixForms.Services.DTOmappers
{
    public static class ResponseMapper
    {
        public static ResponseDTO GetDto(this Response entity)
        {
            if (entity == null)
            {
                throw new ArgumentException();
            };

            return new ResponseDTO
            {
                Id = entity.Id,
                FormId = entity.FormId,
                Form = entity.Form.Title,
                TextQuestionAnswers = entity.TextQuestionAnswers.GetDtos(),
                OptionQuestionAnswers = entity.OptionQuestionAnswers.GetDtos(),
                DocumentQuestionAnswers = entity.DocumentQuestionAnswers.GetDtos()
            };
        }

        public static ICollection<ResponseDTO> GetDtos(this ICollection<Response> entities)
        {
            return entities.Select(GetDto).ToList();
        }
        public static Response GetEntity(this ResponseDTO responseDTO)
        {
            if (responseDTO == null)
            {
                throw new ArgumentException();
            };

            return new Response
            {
                Id = responseDTO.Id,
                FormId = responseDTO.FormId,
                TextQuestionAnswers = TextQuestionAnswerMapper.GetEntities(responseDTO.TextQuestionAnswers),
                OptionQuestionAnswers = OptionQuestionAnswerMapper.GetEntities(responseDTO.OptionQuestionAnswers),
                DocumentQuestionAnswers = DocumentQuestionAnswerMapper.GetEntities(responseDTO.DocumentQuestionAnswers)
            };
        }
        public static ICollection<Response> GetEntities(this ICollection<ResponseDTO> dtos)
        {
            return dtos.Select(GetEntity).ToList();
        }
    }
}
