﻿using DoctorHouse.DAL.Helper;
using DoctorHouse.IdentityServer;
using IdentityServer4.EntityFramework.DbContexts;
using IdentityServer4.EntityFramework.Mappers;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;

public static class DatabaseInitializer
{
    public static object IdentityServerConfiguration { get; private set; }

    public static void Init(IServiceProvider services)
    {
        SeederDB.SeedDataByAS(services);
        using (var scope = services.GetRequiredService<IServiceScopeFactory>().CreateScope())
        {
            //scopeServiceProvider.GetRequiredService<PersistedGrantDbContext>().Database.Migrate();

            var context = scope.ServiceProvider.GetRequiredService<ConfigurationDbContext>();

            //scopeServiceProvider.GetRequiredService<ConfigurationDbContext>();
            context.Database.Migrate();
            if (!context.Clients.Any())
            {
                foreach (var client in Config.Clients)
                {
                    context.Clients.Add(client.ToEntity());
                }
                context.SaveChanges();
            }

            if (!context.IdentityResources.Any())
            {
                foreach (var resource in Config.IdentityResources)
                {
                    context.IdentityResources.Add(resource.ToEntity());
                }
                context.SaveChanges();
            }

            if (!context.ApiScopes.Any())
            {
                foreach (var resource in Config.ApiScopes)
                {
                    context.ApiScopes.Add(resource.ToEntity());
                }
                context.SaveChanges();
            }
            //if (!context.ApiResources.Any())
            //{
            //    foreach (var resource in Config.ApiScopes)
            //    {
            //        context.ApiResources.Add(resource.ToEntity());
            //    }
            //    context.SaveChanges();
            //}



            //var manager = scope.ServiceProvider.GetRequiredService<UserManager<DbUser>>();
            //var managerRole = scope.ServiceProvider.GetRequiredService<RoleManager<DbRole>>();
            //SeederDB.SeedData(manager, managerRole);
        }

    }
}