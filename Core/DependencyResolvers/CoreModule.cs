using Core.CrossCuttingConcerns.Caching.Abstract;
using Core.CrossCuttingConcerns.Caching.ConCreate;
using Core.Utilities.Ioc;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace Core.DependencyResolvers
{
    public class CoreModule : ICoreModule
    {
        public void load(IServiceCollection services)
        {
            services.AddMemoryCache();
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddSingleton<ICacheManager,MemoryCacheManager>();
            services.AddSingleton<Stopwatch>();
        }
    }
}
