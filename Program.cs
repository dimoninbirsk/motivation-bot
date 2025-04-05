using Microsoft.OpenApi.Models;
using MotivationBot.Domain;
using Scalar.AspNetCore;

namespace MotivationBot
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddAuthorization();

            builder.Services.AddOpenApi();

            var app = builder.Build();

            if (app.Environment.IsDevelopment())
            {
                app.MapOpenApi();
                app.MapScalarApiReference(options =>
                {
                    options.Title = "Motivation Bot";
                    options.ShowSidebar = true;
                    options.Theme = ScalarTheme.BluePlanet;
                    options.WithDefaultHttpClient(ScalarTarget.CSharp, ScalarClient.HttpClient);

                    options.Servers = new List<ScalarServer>
                    {
                        new("http://172.28.32.1:8080") { Url = "http://172.28.32.1:32772", Description = "http" },
                        new("http://172.28.32.1:8080") { Url = "http://172.28.32.1:32773", Description = "https" },
                    };
                });
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();

            var quotes = new List<Quote>
            {
                new(){ Id = 1,Author = "Гоггинс", Text = "Устал? Отлично. Значит, ты наконец-то начал работать.", Tags = ["Усталость"]},
                new(){ Id = 2,Author = "Гоггинс", Text = "ВСТАВАЙ! ТЫ ПРОСРАЛ УТРО!.", Tags = ["Утро"]}
            };

            app.MapGet("/give", (HttpContext httpContext) =>
            {
                return quotes[Random.Shared.Next(quotes.Count)];
            })
            .WithName("Give Quote");

            app.Run();
        }
    }
}