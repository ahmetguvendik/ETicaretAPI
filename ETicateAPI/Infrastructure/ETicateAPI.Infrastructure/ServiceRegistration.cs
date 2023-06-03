using System;
using ETicaretAPI.Application.Repositories;
using ETicaretAPI.Application.Services;
using ETicateAPI.Domain.Entities.Identity;
using ETicateAPI.Infrastructure.Services;
using Microsoft.Extensions.DependencyInjection;

namespace ETicateAPI.Infrastructure
{
	
        public static class ServiceRegistration
        {
            public static void AddInfrastructureService(this IServiceCollection services)
            {
            services.AddScoped<ITokenHandler, TokenHandler>();
            services.AddScoped<IUserService, UserService>();
               
            }
        }
    }


