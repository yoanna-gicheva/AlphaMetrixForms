using AlphaMetrixForms.Data.Context;
using AlphaMetrixForms.Data.Entities;
using AlphaMetrixForms.Services.Contracts;
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
    public class UserService : IUserService
    {
        private readonly FormsContext context;
        public UserService(FormsContext context)
        {
            this.context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<UserDTO> UserDetails(Guid id, IMapper mapper)
        {
            User user = await context.Users.FirstOrDefaultAsync(u => u.Id == id);
            if(user == null)
            {
                throw new ArgumentException();
            }

            return mapper.Map<UserDTO>(user);
        }
        public async Task<IEnumerable<FormDTO>> MyForms(Guid id, IMapper mapper)
        {
            ICollection<Form> forms = await context.Forms
                .Include(f=>f.Responses)
                .Where(f => f.OwnerId == id && f.IsDeleted == false).ToListAsync();
            return mapper.Map<IEnumerable<FormDTO>>(forms);
        }

        public async Task<bool> ShareFeedbackAsync(string sender, string subject, string content, string callBackInfo)
        {
            Email email = new Email();
            email.To = "alphametrixforms@gmail.com";

            email.Subject = "You received a new message!";
            email.Greeting = $"Dear AlphaMetrix,\r\nYou received new feedback with the following details:\r\n";
            email.Content = $"Sender: {sender}\r\nSubject: {subject}\r\nContent: {content}\r\nContact me at:{callBackInfo}\r\n";

            MailMessage message = new MailMessage();
            message.To.Add(email.To);
            message.Subject = email.Subject;
            message.Body = email.Greeting + email.Content;
            message.From = new MailAddress("alphametrixforms@gmail.com");
            message.IsBodyHtml = false;
            SmtpClient smtp = new SmtpClient("smtp.gmail.com");
            smtp.Port = 587;
            smtp.UseDefaultCredentials = true;
            smtp.EnableSsl = true;
            smtp.Credentials = new System.Net.NetworkCredential("alphametrixforms@gmail.com", "yoanna13");
            smtp.Send(message);

            return true;
        }
    }
}
