using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Hosting;
using System.Linq;
using System.Reflection;

namespace NoteService
{
    public class Program
    {
        public static void Main(string[] args)
        {

            var allTypes = Assembly.GetExecutingAssembly().GetTypes().Where(t => typeof(ControllerBase).IsAssignableFrom(t));


            CreateHostBuilder(args).Build().Run();



        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
