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
                IsRequired = questionDTO.IsRequired,
                FileNumberLimit = questionDTO.FileNumberLimit,
                FileSizeLimit = questionDTO.FileSizeLimit,
                CreatedOn = DateTime.UtcNow
            };

            await this.context.DocumentQuestions.AddAsync(question);
            await this.context.SaveChangesAsync();

            questionDTO.Id = question.Id;
            return questionDTO;
        }

        public async Task<bool> DeleteDocumentQuestionAsync(Guid questionId)
        {
            DocumentQuestion question = await this.context.DocumentQuestions
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

        public async Task<ICollection<DocumentQuestionDTO>> GetAllDocumentQuestionsAsync(Guid formId)
        {
            List<DocumentQuestion> questions = await this.context.DocumentQuestions
                .Where(q => q.FormId == formId && q.IsDeleted == false)
                .ToListAsync();

            return questions.GetDtos();
        }

        public async Task<DocumentQuestionDTO> GetDocumentQuestionAsync(Guid questionId)
        {
            DocumentQuestion question = await this.context.DocumentQuestions
                .FirstOrDefaultAsync(q => q.Id == questionId && q.IsDeleted == false);

            if(question == null)
            {
                throw new ArgumentNullException($"There is no such DocumentQuestion with ID: {questionId}");
            }

            return question.GetDto();
        }

        public async Task<DocumentQuestionDTO> UpdateDocumentQuestionAsync(Guid questionId, DocumentQuestionDTO questionDTO)
        {
            DocumentQuestion question = await this.context.DocumentQuestions
                .FirstOrDefaultAsync(q => q.Id == questionId && q.IsDeleted == false);

            if (question == null)
            {
                throw new ArgumentNullException($"There is no such DocumentQuestion with ID: {questionId}");
            }

            question.IsRequired = questionDTO.IsRequired;
            question.FileSizeLimit = questionDTO.FileSizeLimit;
            question.FileNumberLimit = questionDTO.FileNumberLimit;
            question.Text = questionDTO.Text;
            question.ModifiedOn = DateTime.UtcNow;

            await this.context.SaveChangesAsync();

            return questionDTO;
        }
    }
}
