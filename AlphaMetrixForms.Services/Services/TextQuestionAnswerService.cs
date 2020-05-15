using AlphaMetrixForms.Data.Context;
using AlphaMetrixForms.Data.Entities;
using AlphaMetrixForms.Services.Contracts;
using AlphaMetrixForms.Services.DTOmappers;
using AlphaMetrixForms.Services.DTOs;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlphaMetrixForms.Services.Services
{
    public class TextQuestionAnswerService : ITextQuestionAnswerService
    {
        private readonly FormsContext context;
        public TextQuestionAnswerService(FormsContext context)
        {
            this.context = context ?? throw new ArgumentNullException(nameof(context));
        }
        public async Task<TextQuestionAnswerDTO> CreateTextQuestionAnswerAsync(TextQuestionAnswerDTO answerDTO, Guid formId)
        {
            var answer = new TextQuestionAnswer()
            {
                TextQuestionId = answerDTO.TextQuestionId,
                ResponseId = answerDTO.ResponseId,
                Answer = answerDTO.Answer
            };

            await this.context.TextQuestionAnswers.AddAsync(answer);
            await this.context.SaveChangesAsync();

            //Is ID needed in entity and answerDto?
            //answerDTO.Id = answer.Id;
            return answerDTO;
        }

        public Task<bool> DeleteTextQuestionAnswerAsync(Guid answerId)
        {
            throw new NotImplementedException();

            //TextQuestionAnswer answer = await this.context.TextQuestions
            //    .FirstOrDefaultAsync(f => f.Id == answerId && f.IsDeleted == false);

            //if (answer == null)
            //{
            //    return false;
            //}

            //answer.IsDeleted = true;
            //answer.DeletedOn = DateTime.UtcNow;
            //await this.context.SaveChangesAsync();
            //return true;
        }

        public async Task<ICollection<TextQuestionAnswerDTO>> GetAllTextQuestionsAnswerAsync(Guid responseId)
        {
            List<TextQuestionAnswer> answers = await this.context.TextQuestionAnswers
                .Where(q => q.ResponseId == responseId /*&& q.IsDeleted == false*/)
                .ToListAsync();

            return answers.GetDtos();
        }

        public Task<TextQuestionAnswerDTO> GetTextQuestionAnswerAsync(Guid questionId)
        {
            throw new NotImplementedException();
            // Id? 
        }

        public Task<TextQuestionAnswerDTO> UpdateTextQuestionAnswerAsync(Guid questionId, TextQuestionAnswerDTO textQuestionDTO)
        {
            throw new NotImplementedException();
        }
    }
}
