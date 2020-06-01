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
    public class DocumentQuestionService : IDocumentQuestionService
    {
        private readonly FormsContext context;
        public DocumentQuestionService(FormsContext context)
        {
            this.context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<bool> CreateDocumentQuestionAsync(ICollection<DocumentQuestionDTO> questionDTOs, Guid formId)
        {
            DocumentQuestionDTO current;
            foreach (var question in questionDTOs)
            {
                current = await CreateDocumentQuestionAsync(question, formId);
                if (current == null)
                    return false;
            }
            return true;
        }
        public async Task<DocumentQuestionDTO> CreateDocumentQuestionAsync(DocumentQuestionDTO questionDTO, Guid formId)
        {
            var question = new DocumentQuestion()
            {
                FormId = formId,
                Text = questionDTO.Text,
                OrderNumber = questionDTO.OrderNumber,
                IsRequired = questionDTO.IsRequired,
                FileNumberLimit = questionDTO.FileNumberLimit,
                FileSizeLimit = questionDTO.FileSizeLimit
            };

            await this.context.DocumentQuestions.AddAsync(question);
            await this.context.SaveChangesAsync();

            questionDTO.Id = question.Id;
            return questionDTO;
        }

        public async Task<DocumentQuestionDTO> UpdateDocumentQuestionAsync(Guid questionId, DocumentQuestionDTO questionDTO)
        {
            DocumentQuestion question = await this.context.DocumentQuestions
                .FirstOrDefaultAsync(q => q.Id == questionId);

            if (question == null)
            {
                throw new ArgumentNullException($"There is no such DocumentQuestion with ID: {questionId}");
            }

            question.IsRequired = questionDTO.IsRequired;
            question.FileSizeLimit = questionDTO.FileSizeLimit;
            question.FileNumberLimit = questionDTO.FileNumberLimit;
            question.Text = questionDTO.Text;

            await this.context.SaveChangesAsync();

            return questionDTO;
        }

        public async Task DocumentQuestion_DetectChanges(Guid formId, ICollection<DocumentQuestionDTO> questions)
        {
            foreach (var question in questions)
            {
                if (context.DocumentQuestions.Any(q => q.Id == question.Id))
                {
                    await this.UpdateDocumentQuestionAsync(question.Id, question);
                }
                else
                {
                    await this.CreateDocumentQuestionAsync(question, formId);
                }
            }
        }
    }
}
