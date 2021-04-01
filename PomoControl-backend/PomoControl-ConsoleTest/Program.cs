using EscNet.Cryptography.Interfaces;
using EscNet.DependencyInjection.IoC.Cryptography;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace PomoControl_ConsoleTest
{
    public class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(DateTime.Now);
            Console.WriteLine("Welcome! Starting this application... ");
            Console.WriteLine("Initializing dependency injections...");

            var serviceCollection = new ServiceCollection();
            ConfigureServices(serviceCollection);
            var serviceProvider = serviceCollection.BuildServiceProvider();
            var eventService = serviceProvider.GetService<IRijndaelCryptography>();

            Console.WriteLine("Dependency injection finished.");
            Console.WriteLine("");

            Console.Write("Encrypting... ");
            var encrypted = eventService.Encrypt("@Abc123!");
            Console.WriteLine(encrypted);

            Console.Write("Decrypting... ");
            var decrypted = eventService.Decrypt(encrypted);
            Console.WriteLine(decrypted);

            Console.WriteLine();
            Console.WriteLine("The execution is finished.");
        }
        public static void ConfigureServices(IServiceCollection services)
        {
            services.AddRijndaelCryptography("x5qWaAZU3jqSY6WV");
        }
    }
}
