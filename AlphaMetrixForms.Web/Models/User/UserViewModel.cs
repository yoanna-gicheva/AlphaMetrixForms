using AlphaMetrixForms.Web.Models.Form;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AlphaMetrixForms.Web.Models.User
{
    public class UserViewModel
    {
        public UserViewModel()
        {
            this.Forms = new List<FormViewModel>();
        }
        public string UserName { get; set; }
        public string Email { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime? ModifiedOn { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime? DeletedOn { get; set; }
        public ICollection<FormViewModel> Forms { get; set; }
    }
}
