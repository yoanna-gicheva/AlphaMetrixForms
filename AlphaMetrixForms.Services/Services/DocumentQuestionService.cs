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
    public class DocumentQuestionService : IDocumentQuestionService
    {
        private readonly FormsContext context;
        public DocumentQuestionService(FormsContext context)
        {
            this.context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<DocumentQuestionDTO> CreateDocumentQuestionAsync(DocumentQuestionDTO questionDTO, Guid formId)
        {
            var check = await context.DocumentQuestions.FirstOrDefaultAsync(q => q.Text == questionDTO.Text && q.IsDeleted == false);

            if (check != null)
            {
                throw new ArgumentException($"Document question with Text: {questionDTO.Text} already exists.");
            }

            var question = new DocumentQuestion()
            {
                FormId = formId,
                Text = questionDTO.Text,
                IsRequired = questionDTO.IsRequired,
                FileNumberLimit = questionDTO.FileNumberLimit,
                FileSizeLimit = questionDTO.FileSizeLimit,
            };

            await context.DocumentQuestions.AddAsync(question);
            await context.SaveChangesAsync();

            return questionDTO;
        }

        public async Task<bool> DeleteDocumentQuestionAsync(Guid questionId)
        {
            DocumentQuestion question = await context.DocumentQuestions.FirstOrDefaultAsync(f => f.Id == questionId && f.IsDeleted == false);

            if (question == null)
            {
                return false;
            }

            question.IsDeleted = true;
            await context.SaveChangesAsync();
            return true;
        }

        public async Task<ICollection<DocumentQuestionDTO>> GetAllDocumentQuestionsAsync(Guid formId)
        {
            Form form = await context.Forms.FirstOrDefaultAsync(f => f.Id == formId && f.IsDeleted == false);
            var questions = form.DocumentQuestions;

            return DocumentQuestionMapper.GetDtos(questions);
        }

        public async Task<DocumentQuestionDTO> GetDocumentQuestionAsync(Guid questionId)
        {
            DocumentQuestion question = await context.DocumentQuestions.FirstOrDefaultAsync(q => q.Id == questionId && q.IsDeleted == false);

            if(question == null)
            {
                throw new ArgumentNullException($"There is no such DocumentQuestion with ID: {questionId}");
            }

            return DocumentQuestionMapper.GetDto(question);
        }

        public async Task<DocumentQuestionDTO> UpdateDocumentQuestionAsync(Guid questionId, DocumentQuestionDTO questionDTO)
        {
            DocumentQuestion question = await context.DocumentQuestions.FirstOrDefaultAsync(q => q.Id == questionId && q.IsDeleted == false);

            if (question == null)
            {
                throw new ArgumentNullException($"There is no such DocumentQuestion with ID: {questionId}");
            }

            question = DocumentQuestionMapper.GetEntity(questionDTO);
            await context.SaveChangesAsync();

            return questionDTO;
        }
    }
}
