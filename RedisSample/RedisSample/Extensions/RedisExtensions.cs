using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using RedisSample.Configuration;
using RedisSample.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RedisSample.Extensions
{
    public static class RedisExtensions
    {
        public static IServiceCollection AddRedisCache(this IServiceCollection services, IConfiguration configuration)
        {
            var redisCacheSettings = new RedisCacheSettings();

            configuration.GetSection(nameof(RedisCacheSettings)).Bind(redisCacheSettings);
            services.AddSingleton(redisCacheSettings);

            if (!redisCacheSettings.Enabled)
            {
                return services;
            }

            services.AddStackExchangeRedisCache(options =>
            {
                options.Configuration = redisCacheSettings.ConnectionString;
            });

            services.AddSingleton<IResponseCacheService, ResponseCacheService>();

            return services;
        }
    }
}
