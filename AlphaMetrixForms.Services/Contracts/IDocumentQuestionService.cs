using AlphaMetrixForms.Services.DTOs;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AlphaMetrixForms.Services.Contracts
{
    public interface IDocumentQuestionService
    {
        Task<DocumentQuestionDTO> GetDocumentQuestionAsync(Guid questionId);
        Task<DocumentQuestionDTO> UpdateDocumentQuestionAsync(Guid questionId, DocumentQuestionDTO questionDTO);
        Task<DocumentQuestionDTO> CreateDocumentQuestionAsync(DocumentQuestionDTO questionDTO, Guid formId);
        Task<bool> CreateDocumentQuestionAsync(ICollection<DocumentQuestionDTO> questionDTOs, Guid formId);
        Task<ICollection<DocumentQuestionDTO>> GetAllDocumentQuestionsAsync(Guid formId);
        Task<bool> DeleteDocumentQuestionAsync(Guid questionId);
    }
}
