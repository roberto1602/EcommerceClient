using Business;
using Business.DownloadFile.Implementation;
using Business.DownloadFile.Interface;
using Business.RegisterUser.Implementation;
using Business.RegisterUser.Interface;
using Business.UploadFile.Implementation;
using Business.UploadFile.Interface;
using Data;
using Data.DownLoadFile.Implementation;
using Data.DownLoadFile.Interface;
using Data.LoginUser.Implementation;
using Data.LoginUser.Interface;
using Data.UploadFileData.Implementation;
using Data.UploadFileData.Interface;
using Entities.configuration;
using Microsoft.EntityFrameworkCore;

namespace EcommerceClient
{
    public static class DependencyInyection
    {
        public static IServiceCollection AddDependenciesService(this IServiceCollection services, IConfiguration config)
        {
            services.AddServicesBusiness(config);
            services.AddServicesData();
            services.AddDataDependenciesService();

            return services;
        }


        private static IServiceCollection AddServicesBusiness(this IServiceCollection services, IConfiguration config) 
        {
            services.AddTransient<IBusinessLoginUser, BusinessLoginUser>();
            services.AddTransient<IBusinessFileDownLoad, BusinessFileDownLoad>();

            services.AddTransient<IUploadFile, UploadFile>();
            services.Configure<ServerRouteSettings>(config.GetSection($"ServerRoute:Route"));

            services.Configure<JwtSettings>(config.GetSection($"Jwt"));

            return services;
        }

        private static IServiceCollection AddServicesData(this IServiceCollection services) 
        {
            services.AddTransient<IDataLoginUser, DataLoginUser>();
            services.AddTransient<IDataFileDownLoad, DataFileDownLoad>();
            services.AddTransient<IUploadFileData, UploadFileData>();

            return services;
        }

        private static IServiceCollection AddDataDependenciesService(this IServiceCollection services)
        {
            services.AddDbContext<ContexMain>(options =>
            {
                options.UseSqlServer(Environment.GetEnvironmentVariable("DataSource") ?? "");
            });
            return services;
        }
    }
}
