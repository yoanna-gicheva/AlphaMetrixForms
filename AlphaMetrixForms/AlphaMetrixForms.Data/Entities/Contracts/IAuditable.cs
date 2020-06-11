using System;
using System.Collections.Generic;
using System.Text;

namespace AlphaMetrixForms.Data.Entities.Contracts
{
    public interface IAuditable
    {
        DateTime CreatedOn { get; set; }
        DateTime? ModifiedOn { get; set; }
    }
}
