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
                FormId = formId,
                CreatedOn = DateTime.UtcNow
            };

            await this.context.Responses.AddAsync(response);
            await this.context.SaveChangesAsync();

            return response.Id;
        }

        public async Task<FormDTO> RetrieveResponseForFormAsync(Guid formId)
        {
            Form form = await this.context.Forms
                .Include(f => f.Owner)
                .Include(f => f.Responses).ThenInclude(r=>r.TextQuestionAnswers)
                .Include(f => f.Responses).ThenInclude(r=>r.OptionQuestionAnswers)
                .Include(f => f.Responses).ThenInclude(r=>r.DocumentQuestionAnswers)
                .FirstOrDefaultAsync(f => f.Id == formId);

            return form.GetDto();
        }
        public async Task<ResponseDTO> RetrieveResponseAsync(Guid responseId, Guid formId)
        {

            Response response = await context.Responses
                .Include(f => f.TextQuestionAnswers)
                .Include(f => f.OptionQuestionAnswers).ThenInclude(o => o.OptionQuestion)
                .Include(f => f.DocumentQuestionAnswers)
                .FirstOrDefaultAsync(f => f.Id == responseId);
            Form form = await this.context.Forms
                .Include(f => f.Owner)
                .Include(f => f.TextQuestions)
                .Include(f => f.OptionQuestions).ThenInclude(o=>o.Options)
                .Include(f => f.DocumentQuestions)
                .FirstOrDefaultAsync(f => f.Id == formId && f.IsDeleted == false);

            ResponseDTO dto = response.GetDto();
            dto.Title = form.Title;
            dto.Description = form.Description;

           
            foreach (var answer in dto.TextQuestionAnswers)
            {
                var result = context.TextQuestions.FirstOrDefaultAsync(t => t.Id == answer.TextQuestionId).Result;
                answer.Text = result.Text;
                answer.OrderNumber = result.OrderNumber;
            }
            foreach (var answer in dto.OptionQuestionAnswers)
            {
                var result = context.OptionQuestions.Include(o=>o.Answers).FirstOrDefaultAsync(t => t.Id == answer.OptionQuestionId).Result;
                answer.Text = result.Text;
                answer.OrderNumber = result.OrderNumber;
                foreach(var text in result.Answers.Where(a=>a.ResponseId == response.Id))
                {
                    answer.Answers.Add(text.Answer);
                }
            }
            foreach (var answer in dto.DocumentQuestionAnswers)
            {
                var result = context.DocumentQuestions.FirstOrDefaultAsync(t => t.Id == answer.DocumentQuestionId).Result;
                answer.Text = result.Text;
                answer.OrderNumber = result.OrderNumber;
            }


            //this.context.Entry(form)
            //    .Collection(f => f.Responses)
            //    .Query()
            //    .Where(r => r.Id == responseId)
            //    .Include(r => r.TextQuestionAnswers)
            //    .Include(r => r.DocumentQuestionAnswers)
            //    .Include(r => r.OptionQuestionAnswers)
            //    .Load();

            return dto;
        }

    }
}
