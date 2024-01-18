﻿using Contracts;
using Entities;
using LoggerService;
using Microsoft.EntityFrameworkCore;
using Repository;

namespace AccountOwnerServer.Extensions;

public static class ServiceExtensions
{
    public static void ConfigureCors(this IServiceCollection services)
    {
        services.AddCors(options =>
        {
            options.AddPolicy("CorsPolicy",
                builder => builder.AllowAnyOrigin()
                    .AllowAnyMethod()
                    .AllowAnyHeader());
        });
    }
    
    public static void ConfigureIISIntegration(this IServiceCollection services)
    {
        services.Configure<IISOptions>(options =>
        {

        });
    }

    public static void ConfigureLoggerService(this IServiceCollection services)
    {
        services.AddSingleton<ILoggerManager, LoggerManager>();
    }

    public static void ConfigureMySqlContext(this IServiceCollection services, IConfiguration config) 
    {
        //services.AddDbContext<RepositoryContext>(o => o.UseInMemoryDatabase("AccountOwner"));
        
        var serverVersion = new MySqlServerVersion(new Version(8, 0, 3));
        var connectionString = config["mysqlconnection:connectionString"];
        //services.AddDbContext<RepositoryContext>(o => o.UseMySql(connectionString, serverVersion));
        services.AddDbContext<RepositoryContext>(options => options.UseMySql(
            connectionString, 
            ServerVersion.AutoDetect(connectionString),
            options => options.EnableRetryOnFailure(
                maxRetryCount: 5,
                maxRetryDelay: System.TimeSpan.FromSeconds(30),
                errorNumbersToAdd: null)
        ));
    }

    public static void ConfigureRepositoryWrapper(this IServiceCollection services)
    { 
        services.AddScoped<IRepositoryWrapper, RepositoryWrapper>(); 
    }
}