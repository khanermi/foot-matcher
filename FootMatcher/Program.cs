using Microsoft.Extensions.DependencyInjection;

namespace FootMatcher
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var serviceCollection = ConfigureServiceCollection();
            var serviceProvider = serviceCollection.BuildServiceProvider();

            var executer = serviceProvider.GetService<JustExecuter>();
            if (executer == null)
            {
                throw new NullReferenceException("executer not found");
            }

            executer.Execute();
        }

        static IServiceCollection ConfigureServiceCollection()
        {
            var serviceCollection = new ServiceCollection();

            serviceCollection
                .AddScoped<IConsoleLogger, ConsoleLogger>()
                .AddScoped<JustExecuter>();

            return serviceCollection;
        }
    }
}