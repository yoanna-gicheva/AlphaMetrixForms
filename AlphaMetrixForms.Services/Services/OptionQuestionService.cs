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
    public class OptionQuestionService : IOptionQuestionService
    {
        private readonly FormsContext context;
        public OptionQuestionService(FormsContext context)
        {
            this.context = context ?? throw new ArgumentNullException(nameof(context));
        }
        public async Task<OptionQuestionDTO> CreateOptionQuestionAsync(OptionQuestionDTO questionDTO, Guid formId)
        {
            var check = await context.OptionQuestions.FirstOrDefaultAsync(q => q.Text == questionDTO.Text && q.IsDeleted == false);

            if (check != null)
            {
                throw new ArgumentException($"Option question with Text: {questionDTO.Text} already exists.");
            }

            var question = new OptionQuestion()
            {
                FormId = questionDTO.FormId,
                Text = questionDTO.Text,
                IsRequired = questionDTO.IsRequired
            };

            await context.OptionQuestions.AddAsync(question);
            await context.SaveChangesAsync();

            return questionDTO;
        }

        public async Task<bool> DeleteOptionQuestionAsync(Guid questionId)
        {
            OptionQuestion question = await context.OptionQuestions.FirstOrDefaultAsync(f => f.Id == questionId && f.IsDeleted == false);

            if (question == null)
            {
                return false;
            }

            question.IsDeleted = true;
            await context.SaveChangesAsync();
            return true;
        }

        public async Task<ICollection<OptionQuestionDTO>> GetAllOptionQuestionsAsync(Guid formId)
        {
            Form form = await context.Forms.FirstOrDefaultAsync(u => u.Id == formId && u.IsDeleted == false);
            var questions = form.OptionQuestions;

            return OptionQuestionMapper.GetDtos(questions);
        }

        public async Task<OptionQuestionDTO> GetOptionQuestionAsync(Guid questionId)
        {
            OptionQuestion question = await context.OptionQuestions.FirstOrDefaultAsync(q => q.Id == questionId && q.IsDeleted == false);

            if (question == null)
            {
                throw new ArgumentNullException($"There is no such DocumentQuestion with ID: {questionId}");
            }

            return OptionQuestionMapper.GetDto(question);
        }

        public async Task<OptionQuestionDTO> UpdateOptionQuestionAsync(Guid questionId, OptionQuestionDTO questionDTO)
        {
            OptionQuestion question = await context.OptionQuestions.FirstOrDefaultAsync(q => q.Id == questionId && q.IsDeleted == false);

            if (question == null)
            {
                throw new ArgumentNullException($"There is no such OptionQuestion with ID: {questionId}");
            }

            question = OptionQuestionMapper.GetEntity(questionDTO);
            await context.SaveChangesAsync();

            return questionDTO;
        }
    }
}
