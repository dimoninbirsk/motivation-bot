using MotivationBot.Domain;

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