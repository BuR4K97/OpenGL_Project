using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenGL_Project.Graphics;
using Microsoft.Extensions.DependencyInjection;

namespace OpenGL_Project.Configurations
{
    public static class AppConfig 
    {

        private static readonly IServiceProvider services = ConfigureServices();

        private static IServiceProvider ConfigureServices()
        {
            IServiceCollection services = new ServiceCollection();

            services.AddSingleton<SystemConfig>();
            services.AddSingleton<GLConfig>();

            return services.BuildServiceProvider(); ;
        }


        public static void Initialize()
        {
            services.GetService<SystemConfig>().Initialize();
        }

        public static Type GetService<Type>()
        {
            return services.GetService<Type>();
        }

    }
}
