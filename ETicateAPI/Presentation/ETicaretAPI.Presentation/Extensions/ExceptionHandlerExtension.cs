using System;
using System.Net;
using System.Net.Mime;
using System.Text.Json;
using Microsoft.AspNetCore.Diagnostics;

namespace ETicaretAPI.Presentation.Extensions
{
	static public class ExceptionHandlerExtension
	{
		public static void ConfigureExceptionHandlerExtension<T>(this WebApplication application,ILogger<T> logger)
		{
			application.UseExceptionHandler(builder =>
			{
				builder.Run(async context =>
				{
					context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
					context.Response.ContentType = MediaTypeNames.Application.Json;

					var features = context.Features.Get<IExceptionHandlerFeature>();
					if(features != null)
					{
						logger.LogError(features.Error.Message);

						await context.Response.WriteAsync(JsonSerializer.Serialize(new
						{
							StatusCode = context.Response.StatusCode,
							Message = features.Error.Message,
							Title = "HATA"
						}));
					}
				});
			});
		}

    }
}

