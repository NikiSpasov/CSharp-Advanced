namespace Models
{
    public class Position
    {
        public Position(int x, int y)
        {
            this.X = x;
            this.Y = y;
        }
        public int X { get; set; }
        public int Y { get; set; }
        public override bool Equals(object obj)
        {
            Position otherPosition = obj as Position;
            if (otherPosition == null)
            {
                return false;
            }
            return this.X == otherPosition.X && this.Y == otherPosition.Y;
        }
    }
}
