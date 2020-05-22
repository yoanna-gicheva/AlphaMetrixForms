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

namespace AlphaMetrixForms.Services.Services
{
    public class UserService : IUserService
    {
        private readonly FormsContext context;
        public UserService(FormsContext context)
        {
            this.context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public UserDTO UserDetails(Guid id, IMapper mapper)
        {
            User user = context.Users./*Include(u=>u.Forms).*/FirstOrDefault(u => u.Id == id);
            if(user == null)
            {
                throw new ArgumentException();
            }

            return mapper.Map<UserDTO>(user);
        }
    }
}
