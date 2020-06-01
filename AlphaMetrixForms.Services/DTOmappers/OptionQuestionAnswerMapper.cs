using AlphaMetrixForms.Data.Entities;
using AlphaMetrixForms.Services.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AlphaMetrixForms.Services.DTOmappers
{
    public static class OptionQuestionAnswerMapper
    {
        public static OptionQuestionAnswerDTO GetDto(this OptionQuestionAnswer entity)
        {
            if (entity == null)
            {
                throw new ArgumentException();
            };

            return new OptionQuestionAnswerDTO
            {
                OptionQuestionId = entity.OptionQuestionId,
                //OptionQuestion = entity.OptionQuestion.Text,
                ResponseId = entity.ResponseId,
                Answer = entity.Answer
            };
        }

        public static ICollection<OptionQuestionAnswerDTO> GetDtos(this ICollection<OptionQuestionAnswer> entities)
        {
            return entities.Select(GetDto).ToList();
        }
        //public static OptionQuestionAnswer GetEntity(this OptionQuestionAnswerDTO optionQuestionAnswerDTO)
        //{
        //    if (optionQuestionAnswerDTO == null)
        //    {
        //        throw new ArgumentException();
        //    };

        //    return new OptionQuestionAnswer
        //    {
        //        OptionQuestionId = optionQuestionAnswerDTO.OptionQuestionId,
        //        ResponseId = optionQuestionAnswerDTO.ResponseId,
        //        Answer = optionQuestionAnswerDTO.Answer
        //    };
        //}
        //public static ICollection<OptionQuestionAnswer> GetEntities(this ICollection<OptionQuestionAnswerDTO> dtos)
        //{
        //    return dtos.Select(GetEntity).ToList();
        //}
    }
    
}
