using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;

namespace WPF_WebAPI;

public class Startup
{
    public IConfiguration Configuration { get; }
    public Startup(IConfiguration configuration) => Configuration = configuration;

    public void ConfigureServices(IServiceCollection services)
    {
        _ = services.AddCors(options => options.AddDefaultPolicy(builder => builder.AllowAnyOrigin()));
        _ = services.AddControllers();
        _ = services.AddEndpointsApiExplorer();
        _ = services.AddSwaggerGen(c =>
                                   {
                                       c.SwaggerDoc("v1",
                                                    new OpenApiInfo
                                                    {
                                                        Version     = "v1",
                                                        Title       = "WunmaoTest API",
                                                        Description = "Wunmao's Swagger Test",
                                                        Contact = new OpenApiContact
                                                                  {
                                                                      Name  = "Wunmao",
                                                                      Email = "wenmao.lo@gpline.com.tw"
                                                                  }
                                                    });
                                   });
    }

    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
        if (env.IsDevelopment())
        {
            _ = app.UseDeveloperExceptionPage();
        }
        else
        {
            _ = app.UseExceptionHandler("/Error");
            _ = app.UseHsts();
        }

        _ = app.UseSwagger();
        _ = app.UseSwaggerUI(c =>
                             {
                                 c.SwaggerEndpoint("/swagger/v1/swagger.json", "wunamoTest v1");
                                 c.RoutePrefix = string.Empty;
                             });

        //_ = app.UseHttpsRedirection();
        _ = app.UseCors();
        _ = app.UseRouting();
        _ = app.UseEndpoints(endpoints => _ = endpoints.MapControllers());
    }
}