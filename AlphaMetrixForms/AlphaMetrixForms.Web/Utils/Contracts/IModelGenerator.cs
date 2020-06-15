using AlphaMetrixForms.Services.DTOs;
using AlphaMetrixForms.Web.Models.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AlphaMetrixForms.Web.Utils.Contracts
{
    public interface IModelGenerator
    {
        void Response_TextRelationship(FormDTO formDTO, ResponseDisplayModel vm);
        void Response_OptionRelationship(FormDTO formDTO, ResponseDisplayModel vm);
        void Response_DocumentRelationship(FormDTO formDTO, ResponseDisplayModel vm);
    }
}
