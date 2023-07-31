using spacewar.GameGL;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace spacewar.GameGL
{
    internal class Obstacle : GameObject
    {
        public Obstacle(Image image, GameCell startCell) : base(GameObjectType.OBSTACLE, image)
        {
            this.CurrentCell = startCell;
        }

        public void remove()
        {

            GameObject blankGameObject = new GameObject(GameObjectType.NONE, null);

            this.CurrentCell.setGameObject(blankGameObject);
        }
    }
}
