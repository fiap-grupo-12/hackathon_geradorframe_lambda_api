using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FIAP.Hackathon.GeradorFrame.Lambda.Domain.Entities
{
    public class S3Settings
    {
        public S3UploadSettings Upload { get; set; }
        public S3DownloadSettings Download { get; set; }
    }

    public class S3UploadSettings
    {
        public string Bucket { get; set; }
        public string FileName { get; set; }
    }

    public class S3DownloadSettings
    {
        public string Bucket { get; set; }
        public string FileName { get; set; }
    }
}
