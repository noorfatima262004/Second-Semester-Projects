using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;

namespace spacewar.GameGL
{
    class shipBullet : Bullet
    {
        GameDirection direction;
        private List<enemyShip> ships;
        public shipBullet()
        {

        }

        public shipBullet(List<enemyShip> ghosts, GameDirection direction, Image image, GameCell startCell) : base(GameObjectType.PLAYERBULLET, image)
        {
            this.direction = direction;
            this.CurrentCell = startCell;
            this.ships = ghosts;
        }

        public override GameCell move()
        {
            if (getIsActive() == true)
            {
                GameCell currentCell = this.CurrentCell;
                GameCell nextCell = currentCell.nextCell(direction);
                GameCell nextCell2 = currentCell.nextWallCell(direction);

                this.CurrentCell = nextCell;
                GameObject previousObject = nextCell.CurrentGameObject;
                GameObject nextObject = nextCell2.CurrentGameObject;



                if (currentCell != nextCell)
                {
                    currentCell.setGameObject(Game.getBlankGameObject());

                }
                else if (currentCell == nextCell)
                {
                    if (nextObject.GameObjectType == GameObjectType.ENEMY)
                    {
                        Game.score++;
                        foreach (enemyShip e in ships)
                        {
                            GameCell next = e.CurrentCell.nextWallCell(GameDirection.Up);
                            GameObject obj = next.CurrentGameObject;
                            GameCell next2 = e.CurrentCell.nextWallCell(GameDirection.Down);
                            GameObject obj2 = next2.CurrentGameObject;


                            if (obj.GameObjectType == GameObjectType.PLAYERBULLET)
                            {
                                e.decreasLive();
                                Game.increaseScore(3); 

                            }
                            else if (obj2.GameObjectType == GameObjectType.PLAYERBULLET)
                            {
                                e.decreasLive();
                                Game.increaseScore(3);
                            }
                        }
                    }

                    currentCell.setGameObject(Game.getBlankGameObject());
                    this.setIsActive(false);

                }
                return nextCell;
            }

            return null;
        }
    }
}
