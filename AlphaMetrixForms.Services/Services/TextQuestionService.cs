using AlphaMetrixForms.Data.Context;
using AlphaMetrixForms.Data.Entities;
using AlphaMetrixForms.Services.Contracts;
using AlphaMetrixForms.Services.DTOmappers;
using AlphaMetrixForms.Services.DTOs;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
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
        public async Task<TextQuestionDTO> CreateTextQuestionAsync(TextQuestionDTO questionDTO, Guid formId)
        {
            var check = await context.TextQuestions.FirstOrDefaultAsync(q => q.Text == questionDTO.Text && q.IsDeleted == false);

            if(check != null)
            {
                throw new ArgumentException($"Text question with Text: {questionDTO.Text} already exists.");
            }

            var question = new TextQuestion()
            {
                FormId = formId,
                Text = questionDTO.Text,
                IsRequired = questionDTO.IsRequired,
                IsLongAnswer = questionDTO.IsLongAnswer
            };

            await context.TextQuestions.AddAsync(question);
            await context.SaveChangesAsync();

            return questionDTO;
        }

        public async Task<bool> DeleteTextQuestionAsync(Guid questionId)
        {
            TextQuestion question = await context.TextQuestions.FirstOrDefaultAsync(f => f.Id == questionId && f.IsDeleted == false);

            if (question == null)
            {
                return false;
            }

            question.IsDeleted = true;
            await context.SaveChangesAsync();
            return true;
        }

        public async Task<ICollection<TextQuestionDTO>> GetAllTextQuestionsAsync(Guid formId)
        {
            Form form = await context.Forms.FirstOrDefaultAsync(u => u.Id == formId && u.IsDeleted == false);
            var questions = form.TextQuestions;

            return TextQuestionMapper.GetDtos(questions);
        }

        public async Task<TextQuestionDTO> GetTextQuestionAsync(Guid questionId)
        {
            TextQuestion question = await context.TextQuestions.FirstOrDefaultAsync(q => q.Id == questionId && q.IsDeleted == false);

            if (question == null)
            {
                throw new ArgumentNullException($"There is no such DocumentQuestion with ID: {questionId}");
            }

            return TextQuestionMapper.GetDto(question);
        }

        public async Task<TextQuestionDTO> UpdateTextQuestionAsync(Guid questionId, TextQuestionDTO textQuestionDTO)
        {
            TextQuestion question = await context.TextQuestions.FirstOrDefaultAsync(q => q.Id == questionId && q.IsDeleted == false);

            if (question == null)
            {
                throw new ArgumentNullException($"There is no such TextQuestion with ID: {questionId}");
            }

            question = TextQuestionMapper.GetEntity(textQuestionDTO);
            await context.SaveChangesAsync();

            return textQuestionDTO;
        }
    }
}
