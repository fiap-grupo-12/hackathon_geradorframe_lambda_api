using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FIAP.Hackathon.GeradorFrame.Lambda.Application.UseCases.Interfaces
{
    public interface ICriarUrlDownloadS3UseCase : IUseCaseAsync<Guid, string>
    {
    }
}
