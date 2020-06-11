using System;
using System.Collections.Generic;
using System.Text;

namespace AlphaMetrixForms.Data.Entities.Contracts
{
    public interface IDeletable
    {
        bool IsDeleted { get; set; }
        DateTime? DeletedOn { get; set; }
    }
}
