using System.Windows;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;

namespace WPF_WebAPI;

/// <summary>Interaction logic for MainWindow.xaml</summary>
public partial class MainWindow : Window
{
    public MainWindow() => InitializeComponent();

    private void Window_Loaded(object sender, RoutedEventArgs e)
    {
        var builder = WebApplication.CreateBuilder();
        _ = builder.Services.AddCors(options => options.AddDefaultPolicy(policy => policy.AllowAnyOrigin()));
        _ = builder.Services.AddControllers();
        _ = builder.Services.AddEndpointsApiExplorer();
        _ = builder.Services.AddSwaggerGen(c =>
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

        var app = builder.Build();
        app.Urls.Add("http://*:5001");
        app.Urls.Add("https://*:5002");

        if (app.Environment.IsDevelopment())
        {
            _ = app.UseSwagger();
            _ = app.UseSwaggerUI(c =>
                                 {
                                     c.SwaggerEndpoint("/swagger/v1/swagger.json", "wunamoTest v1");
                                     c.RoutePrefix = "swagger";
                                 });
        }

        //_ = app.UseHttpsRedirection(); //! 若要啟用HTTP就不能用這行，這行會將HTTP請求自動轉HTTPS
        _ = app.MapControllers();
        _ = app.UseAuthorization();
        _ = app.UseCors();
        _ = app.RunAsync();
    }
}