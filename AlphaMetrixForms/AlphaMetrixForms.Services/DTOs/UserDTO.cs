using System;
using System.Collections.Generic;
using System.Text;

namespace AlphaMetrixForms.Services.DTOs
{
    public class UserDTO
    {
        public Guid Id { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public ICollection<FormDTO> Forms { get; set; }
        public DateTime CreatedOn { get; set; }

    }
}
