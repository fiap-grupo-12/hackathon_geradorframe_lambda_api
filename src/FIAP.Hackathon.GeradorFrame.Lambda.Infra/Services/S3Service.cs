using Amazon.S3;
using Amazon.S3.Model;
using FIAP.Hackathon.GeradorFrame.Lambda.Application.Services;
using FIAP.Hackathon.GeradorFrame.Lambda.Domain.Entities;
using Microsoft.Extensions.Options;

namespace FIAP.Hackathon.GeradorFrame.Lambda.Infra.Services
{
    public class S3Service : IS3Service
    {
        private readonly S3Settings _s3Settings;
        private readonly IAmazonS3 _s3Client;
        public S3Service(
            IAmazonS3 s3Client,
            IOptions<S3Settings> s3Settings)
        {
            _s3Settings = s3Settings.Value;
            _s3Client = s3Client;
        }

        public async Task<string> CreateUrlToUpload(Guid id)
        {
            var request = new GetPreSignedUrlRequest
            {
                BucketName = _s3Settings.Upload.Bucket,
                Key = $"{id.ToString()}/{_s3Settings.Upload.FileName}",
                Verb = HttpVerb.PUT,
                Expires = DateTime.UtcNow.AddHours(12),
            };

            return await _s3Client.GetPreSignedURLAsync(request);
        }

        public async Task<string> CreateUrlToDownload(Guid id)
        {
            var request = new GetPreSignedUrlRequest
            {
                BucketName = _s3Settings.Download.Bucket,
                Key = $"{id.ToString()}/{_s3Settings.Download.FileName}",
                Verb = HttpVerb.GET,
                Expires = DateTime.UtcNow.AddHours(12),
            };

            return await _s3Client.GetPreSignedURLAsync(request);
        }
    }
}
