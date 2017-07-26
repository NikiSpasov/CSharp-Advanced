using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
   public  class Enemy
    {
        public Enemy(char symbol, Position position)
        {
            this.Symbol = symbol;
            this.Position = position;
        }
        public char Symbol { get; set; }
        public Position Position { get; set; }
    }
}
