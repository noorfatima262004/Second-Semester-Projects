using spacewar.GameGL;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace spacewar.GameGL
{
    class RandomEnemy : enemyShip
    {
        ship player;
        private int bulletDelay = 1;
         int speed;

        public RandomEnemy(Form form, int lives, ship player, GameDirection direction, Image image, GameCell startCell) : base(form, lives, GameObjectType.ENEMY, image, direction)
        {
            this.CurrentCell = startCell;
            this.player = player;

        }

        public override GameCell move()
        {
            if (this.isELive == true)
            {
                if (speed % 3 == 0)
                {
                    manageDirections();
                    GameCell currentCell = this.CurrentCell;
                    GameCell nextCell = currentCell.nextCell(direction);
                    GameObject previousObject = nextCell.CurrentGameObject;
                    this.CurrentCell = nextCell;

                    if (previousObject.GameObjectType == GameObjectType.PLAYER)
                    {
                        player.decreaseHealth();
                    }
                    if (currentCell != nextCell)
                    {
                        currentCell.setGameObject(previousObject);
                    }
                    speed = 1;
                    return null;
                }
                speed++;

            }
          
            return this.CurrentCell;
        }
        public int RandomValue()
        {
            Random r = new Random();
            int value = r.Next(4);
            return value;

        }
        public void manageDirections()
        {
            int random = RandomValue();
            if (random == 0 || random == 2)
            {
                direction = GameDirection.Right;
            }
            else if (random == 1 || random == 3)
            {
                direction = GameDirection.Left;
            }
        }

        public override void generateBullet()
        {

            GameCell currentCell = this.CurrentCell;
            GameCell nextCell = currentCell.nextWallCell(direction);


            if (nextCell.CurrentGameObject.GameObjectType == GameObjectType.NONE)
            {

                if (bulletDelay % 3 == 0)
                {
                    enemyshipbullet b = new enemyshipbullet();
                    Image bullet = GameGL.Game.getGameObjectImage('F');
                    GameCell startBullet = new GameCell();

                    startBullet = this.CurrentCell.nextCell(GameDirection.Down);
                    b = new enemyshipbullet(GameDirection.Down, bullet, startBullet, player);
                    b.setIsActive(true);
                    Game.bulletE.Add(b);
                }
                bulletDelay++;

            }
        }

    }
}
