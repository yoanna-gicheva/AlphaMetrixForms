using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AlphaMetrixForms.Data.Entities.Contracts;
using AlphaMetrixForms.Data.Entities.Parent;
using Microsoft.AspNetCore.Identity;

namespace AlphaMetrixForms.Data.Entities
{
    // Add profile data for application users by adding properties to the User class
    public class User : IdentityUser<Guid>, IAuditable, IDeletable
    {
        public User()
        {
            this.Forms = new List<Form>();
        }

        public DateTime CreatedOn { get ; set ; }
        public DateTime? ModifiedOn { get ; set ; }
        public bool IsDeleted { get ; set ; }
        public DateTime? DeletedOn { get ; set ; }

        public ICollection<Form> Forms { get; set; }
    }
}
