using Amazon.S3;
using FIAP.Hackathon.GeradorFrame.Lambda.Application.Services;
using FIAP.Hackathon.GeradorFrame.Lambda.Application.UseCases.Interfaces;
using FIAP.Hackathon.GeradorFrame.Lambda.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FIAP.Hackathon.GeradorFrame.Lambda.Application.UseCases
{
    public class CriarUrlDownloadS3UseCase(
        IS3Service s3Repository
        ) : ICriarUrlDownloadS3UseCase
    {
        private readonly IS3Service _s3Repository = s3Repository;


        public async Task<string> Execute(Guid request)
        {
            return await _s3Repository.CreateUrlToDownload(request);
        }
    }
}
