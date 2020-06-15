using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace AlphaMetrixForms.Services.Providers.Contracts
{
    public interface IBlobProvider
    {
        Task<MemoryStream> DownloadFileAsync(string name);
        Task UploadFileAsync(IFormFile file, Guid responseId, Guid questionId);
        Dictionary<string, string> TypeDict_Setter();
    }
}
