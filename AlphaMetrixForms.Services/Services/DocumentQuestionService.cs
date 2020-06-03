using AlphaMetrixForms.Data.Context;
using AlphaMetrixForms.Data.Entities;
using AlphaMetrixForms.Services.Contracts;
using AlphaMetrixForms.Services.DTOmappers;
using AlphaMetrixForms.Services.DTOs;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.Azure.Storage;
using Microsoft.Azure.Storage.Auth;
using Microsoft.Azure.Storage.Blob;
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

        public async Task CreateDocumentQuestionAnswerAsync(Guid responseId, Guid questionId, IFormFileCollection files)
        {
            if (files == null)
            {
                return;
            }
            foreach (var item in files)
            {
                await this.UploadFileAsync(item, responseId, questionId);
                var documentAnswer = new DocumentQuestionAnswer
                {
                    ResponseId = responseId,
                    DocumentQuestionId = questionId,
                    Answer = item.FileName
                };
                await context.DocumentQuestionAnswers.AddAsync(documentAnswer);
            }
            await this.context.SaveChangesAsync();
        }

        public async Task UploadFileAsync(IFormFile file, Guid responseId, Guid questionId)
        {
            const string accountName = "alphametrix";
            const string key = "3hCy/2bFCJFXUrqs8JT9v9yWtemzAqPUod2rhHU94Uxn3Zah2LO3MWPb1H0y/E2fZ4GfmXEYci4GNfeRKmcTQQ==";
            var storageAccount = new CloudStorageAccount(new StorageCredentials(accountName, key), true);
            var blobClient = storageAccount.CreateCloudBlobClient();
            var container = blobClient.GetContainerReference("alphametrixforms");
            await container.CreateIfNotExistsAsync();
            await container.SetPermissionsAsync(new BlobContainerPermissions()
            {
                PublicAccess = BlobContainerPublicAccessType.Blob
            });

            CloudBlobDirectory folder = container.GetDirectoryReference($"Response_{responseId}_{questionId}");

            var blockblob = folder.GetBlockBlobReference(file.FileName);

            using (var stream = file.OpenReadStream())
            {
                await blockblob.UploadFromStreamAsync(stream);
            }
        }
    }
}
