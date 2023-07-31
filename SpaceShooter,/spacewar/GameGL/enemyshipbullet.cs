using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;

namespace spacewar.GameGL
{
    class enemyshipbullet : Bullet
    {
        GameDirection direction;
        ship player;
        public enemyshipbullet(GameDirection direction, Image image, GameCell startCell, ship player) : base(GameObjectType.BULLET, image)
        {
            this.direction = direction;
            this.CurrentCell = startCell;
            this.player = player;
        }

        public enemyshipbullet()
        {

        }

        public override GameCell move()
        {
            if (getIsActive() == true)
            {
                GameCell currentCell = this.CurrentCell;
                GameCell nextCell = currentCell.nextCell(direction);
                GameCell nextcell2 = currentCell.nextWallCell(direction);
                GameObject previousObject = nextCell.CurrentGameObject;
                GameObject nextobj = nextcell2.CurrentGameObject;
                this.CurrentCell = nextCell;

                if (currentCell != nextCell)
                {
                    currentCell.setGameObject(Game.getBlankGameObject());
                }
                else if (currentCell == nextCell)
                {

                    if (nextobj.GameObjectType == GameObjectType.PLAYER)
                    {
                        player.decreaseHealth();
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
