using System;
using ETicaretAPI.Application.Repositories;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace ETicaretAPI.Application
{
	public static class ServiceRegistration
	{
        public static void AddMediatorService(this IServiceCollection services)
        {
            services.AddMediatR(cfg =>
            {
                cfg.RegisterServicesFromAssemblies(typeof(ServiceRegistration).Assembly);
            });
        }
    }
}

