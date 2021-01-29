using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using OrionBlog.Services;
using OrionBlog.Models;
using Microsoft.Extensions.DependencyInjection; // NEED TO READ 
using Microsoft.AspNetCore.Identity;// NEED TO READ
using OrionBlog.Areas;

namespace OrionBlog
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var host = CreateHostBuilder(args).Build();
            await DataService.ManageDataAsync(host);
            host.Run();
        }
      
        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
