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
            if (files.Count==0)
            {
                return;
            }

            DocumentQuestion question = await this.context.DocumentQuestions
                .FirstOrDefaultAsync(q => q.Id == questionId);

            if (question == null)
            {
                throw new ArgumentException($"There is no such DocumentQuestion with ID: {questionId}");
            }

            Response response = await this.context.Responses
                .FirstOrDefaultAsync(q => q.Id == responseId);

            if (response == null)
            {
                throw new ArgumentException($"There is no such Response with ID: {responseId}");
            }

            foreach (var item in files)
            {
                await this.UploadFileAsync(item, responseId, questionId);
                var documentAnswer = new DocumentQuestionAnswer
                {
                    ResponseId = responseId,
                    DocumentQuestionId = questionId,
                    Answer = $"{responseId}_{questionId}/{item.FileName}"
                };
                await context.DocumentQuestionAnswers.AddAsync(documentAnswer);
            }
            await this.context.SaveChangesAsync();
        }

        public async Task UploadFileAsync(IFormFile file, Guid responseId, Guid questionId)
        {
            const string accountName = "alphametrix";
            const string key = "3hCy/2bFCJFXUrqs8JT9v9yWtemzAqPUod2rhHU94Uxn3Zah2LO3MWPb1H0y/E2fZ4GfmXEYci4GNfeRKmcTQQ==";

            CloudStorageAccount storageAccount = new CloudStorageAccount(new StorageCredentials(accountName, key), true);
            CloudBlobClient blobClient = storageAccount.CreateCloudBlobClient();
            CloudBlobContainer container = blobClient.GetContainerReference("alphametrixforms");

            await container.CreateIfNotExistsAsync();
            await container.SetPermissionsAsync(new BlobContainerPermissions()
            {
                PublicAccess = BlobContainerPublicAccessType.Blob
            });

            CloudBlobDirectory folder = container.GetDirectoryReference($"Response_{responseId}_{questionId}");

            CloudBlockBlob blockblob = folder.GetBlockBlobReference(file.FileName);

            using (var stream = file.OpenReadStream())
            {
                await blockblob.UploadFromStreamAsync(stream);
            }
        }

        public async Task<MemoryStream> DownloadFileAsync(string name)
        {
            const string accountName = "alphametrix";
            const string key = "3hCy/2bFCJFXUrqs8JT9v9yWtemzAqPUod2rhHU94Uxn3Zah2LO3MWPb1H0y/E2fZ4GfmXEYci4GNfeRKmcTQQ==";

            CloudStorageAccount storageAccount = new CloudStorageAccount(new StorageCredentials(accountName, key), true);
            CloudBlobClient blobClient = storageAccount.CreateCloudBlobClient();

            string folderRef = name.Split('/')[0];
            string folderName = "Response_"+folderRef;
            CloudBlobContainer container = blobClient.GetContainerReference($"alphametrixforms/{folderName}");

            string fileName = name.Substring(folderRef.Length+1);
            CloudBlockBlob blob = container.GetBlockBlobReference(fileName);

            var memory = new MemoryStream();
            await blob.DownloadToStreamAsync(memory);

            memory.Position = 0;
            return memory;
        }
    }
}
