using MotivationBot.Domain;
using MotivationBot.Features.GetQuote;

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
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();

            app.MapGet("/give", (HttpContext httpContext) =>
            {
                GetQuote quoteGen = new();
                return quoteGen.Get();
            })
            .WithName("Give Quote");

            app.Run();
        }
    }
}