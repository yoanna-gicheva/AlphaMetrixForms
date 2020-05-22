using AlphaMetrixForms.Services.DTOs;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;

namespace AlphaMetrixForms.Services.Contracts
{
    public interface IUserService
    {
         UserDTO UserDetails(Guid id, IMapper mapper); 
    }
}
