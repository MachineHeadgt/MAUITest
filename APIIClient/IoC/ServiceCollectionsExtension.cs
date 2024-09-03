using APIIClient.Models;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace APIIClient.IoC
{
    public static class ServiceCollectionsExtension
    {
        public static void AddApiClientService(this IServiceCollection services, Action<APIClientOptions> options)
        {
            services.Configure(options);
            services.AddSingleton(provider =>
                {
                    var options = provider.GetRequiredService<IOptions<APIClientOptions>>().Value;
                    return new APIClientService(options);
                }
            );
        }
    }
}
