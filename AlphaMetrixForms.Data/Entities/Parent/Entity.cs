using AlphaMetrixForms.Data.Entities.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace AlphaMetrixForms.Data.Entities.Parent
{
    public class Entity : IAuditable, IDeletable
    {
        public DateTime CreatedOn { get ; set ; }
        public DateTime? ModifiedOn { get ; set ; }
        public bool IsDeleted { get ; set ; }
        public DateTime? DeletedOn { get ; set ; }
    }
}
