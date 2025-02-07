using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FIAP.Hackathon.GeradorFrame.Lambda.Application.Services
{
    public interface IS3Service
    {
        Task<string> CreateUrlToUpload(Guid id);
        Task<string> CreateUrlToDownload(Guid id);
    }
}
