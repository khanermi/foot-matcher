using FootMatcher.BusinessServices.BusinessServices;
using FootMatcher.BusinessServices.Interfaces.Interfaces;
using FootMatcher.FileSystemRepositories.Options;
using FootMatcher.FileSystemRepositories.Repositories;
using FootMatcher.Repositories.Interfaces.Interfaces;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;

namespace FootMatcher.FileSystemDbPopulator
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var host = Host.CreateDefaultBuilder(args)
                .ConfigureServices((context, services) =>
                {
                    var configurationRoot = context.Configuration;
                    services.Configure<FileSystemRepositoryOptions>(
                        configurationRoot.GetSection(nameof(FileSystemRepositoryOptions)));

                    services
                        .AddScoped<ITeamRepository, TeamRepository>()

                        .AddScoped<ITeamBusinessService, TeamBusinessService>()

                        .AddScoped<Executer>();
                })
                .Build();

            var serviceProvider = host.Services;
            var executer = serviceProvider.GetService<Executer>();
            if (executer == null)
            {
                throw new NullReferenceException("executer not found");
            }

            executer.Execute();
        }
    }
}