﻿using Microsoft.EntityFrameworkCore;
using StoreP.Core.Services.Contract;
using StoreP.Core;
using StoreP.Repository;
using StoreP.Repository.Data.Contexts;
using StoreP.Service.Services.Products;
using StoreP.Core.Mapping.Products;
using Microsoft.AspNetCore.Mvc;
using StoreP.APIs.Errors;
using StoreP.Core.Repositories.Contract;
using StoreP.Repository.Repositories;
using StackExchange.Redis;
using StoreP.Core.Mapping.Baskets;

namespace StoreP.APIs.Helper
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddDependency(this IServiceCollection services , IConfiguration configuration )
        {
            services.AddBuiltInService();
            services.AddSwaggerService();
            services.AddDbContextService(configuration);
            services.AddUserDefinedService();
            services.AddAutoMapperService(configuration);
            services.ConfigureInvaledModelStateResponseService();
            services.AddRedisService(configuration);


            return services;
        }
        private static IServiceCollection AddBuiltInService (this IServiceCollection services)
        {
            services.AddControllers();
            services.AddScoped<FcmService>();

            return services;
        }
        private static IServiceCollection AddSwaggerService(this IServiceCollection services)
        {
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen();

            return services;
        }
        private static IServiceCollection AddDbContextService(this IServiceCollection services , IConfiguration configuration)
        {
            services.AddDbContext<StoreDbContext>(option =>
            {
                option.UseSqlServer(configuration.GetConnectionString("DefaultConnection"));
            });

            return services;
        }
        private static IServiceCollection AddUserDefinedService(this IServiceCollection services)
        {
            services.AddScoped<IProductService, ProductService>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IBasketRepository, BasketRepository>();

            return services;
        }
        private static IServiceCollection AddAutoMapperService(this IServiceCollection services , IConfiguration configuration)
        {
            services.AddAutoMapper(M => M.AddProfile(new ProductProfile(configuration)));
            services.AddAutoMapper(M => M.AddProfile(new BasketProfile()));

            return services;
        }
        private static IServiceCollection ConfigureInvaledModelStateResponseService(this IServiceCollection services)
        {
            services.Configure<ApiBehaviorOptions>(options =>
               options.InvalidModelStateResponseFactory = (actioncontext) =>
               {
                   var errors = actioncontext.ModelState.Where(P => P.Value.Errors.Count() > 0)
                                             .SelectMany(P => P.Value.Errors)
                                             .Select(E => E.ErrorMessage)
                                             .ToList();

                   var response = new ApiValidationErrorResponse()
                   {
                       Errors = errors
                   };

                   return new BadRequestObjectResult(response);
               }
               );

            return services;
        }
        private static IServiceCollection AddRedisService(this IServiceCollection services ,IConfiguration configuration)
        {
            services.AddSingleton<IConnectionMultiplexer>((serviceProvider) =>
            {
                var connection = configuration.GetConnectionString("Redis");
                return ConnectionMultiplexer.Connect(connection);
            });
            return services;
        }
    }
}
