using System;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using AhmadBooks.BMS.Data;
using Volo.Abp.DependencyInjection;

namespace AhmadBooks.BMS.EntityFrameworkCore;

public class EntityFrameworkCoreBMSDbSchemaMigrator
    : IBMSDbSchemaMigrator, ITransientDependency
{
    private readonly IServiceProvider _serviceProvider;

    public EntityFrameworkCoreBMSDbSchemaMigrator(
        IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider;
    }

    public async Task MigrateAsync()
    {
        /* We intentionally resolving the BMSDbContext
         * from IServiceProvider (instead of directly injecting it)
         * to properly get the connection string of the current tenant in the
         * current scope.
         */

        await _serviceProvider
            .GetRequiredService<BMSDbContext>()
            .Database
            .MigrateAsync();
    }
}
