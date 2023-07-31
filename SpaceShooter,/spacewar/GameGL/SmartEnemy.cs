using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;
using spacewar.GameGL;

namespace spacewar.GameGL
{
    class SmartEnemy : enemyShip
    {
        ship player;
        private int bulletDelay = 1;
        int speed;

        public SmartEnemy(Form form, int lives, ship player, GameDirection direction, Image image, GameCell startCell) : base(form, lives, GameObjectType.ENEMY, image, direction)
        {
            this.CurrentCell = startCell;
            this.player = player;

        }

        public override GameCell move()
        {
            if (this.getIsELive() == true)
            {
                //if (speed % 3 == 0)
                //{
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
                //   speed = 1;
                return null;

                //  }
            }
           // speed++;
            return this.CurrentCell;
        }

        public void manageDirections()
        {
            double[] distance = new double[4] { 10000, 10000, 10000, 10000 };
            if (this.CurrentCell.nextCell(GameDirection.Left).CurrentGameObject.GameObjectType != GameObjectType.WALL)
            {
                distance[0] = calculateDistance(this.CurrentCell.nextCell(GameDirection.Left));
            }
            if (this.CurrentCell.nextCell(GameDirection.Right).CurrentGameObject.GameObjectType != GameObjectType.WALL)
            {
                distance[1] = calculateDistance(this.CurrentCell.nextCell(GameDirection.Right));
            }
            if (this.CurrentCell.nextCell(GameDirection.Up).CurrentGameObject.GameObjectType != GameObjectType.WALL)
            {
                distance[2] = calculateDistance(this.CurrentCell.nextCell(GameDirection.Up));
            }
            if (this.CurrentCell.nextCell(GameDirection.Down).CurrentGameObject.GameObjectType != GameObjectType.WALL)
            {
                distance[3] = calculateDistance(this.CurrentCell.nextCell(GameDirection.Down));
            }
            if (distance[0] <= distance[1] && distance[0] <= distance[2] && distance[0] <= distance[3])
            {
                if (distance[0] > 4)
                {
                    this.direction = GameDirection.Left;
                }
            }
            if (distance[1] <= distance[0] && distance[1] <= distance[2] && distance[1] <= distance[3])
            {

                if (distance[1] > 4)
                {

                    this.direction = GameDirection.Right;
                }
            }
        }

        public double calculateDistance(GameCell nextcell)
        {
            return Math.Sqrt(Math.Pow((player.CurrentCell.X - nextcell.X), 2) + Math.Pow((player.CurrentCell.Y - nextcell.Y), 2));
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
