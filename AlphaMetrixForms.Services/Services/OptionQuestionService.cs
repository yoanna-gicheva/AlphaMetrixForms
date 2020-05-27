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
    public class OptionQuestionService : IOptionQuestionService
    {
        private readonly FormsContext context;
        public OptionQuestionService(FormsContext context)
        {
            this.context = context ?? throw new ArgumentNullException(nameof(context));
        }
        public async Task<bool> CreateOptionQuestionAsync(ICollection<OptionQuestionDTO> questionDTOs, Guid formId)
        {
            OptionQuestionDTO current;
            foreach (var question in questionDTOs)
            {
                current = await CreateOptionQuestionAsync(question, formId);
                if (current == null)
                    return false;
            }
            return true;
        }
        public async Task<OptionQuestionDTO> CreateOptionQuestionAsync(OptionQuestionDTO questionDTO, Guid formId)
        {
            var question = new OptionQuestion()
            {
                FormId = formId,
                Text = questionDTO.Text,
                IsRequired = questionDTO.IsRequired,
                IsMultipleAnswerAllowed = questionDTO.IsMultipleAnswerAllowed,
                CreatedOn = DateTime.UtcNow
            };

            await this.context.OptionQuestions.AddAsync(question);

            //added 2 new options for each newly created option question as per project assignment
            var option1 = new Option()
            {
                QuestionId = question.Id,
                Text = "Option 1",
                CreatedOn = DateTime.UtcNow
            };
            var option2 = new Option()
            {
                QuestionId = question.Id,
                Text = "Option 2",
                CreatedOn = DateTime.UtcNow
            };
            await this.context.Options.AddAsync(option1);
            await this.context.Options.AddAsync(option2);
            await this.context.SaveChangesAsync();

            questionDTO.Id = question.Id;
            return questionDTO;
        }

        public async Task<bool> DeleteOptionQuestionAsync(Guid questionId)
        {
            OptionQuestion question = await this.context.OptionQuestions
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

        public async Task<ICollection<OptionQuestionDTO>> GetAllOptionQuestionsAsync(Guid formId)
        {
            List<OptionQuestion> questions = await this.context.OptionQuestions
                .Where(q => q.FormId == formId && q.IsDeleted == false)
                .ToListAsync();

            return questions.GetDtos();
        }

        public async Task<OptionQuestionDTO> GetOptionQuestionAsync(Guid questionId)
        {
            OptionQuestion question = await this.context.OptionQuestions
                .Include(q => q.Options)
                .FirstOrDefaultAsync(q => q.Id == questionId && q.IsDeleted == false);

            if (question == null)
            {
                throw new ArgumentNullException($"There is no such OptionQuestion with ID: {questionId}");
            }

            return question.GetDto();
        }

        public async Task<OptionQuestionDTO> UpdateOptionQuestionAsync(Guid questionId, OptionQuestionDTO questionDTO)
        {
            OptionQuestion question = await this.context.OptionQuestions
                .FirstOrDefaultAsync(q => q.Id == questionId && q.IsDeleted == false);

            if (question == null)
            {
                throw new ArgumentNullException($"There is no such OptionQuestion with ID: {questionId}");
            }

            question.Text = questionDTO.Text;
            question.IsRequired = questionDTO.IsRequired;
            question.IsMultipleAnswerAllowed = questionDTO.IsMultipleAnswerAllowed;
            question.ModifiedOn = DateTime.UtcNow;

            await this.context.SaveChangesAsync();

            return questionDTO;
        }

        public async Task<bool> AddOptionToOptionQuestionAsync(OptionDTO optionDTO)
        {
            OptionQuestion question = await this.context.OptionQuestions
                .Include(q => q.Options)
                .FirstOrDefaultAsync(f => f.Id == optionDTO.QuestionId && f.IsDeleted == false);

            if (question == null)
            {
                return false;
            }

            var check = question.Options
                .Any(o => o.Text == optionDTO.Text);

            if (check)
            {
                return false;
            }

            var option = new Option()
            {
                QuestionId = optionDTO.QuestionId,
                Text = optionDTO.Text,
                CreatedOn = DateTime.UtcNow
            };

            await this.context.Options.AddAsync(option);
            await this.context.SaveChangesAsync();

            return true;
        }

        public async Task<bool> RemoveOptionFromOptionQuestionAsync(OptionDTO optionDTO)
        {
            OptionQuestion question = await this.context.OptionQuestions
                .Include(q => q.Options)
                .FirstOrDefaultAsync(f => f.Id == optionDTO.QuestionId && f.IsDeleted == false);

            if (question == null)
            {
                return false;
            }

            if (question.Options.Count == 2)
            {
                throw new ArgumentNullException($"Options can not be less than 2.");
            }

            var check = question.Options
                .Any(o => o.Id == optionDTO.Id);

            if (check == false)
            {
                return false;
            }

            Option option = await this.context.Options
                .Where(o => o.Id == optionDTO.Id)
                .FirstOrDefaultAsync();

            option.IsDeleted = true;
            option.DeletedOn = DateTime.UtcNow;

            await this.context.SaveChangesAsync();

            return true;
        }

        public async Task<bool> UpdateOptionForOptionQuestionAsync(OptionDTO optionDTO)
        {
            OptionQuestion question = await this.context.OptionQuestions
                .Include(q => q.Options)
                .FirstOrDefaultAsync(f => f.Id == optionDTO.QuestionId && f.IsDeleted == false);

            if (question == null)
            {
                return false;
            }

            Option option = await this.context.Options
                 .Where(o => o.Id == optionDTO.Id)
                 .FirstOrDefaultAsync();

            option.Text = optionDTO.Text;
            option.ModifiedOn = DateTime.UtcNow;

            await this.context.SaveChangesAsync();

            return true;
        }
    }
}
