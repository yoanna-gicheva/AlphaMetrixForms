using AlphaMetrixForms.Data.Context;
using AlphaMetrixForms.Data.Entities;
using AlphaMetrixForms.Services.Contracts;
using AlphaMetrixForms.Services.DTOmappers;
using AlphaMetrixForms.Services.DTOs;
using AutoMapper;
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
                OrderNumber = questionDTO.OrderNumber,
                IsRequired = questionDTO.IsRequired,
                IsMultipleAnswerAllowed = questionDTO.IsMultipleAnswerAllowed
            };
            await context.OptionQuestions.AddAsync(question);
            await context.SaveChangesAsync();
            int orderOfOptions = 1;
            foreach (var option in questionDTO.Options)
            {
                Option toAdd = new Option();
                toAdd.Text = option.Text;
                toAdd.QuestionId = question.Id;
                toAdd.OrderNumber = orderOfOptions;
                orderOfOptions++;
                await context.Options.AddAsync(toAdd);
            }
            await context.SaveChangesAsync();
            questionDTO.Id = question.Id;
            return questionDTO;
        }

        public async Task<OptionQuestionDTO> UpdateOptionQuestionAsync(Guid questionId, OptionQuestionDTO questionDTO)
        {
            OptionQuestion question = await this.context.OptionQuestions
                .FirstOrDefaultAsync(q => q.Id == questionId);

            if (question == null)
            {
                throw new ArgumentNullException($"There is no such OptionQuestion with ID: {questionId}");
            }

            question.Text = questionDTO.Text;
            question.IsRequired = questionDTO.IsRequired;
            question.IsMultipleAnswerAllowed = questionDTO.IsMultipleAnswerAllowed;

            await this.context.SaveChangesAsync();

            return questionDTO;
        }

        public async Task OptionQuestion_DetectChanges(Guid formId, ICollection<OptionQuestionDTO> questions)
        {
            foreach (var question in questions)
            {
                if (context.OptionQuestions.Any(q => q.Id == question.Id))
                {
                    await this.UpdateOptionQuestionAsync(question.Id, question);
                }
                else
                {
                    await this.CreateOptionQuestionAsync(question, formId);
                }
            }
        }

        public async Task CreateOptionQuestionAnswerRadioAsync(Guid responseId, Guid questionId, string answer)
        {
            if (answer == null)
            {
                return;
            }
            var optionAnswer = new OptionQuestionAnswer
            {
                ResponseId = responseId,
                OptionQuestionId = questionId,
                Answer = answer
            };

            await this.context.OptionQuestionAnswers.AddAsync(optionAnswer);
            await this.context.SaveChangesAsync();
        }

        public async Task CreateOptionQuestionAnswerCheckboxAsync(Guid responseId, Guid questionId, List<bool> checkboxes)
        {
            if (checkboxes.Contains(true)==false)
            {
                return;
            }
            var options = await this.context.Options
                .Where(o => o.QuestionId == questionId)
                .OrderBy(o => o.OrderNumber)
                .ToListAsync();

            if (options.Count != checkboxes.Count)
            {
                throw new ArgumentException("Invalid number of options received.");
            }

            for (int i = 0; i < checkboxes.Count; i++)
            {
                if (checkboxes[i] == true)
                {
                    var optionAnswer = new OptionQuestionAnswer
                    {
                        ResponseId = responseId,
                        OptionQuestionId = questionId,
                        Answer = options[i].Text
                    };
                    await context.OptionQuestionAnswers.AddAsync(optionAnswer);
                }
            }
            await this.context.SaveChangesAsync();
        }

    }
}
