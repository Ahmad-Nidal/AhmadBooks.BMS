using System;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Volo.Abp;

namespace AhmadBooks.BMS;

public class BMSWebTestStartup
{
    public void ConfigureServices(IServiceCollection services)
    {
        services.AddApplication<BMSWebTestModule>();
    }

    public void Configure(IApplicationBuilder app, ILoggerFactory loggerFactory)
    {
        app.InitializeApplication();
    }
}
