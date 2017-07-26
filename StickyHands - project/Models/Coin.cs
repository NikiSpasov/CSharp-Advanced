namespace Models
{
    public class Coin
    {
        public Coin(char symbol, int value, Position position)
        {
            this.Symbol = symbol;
            this.Value = value;
            this.Position = position;
        }
        public char Symbol { get; set; }
        public int Value { get; set; }
        public Position Position { get; set; }
    }
}
