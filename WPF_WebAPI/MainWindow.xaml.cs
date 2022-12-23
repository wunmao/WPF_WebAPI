using System.Windows;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace WPF_WebAPI;
/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window
{
    public MainWindow() => InitializeComponent();

    private void Window_Loaded(object sender, RoutedEventArgs e)
    {
        var builder = WebApplication.CreateBuilder();

        // Add services to the container.

        _=builder.Services.AddControllers();
        // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
        _=builder.Services.AddEndpointsApiExplorer();
        _=builder.Services.AddSwaggerGen();

        var app = builder.Build();

        // Configure the HTTP request pipeline.
        if (app.Environment.IsDevelopment())
        {
            _=app.UseSwagger();
            _=app.UseSwaggerUI();
        }

        _=app.UseHttpsRedirection();

        _=app.UseAuthorization();

        _=app.MapControllers();

        app.Run();
    }
}
