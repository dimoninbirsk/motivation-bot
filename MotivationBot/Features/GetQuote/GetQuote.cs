using MotivationBot.Domain;

namespace MotivationBot.Features.GetQuote;

public class GetQuote
{
    private List<Quote> quotes =
        [
            new(){ Id = 1,Author = "Гоггинс", Text = "Устал? Отлично. Значит, ты наконец-то начал работать.", Tags = ["Усталость"]},
            new(){ Id = 2,Author = "Гоггинс", Text = "ВСТАВАЙ! ТЫ ПРОСРАЛ УТРО!.", Tags = ["Утро"]}
        ];

    public Quote Get()
    {
        return quotes[Random.Shared.Next(quotes.Count)];
    }
}