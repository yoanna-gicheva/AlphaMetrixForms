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
    public class TextQuestionService : ITextQuestionService
    {
        private readonly FormsContext context;
        public TextQuestionService(FormsContext context)
        {
            this.context = context ?? throw new ArgumentNullException(nameof(context));
        }
        public async Task<bool> CreateTextQuestionAsync(ICollection<TextQuestionDTO> questionDTOs, Guid formId)
        {
            TextQuestionDTO current;
            foreach(var question in questionDTOs)
            {
                current = await CreateTextQuestionAsync(question, formId);
                if (current == null)
                    return false;
            }
            return true;
        }
        public async Task<TextQuestionDTO> CreateTextQuestionAsync(TextQuestionDTO questionDTO, Guid formId)
        {
            var question = new TextQuestion()
            {
                FormId = formId,
                Text = questionDTO.Text,
                OrderNumber = questionDTO.OrderNumber,
                IsRequired = questionDTO.IsRequired,
                IsLongAnswer = questionDTO.IsLongAnswer,
                CreatedOn = DateTime.UtcNow
        };

            await this.context.TextQuestions.AddAsync(question);
            await this.context.SaveChangesAsync();

            questionDTO.Id = question.Id;
            return questionDTO;
        }

        public async Task<bool> DeleteTextQuestionAsync(Guid questionId)
        {
            TextQuestion question = await this.context.TextQuestions
                .FirstOrDefaultAsync(f => f.Id == questionId && f.IsDeleted == false);

            if (question == null)
            {
                return false;
            }

            question.IsDeleted = true;
            question.DeletedOn = DateTime.UtcNow;
            await this.context.SaveChangesAsync();
            return true;
        }

        public async Task<ICollection<TextQuestionDTO>> GetAllTextQuestionsAsync(Guid formId)
        {
            List<TextQuestion> questions = await this.context.TextQuestions
                .Where(q => q.FormId == formId && q.IsDeleted == false)
                .ToListAsync();

            return questions.GetDtos();
        }

        public async Task<TextQuestionDTO> GetTextQuestionAsync(Guid questionId)
        {
            TextQuestion question = await this.context.TextQuestions
                .FirstOrDefaultAsync(q => q.Id == questionId && q.IsDeleted == false);

            if (question == null)
            {
                throw new ArgumentNullException($"There is no such TextQuestion with ID: {questionId}");
            }

            return question.GetDto();
        }

        public async Task<TextQuestionDTO> UpdateTextQuestionAsync(Guid questionId, TextQuestionDTO textQuestionDTO)
        {
            TextQuestion question = await this.context.TextQuestions
                .FirstOrDefaultAsync(q => q.Id == questionId && q.IsDeleted == false);

            if (question == null)
            {
                throw new ArgumentNullException($"There is no such TextQuestion with ID: {questionId}");
            }

            question.IsRequired = textQuestionDTO.IsRequired;
            question.IsLongAnswer = textQuestionDTO.IsLongAnswer;
            question.Text = textQuestionDTO.Text;
            question.ModifiedOn = DateTime.UtcNow;


            await this.context.SaveChangesAsync();

            return textQuestionDTO;
        }
    }
}
