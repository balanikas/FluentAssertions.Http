using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace SampleApplication;

public class Startup
{
    public Startup(IConfiguration configuration)
    {
    }

    public void ConfigureServices(IServiceCollection services)
    {
        services.AddMvc(o => o.EnableEndpointRouting = false);
    }

    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
        if (env.IsDevelopment()) app.UseDeveloperExceptionPage();

        app.UseMvc();
    }
}