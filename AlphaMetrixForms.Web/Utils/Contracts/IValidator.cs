using AlphaMetrixForms.Web.Models.Form;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AlphaMetrixForms.Web.Utils.Contracts
{
    public interface IValidator
    {
        string ModifyModelValidation_Message(FormViewModel form);
    }
}
