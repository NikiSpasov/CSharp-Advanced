using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;

namespace Utilities
{
   public class EnemyGenerator
    {
        public EnemyGenerator()
        {
            this.Enemies = new HashSet<Enemy>();
        }
        public HashSet<Enemy> Enemies { get; set; }
        public Enemy GenerateEnemy(Window consoleWindow, Random rand)
        {
            //Random rand = new Random(0);
            char coinSymbol = '@';
            Position enemyPosition = new Position(rand.Next(3, consoleWindow.FrameWidth - 1), rand.Next(5, consoleWindow.FrameHeight - 1));
            Enemy newEnemy = new Enemy(coinSymbol, enemyPosition);
            Enemies.Add(newEnemy);
            return newEnemy;
        }

        public bool IsPlayerKilled(Player player)
        {
            foreach (var enemy in this.Enemies)
            {
                if (enemy.Position.Equals(player.Position))
                {
                    return true;
                }
            }
            return false;
        }

    }
}
