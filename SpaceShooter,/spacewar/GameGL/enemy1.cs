using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;

namespace spacewar.GameGL
{
    class enemy1 : enemyShip
    {
        ship player;
        private int bulletDelay = 1;

        public enemy1(Form form, int lives, ship player, GameDirection direction, Image image, GameCell startCell) : base(form, lives, GameObjectType.ENEMY, image, direction)
        {
            this.direction = GameDirection.Left;
            this.CurrentCell = startCell;
            this.player = player;
        }
        public override GameCell move()
        {
            if (this.isELive == true)
            {

                GameCell currentCell = this.CurrentCell;
                GameCell nextCell = currentCell.nextCell(direction);
                GameCell nextCell2 = currentCell.nextWallCell(direction);
                GameObject previousObject = nextCell.CurrentGameObject;
                this.CurrentCell = nextCell;
                GameCell downCell = nextCell.nextWallCell(GameDirection.Up);
                if (currentCell != nextCell)
                {
                    currentCell.setGameObject(previousObject);
                    if (downCell.CurrentGameObject.GameObjectType == GameObjectType.V_WALL)
                    {
                        manageDirections();
                    }

                }

                if (nextCell2.CurrentGameObject.GameObjectType == GameObjectType.PLAYERBULLET)
                {
                    this.decreasLive();
                }
            }

            else if (player.CurrentCell.Y == this.CurrentCell.Y)
            {
                enemyD();

               // generateBullet();
            }
            return null;

        }
        private void enemyD()
        {
            if (player.CurrentCell.Y < this.CurrentCell.Y)
            {
                direction = GameDirection.Left;
            }
            else if (player.CurrentCell.Y > this.CurrentCell.Y)
            {
                direction = GameDirection.Right;
            }
        }
        public void manageDirections()
        {

            if (direction == GameDirection.Left)
            {
                direction = GameDirection.Right;
            }
            else if (direction == GameDirection.Right)
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
                        Image bullet = GameGL.Game.getGameObjectImage('B');
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
