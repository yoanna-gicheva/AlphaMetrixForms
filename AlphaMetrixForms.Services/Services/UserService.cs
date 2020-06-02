using AlphaMetrixForms.Data.Context;
using AlphaMetrixForms.Data.Entities;
using AlphaMetrixForms.Services.Contracts;
using AlphaMetrixForms.Services.DTOs;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
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
    }
}
