using ConsoleViewPresent;
using FootMatcher.BusinessServices.BusinessServices;
using FootMatcher.BusinessServices.Interfaces.Interfaces;
using FootMatcher.ConsoleApp.Views.SessionDetails;
using FootMatcher.ConsoleApp.Views.StartMenu;
using FootMatcher.FileSystemRepositories.Options;
using FootMatcher.FileSystemRepositories.Repositories;
using FootMatcher.Presentation.Presenters;
using FootMatcher.Presentation.ViewInterfaces;
using FootMatcher.Presentation.ViewModels;
using FootMatcher.Presentation.ViewSwitch;
using FootMatcher.Presentation.ViewSwitch.PresenterCreators;
using FootMatcher.Repositories.Interfaces.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;

namespace FootMatcher
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
                        .AddSingleton<ConsoleViewRenderer>()

                        .AddScoped<ViewSwitcher>()
                        .AddScoped<StartMenuPresenterCreator>()
                        .AddScoped<SessionDetailsPresenterCreator>()

                        .AddScoped<IStartMenuView, StartMenuView>()
                        .AddScoped<ISessionDetailsView, SessionDetailsView>()

                        .AddScoped<StartMenuViewModel>()
                        .AddScoped<SessionDetailsViewModel>()

                        .AddScoped<StartMenuPresenter>()
                        .AddScoped<SessionDetailsPresenter>()

                        .AddScoped<IMatchBusinessService, MatchBusinessService>()
                        .AddScoped<ISessionBusinessService, SessionBusinessService>()
                        .AddScoped<ITeamBusinessService, TeamBusinessService>()

                        .AddScoped<ITeamRepository, TeamRepository>()

                        .AddScoped<Executer>();
                })
                .Build();

            var serviceProvider = host.Services;

            var executer = serviceProvider.GetService<Executer>();
            if (executer == null)
            {
                throw new NullReferenceException("executer not found");
            }

            Console.OutputEncoding = System.Text.Encoding.UTF8;

            executer.Execute();
        }
    }
}