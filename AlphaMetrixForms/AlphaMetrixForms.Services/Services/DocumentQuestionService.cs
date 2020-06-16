using AlphaMetrixForms.Data.Context;
using AlphaMetrixForms.Data.Entities;
using AlphaMetrixForms.Services.Contracts;
using AlphaMetrixForms.Services.DTOmappers;
using AlphaMetrixForms.Services.DTOs;
using AlphaMetrixForms.Services.Providers;
using AlphaMetrixForms.Services.Providers.Contracts;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.Azure.Storage;
using Microsoft.Azure.Storage.Auth;
using Microsoft.Azure.Storage.Blob;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
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
            if (questionDTOs.Count == 0)
            {
                return false;
            }
            DocumentQuestionDTO current;
            foreach (var question in questionDTOs)
            {
                current = await CreateDocumentQuestionAsync(question, formId);
            }
            return true;
        }
        public async Task<DocumentQuestionDTO> CreateDocumentQuestionAsync(DocumentQuestionDTO questionDTO, Guid formId)
        {

            Form form = await this.context.Forms
               .FirstOrDefaultAsync(f => f.Id == formId && f.IsDeleted == false);

            if (form == null)
            {
                throw new ArgumentException($"Form with id {formId} does not exist.");
            }

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
                throw new ArgumentException($"There is no such DocumentQuestion with ID: {questionId}");
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
                    await UpdateDocumentQuestionAsync(question.Id, question);
                }
                else
                {
                    await CreateDocumentQuestionAsync(question, formId);
                }
            }
        }

        public async Task CreateDocumentQuestionAnswerAsync(Guid responseId, Guid questionId, IFormFileCollection files)
        {
            if (files.Count == 0)
            {
                return;
            }

            DocumentQuestion question = await context.DocumentQuestions
                .FirstOrDefaultAsync(q => q.Id == questionId);

            if (question == null)
            {
                throw new ArgumentException($"There is no such DocumentQuestion with ID: {questionId}");
            }

            Response response = await context.Responses
                .FirstOrDefaultAsync(q => q.Id == responseId);

            if (response == null)
            {
                throw new ArgumentException($"There is no such Response with ID: {responseId}");
            }

            foreach (var item in files)
            {
                IBlobProvider _blob = new BlobProvider();
                await _blob.UploadFileAsync(item, responseId, questionId);
                var documentAnswer = new DocumentQuestionAnswer
                {
                    ResponseId = responseId,
                    DocumentQuestionId = questionId,
                    Answer = $"{responseId}_{questionId}/{item.FileName}"
                };
                await context.DocumentQuestionAnswers.AddAsync(documentAnswer);
            }
            await context.SaveChangesAsync();
        }
    }
}
