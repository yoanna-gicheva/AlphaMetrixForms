using AlphaMetrixForms.Services.DTOs;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AlphaMetrixForms.Services.Contracts
{
    public interface IDocumentQuestionService
    {
        Task<DocumentQuestionDTO> UpdateDocumentQuestionAsync(Guid questionId, DocumentQuestionDTO questionDTO);
        Task<DocumentQuestionDTO> CreateDocumentQuestionAsync(DocumentQuestionDTO questionDTO, Guid formId);
        Task<bool> CreateDocumentQuestionAsync(ICollection<DocumentQuestionDTO> questionDTOs, Guid formId);

        Task DocumentQuestion_DetectChanges(Guid formId, ICollection<DocumentQuestionDTO> questions);

        Task CreateDocumentQuestionAnswerAsync(Guid responseId, Guid questionId, IFormFileCollection files);


    }
}
