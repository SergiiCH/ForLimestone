using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;


namespace ForLimestone
{
    public class Program
    {
        public static void Main(string[] args)
        {
            BuildWebHost(args).Run();
        }

        public static IWebHost BuildWebHost(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>()
                .UseDefaultServiceProvider(option =>
                 option.ValidateScopes = false)
                .Build();
    }
}
