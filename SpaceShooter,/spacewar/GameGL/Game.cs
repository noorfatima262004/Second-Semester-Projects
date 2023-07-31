using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;

namespace spacewar.GameGL
{
    class Game
    {
        public static int score = 0;
        public static int enemycount = 1;
        public static GameGrid grid;
        public static ship player;    
        public static List<enemyShip> ships = new List<enemyShip>();
        public static List<Bullet> bullets = new List<Bullet>();
        public static List<enemyshipbullet> bulletE = new List<enemyshipbullet>();
        public static List<RandomObject> key = new List<RandomObject>();
        public static List<Obstacle> obstacles = new List<Obstacle>();
        private static int rewardDelay = 0;
        public static int lives = 5;
        private static int x = 0;
        private static int y = 0;
        




        public static GameObject getBlankGameObject()
        {
            GameObject blankGameObject = new GameObject(GameObjectType.NONE, null);
            return blankGameObject;
        }
        public static void increaseScore(int scoreAdded)
        {
            score = score + scoreAdded;
        }



        public static void generateRandomReward()
        {
            rewardDelay++;
            if (rewardDelay % 30 == 0)
            {
                Random rand = new Random();

                x = rand.Next(1, 11);
                y = rand.Next(1, 20);

                Image rewardImg = Game.getGameObjectImage('*');
                GameCell rewardCell = Game.grid.getCell(x, y);
                GameObject obj = new GameObject(GameObjectType.REWARD, rewardImg);
                if (rewardCell.nextWallCell(GameDirection.Down).CurrentGameObject.GameObjectType == GameObjectType.WALL)
                {
                    rewardCell.setGameObject(obj);
                }

            }


        }

        public static Image getGameObjectImage(char displayCharacter)
        {
            Image img = null;

            if (displayCharacter == '#' || displayCharacter == '%')
            {
                img = spacewar.Properties.Resources.spaceStation_019;
            }
            if (displayCharacter == '|')
            {
                img = spacewar.Properties.Resources.spaceStation_020;
            }
            if (displayCharacter == '!')
            {
                img = spacewar.Properties.Resources.spaceStation_020;
            }
            if (displayCharacter == 'p' || displayCharacter == 'P')
            {
                img = spacewar.Properties.Resources.player;
            }
            if (displayCharacter == 'Q') // player fire
            {
                img = spacewar.Properties.Resources.images;
            }
            if (displayCharacter == 'h')
            {
                img = spacewar.Properties.Resources.enemyGreen2;
            }
            if (displayCharacter == 'H')
            {
                img = spacewar.Properties.Resources.enemy3;
            }
            if (displayCharacter == 'G')
            {
                img = spacewar.Properties.Resources.enemy3;
            }
            if (displayCharacter == 'F') // enemy fire
            {
                img = spacewar.Properties.Resources.enemyFire;
            }
            if (displayCharacter == 'B') // enemy fire
            {
                img = spacewar.Properties.Resources.fire;
            }
            if (displayCharacter == 'L')
            {
                img = spacewar.Properties.Resources.ufo2;
            }
            if (displayCharacter == 'x')
            {
                img = spacewar.Properties.Resources.enemy2;
            }
            if (displayCharacter == 'y')
            {
                img = spacewar.Properties.Resources.enemy;
            }if (displayCharacter == 'R')
            {
                img = spacewar.Properties.Resources.playerShip2_orange;
            }
            if (displayCharacter == '*')
            {
                img = spacewar.Properties.Resources.reward;
            }  if (displayCharacter == '@')
            {
                img = spacewar.Properties.Resources.obstacle;
            }

            return img;
        }
    }
}
