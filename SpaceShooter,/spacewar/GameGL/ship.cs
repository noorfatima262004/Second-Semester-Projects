using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;

namespace spacewar.GameGL
{
    class ship : GameObject
    {
       // private bool isshipalive;
        public  int health;
        private int scores;
        private bool flipBool = false;
        private string flipPosition = "Up";
        public ship(int scores, int lives, Image image, GameCell startCell) : base(GameObjectType.PLAYER, image)
        {
            this.health = lives;
            this.scores = scores;
            this.CurrentCell = startCell;
        }
        public ship()
        {

        }
        public int getHealth()
        {
            return health;
        }
        public void setHealth(int health)
        {
            this.health = health;
        }
        public void increasHealth()
        {
            health = health + 5;
        }

        public void decreaseHealth()
        {
            health = health - 5;
        }
        public GameCell move(GameDirection direction)
        {
            GameCell currentCell = this.CurrentCell;
            GameCell nextCell = currentCell.nextCell(direction);
            //    addScores(nextCell);
            this.CurrentCell = nextCell;
            if (currentCell != nextCell)
            {
                currentCell.setGameObject(Game.getBlankGameObject());
            }
            return nextCell;
        }
        private void addScores(GameCell nextCell)
        {
            if (nextCell.CurrentGameObject.GameObjectType == GameObjectType.REWARD)
            {
                Game.increaseScore(1);
            }
        }

        public int getScores()
        {
            return scores;
        }
        public string getFlipPosition()
        {
            return flipPosition;
        }
        public void setFlipPosition(string position)
        {
            flipPosition = position;
        }
        public bool getFlip()
        {
            return flipBool;
        }
        public void setFlip(bool flip)
        {
            flipBool = flip;
        }
        public void flipPlayer()
        {
            if (flipPosition == "Up")
            {
                this.CurrentCell.PictureBox.Image = spacewar.Properties.Resources.player;
            }
            if (flipPosition == "Down")
            {
                this.CurrentCell.PictureBox.Image = spacewar.Properties.Resources.player_rotate;
            }
        }
        public void generateBullet()
        {
            shipBullet b = new shipBullet();
            Image bullet = GameGL.Game.getGameObjectImage('Q');
            GameCell startBullet = new GameCell();
            if (this.getFlipPosition() == "Up")
            {
                GameCell next = this.CurrentCell.nextWallCell(GameDirection.Up);
                if (next.CurrentGameObject.GameObjectType == GameObjectType.NONE)
                {
                    startBullet = this.CurrentCell.nextCell(GameDirection.Up);
                    b = new shipBullet(Game.ships, GameDirection.Up, bullet, startBullet);
                    b.setIsActive(true);
                    Game.bullets.Add(b);
                }
            }
            else if (this.getFlipPosition() == "Down")
            {
                GameCell next2 = this.CurrentCell.nextWallCell(GameDirection.Down);
                if (next2.CurrentGameObject.GameObjectType == GameObjectType.NONE)
                {
                    startBullet = this.CurrentCell.nextCell(GameDirection.Down);
                    b = new shipBullet(Game.ships, GameDirection.Down, bullet, startBullet);
                    b.setIsActive(true);
                    Game.bullets.Add(b);
                }
            }
        }
    }

}

