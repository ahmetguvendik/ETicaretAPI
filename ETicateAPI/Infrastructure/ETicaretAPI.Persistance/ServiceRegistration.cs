using System;
using ETicaretAPI.Application.Repositories;
using ETicaretAPI.Persistance.Contexts;
using ETicaretAPI.Persistance.Repositories;
using ETicateAPI.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace ETicaretAPI.Persistance
{
	public static class ServiceRegistration
	{
		public static void AddPersistanceService(this IServiceCollection services)
		{
			services.AddDbContext<ETicaretAPIDbContext>(opt => opt.UseNpgsql("User ID=postgres;Password=123456;Host=localhost;Port=5432;Database=myDataBase;"));
			services.AddScoped<ICustomerWriteRepository, CustomerWriteRepository>();
			services.AddScoped<IOrderWriteRepository, OrderWriteRepository>();
            services.AddScoped<IOrderReadRepository, OrderReadRepository>();
			services.AddScoped<IProductReadRepository, ProductReadRepository>();
			services.AddScoped< IProductWriteRepository, ProductWriteRepository>();
			services.AddScoped<ICustomerReadRepository, CustomerReadRepository>();
        }
	}
}

