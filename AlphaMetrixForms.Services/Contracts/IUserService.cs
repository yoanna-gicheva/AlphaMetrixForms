using AlphaMetrixForms.Services.DTOs;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AlphaMetrixForms.Services.Contracts
{
    public interface IUserService
    {

        Task<UserDTO> UserDetails(Guid id, IMapper mapper);
        Task<IEnumerable<FormDTO>> MyForms(Guid id, IMapper mapper);
    }
}
