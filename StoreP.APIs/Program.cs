
using AutoMapper;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StoreP.APIs.Errors;
using StoreP.APIs.Helper;
using StoreP.APIs.Middlewares;
using StoreP.Core;
using StoreP.Core.Mapping.Products;
using StoreP.Core.Services.Contract;
using StoreP.Repository;
using StoreP.Repository.Data;
using StoreP.Repository.Data.Contexts;
using StoreP.Service.Services.Products;

namespace StoreP.APIs
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddDependency(builder.Configuration);

            var app = builder.Build();

            await app.ConfigureMiddlewareAsync();

            app.Run();
        }
    }
}
