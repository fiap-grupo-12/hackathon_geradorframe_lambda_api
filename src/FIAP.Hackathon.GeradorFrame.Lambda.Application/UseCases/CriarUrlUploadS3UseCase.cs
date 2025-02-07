using FIAP.Hackathon.GeradorFrame.Lambda.Application.Services;
using FIAP.Hackathon.GeradorFrame.Lambda.Application.UseCases.Interfaces;

namespace FIAP.Hackathon.GeradorFrame.Lambda.Application.UseCases
{
    public class CriarUrlUploadS3UseCase(
        IS3Service s3Repository
        ) : ICriarUrlUploadS3UseCase
    {
        private readonly IS3Service _s3Repository = s3Repository;


        public async Task<string> Execute(Guid request)
        {
            return await _s3Repository.CreateUrlToUpload(request);
        }
    }
}
