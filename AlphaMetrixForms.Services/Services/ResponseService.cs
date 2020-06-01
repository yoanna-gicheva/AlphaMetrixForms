using AlphaMetrixForms.Data.Context;
using AlphaMetrixForms.Data.Entities;
using AlphaMetrixForms.Services.Contracts;
using AlphaMetrixForms.Services.DTOmappers;
using AlphaMetrixForms.Services.DTOs;
using AlphaMetrixForms.Services.Providers;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace AlphaMetrixForms.Services.Services
{
    public class ResponseService : IResponseService
    {
        private readonly FormsContext context;
        private readonly ITextQuestionService textQuestionService;
        private readonly IOptionQuestionService optionQuestionService;
        private readonly IDocumentQuestionService documentQuestionService;

        public ResponseService(FormsContext context, ITextQuestionService textQuestionService, IOptionQuestionService optionQuestionService, IDocumentQuestionService documentQuestionService)
        {
            this.context = context ?? throw new ArgumentNullException(nameof(context));
            this.textQuestionService = textQuestionService ?? throw new ArgumentNullException(nameof(textQuestionService));
            this.optionQuestionService = optionQuestionService ?? throw new ArgumentNullException(nameof(optionQuestionService));
            this.documentQuestionService = documentQuestionService ?? throw new ArgumentNullException(nameof(documentQuestionService));
        }

        public async Task<Guid> CreateResponseAsync(Guid formId)
        {
            Form form = await this.context.Forms
               .FirstOrDefaultAsync(f => f.Id == formId && f.IsClosed == false);

            if (form == null)
            {
                throw new ArgumentException($"Form with id {formId} does not exist.");
            }

            Response response = new Response()
            {
                FormId = formId
            };

            await this.context.Responses.AddAsync(response);
            await this.context.SaveChangesAsync();

            return response.Id;
        }

    }
}
