using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.IO;
using spacewar.GameGL;

namespace spacewar.GameGL
{
    internal class RandomObject : GameObject
    {
        GameDirection direction;
        public RandomObject(GameObjectType type, Image image, GameCell startCell) : base(type, image)
        {
            this.CurrentCell = startCell;
        }

        public GameCell move()
        {


            GameCell currentCell = this.CurrentCell;
            GameCell nextCell = currentCell.nextCell(direction);
            GameCell nextCell2 = currentCell.nextWallCell(direction);
            GameObject previousObject = nextCell.CurrentGameObject;
            if (nextCell2.CurrentGameObject.GameObjectType != GameObjectType.WALL)
            {
                this.CurrentCell = nextCell;
            }






            if (currentCell != nextCell)
            {

                currentCell.setGameObject(Game.getBlankGameObject());


            }


            return null;



        }

        public void setDirection(GameDirection direction)
        {
            this.direction = direction;
        }




    }
}
