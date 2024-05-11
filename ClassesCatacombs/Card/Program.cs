List<Card> deck = new();

foreach (CardColor color in (CardColor[])Enum.GetValues(typeof(CardColor)))
{
    foreach (CardRank rank in (CardRank[])Enum.GetValues(typeof(CardRank)))
    {
        deck.Add(new Card(color, rank));
    }
}

foreach (var card in deck)
{
    Console.WriteLine($"Card color: {card.Color}, card rank: {card.Rank}");
}

public class Card
{
    public CardColor Color {get; init;}
    public CardRank Rank {get; init;}

    public Card(CardColor color, CardRank rank)
    {
        Color = color;
        Rank = rank;
    }
}
public enum CardColor {Red, Green, Blue, Yellow}
public enum CardRank {One,Two,Three,Four,Five,Six,Seven,Eight,Nine,Ten,DollarSign,PercentSign,Caret,Ampersand}