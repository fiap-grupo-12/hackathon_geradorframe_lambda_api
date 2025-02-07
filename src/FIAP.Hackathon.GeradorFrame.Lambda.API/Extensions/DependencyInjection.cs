using Amazon.DynamoDBv2.DataModel;
using Amazon.DynamoDBv2;
using AutoMapper;
using FIAP.Hackathon.GeradorFrame.Lambda.Infra.Data.Configurations;
using FIAP.Hackathon.GeradorFrame.Lambda.Domain.Repositories;
using FIAP.Hackathon.GeradorFrame.Lambda.Infra.Data.Repositories;
using FIAP.Hackathon.GeradorFrame.Lambda.Application.UseCases.Interfaces;
using FIAP.Hackathon.GeradorFrame.Lambda.Application.UseCases;
using Amazon.S3;
using FIAP.Hackathon.GeradorFrame.Lambda.Infra.Services;
using FIAP.Hackathon.GeradorFrame.Lambda.Application.Services;

namespace FIAP.Hackathon.GeradorFrame.Lambda.API.Extensions
{
    public static class DependencyInjection
    {
        public static void AddProjectDependencies(this IServiceCollection services)
        {
            //AWS
            services.AddAWSService<IAmazonDynamoDB>();
            services.AddAWSService<IAmazonS3>();
            services.AddTransient<IDynamoDBContext, DynamoDBContext>();

            //AutoMapper
            var mapperConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new MapperConfig());
            });

            IMapper mapper = mapperConfig.CreateMapper();
            services.AddSingleton(mapper);

            //Repository
            services.AddTransient<ISolicitacaoRepository, SolicitacaoRepository>();

            services.AddTransient<IS3Service, S3Service>();

            //UseCase
            services.AddTransient<ICriarSolicitacaoUseCase, CriarSolicitacaoUseCase>();
            services.AddTransient<IObterSolicitacaoPorIdUseCase, ObterSolicitacaoPorIdUseCase>();
            services.AddTransient<IObterSolicitacaoUseCase, ObterSolicitacaoUseCase>();
            services.AddTransient<ICriarUrlUploadS3UseCase, CriarUrlUploadS3UseCase>();
            services.AddTransient<ICriarUrlDownloadS3UseCase, CriarUrlDownloadS3UseCase>();
        }
    }
}
