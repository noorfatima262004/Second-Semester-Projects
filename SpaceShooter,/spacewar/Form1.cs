using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using spacewar.GameGL;
using EZInput;
using System.Threading;

namespace spacewar
{
    public partial class Form1 : Form
    {
        GameGrid grid;
        //shipGame.player;
        enemy1 e1;
        enemy1 e2;
        enemy1 e3;
        RandomEnemy R1;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
                 Game.grid = new GameGrid("maze.txt", 13, 25);

            Image playerImg = GameGL.Game.getGameObjectImage('P');
            GameCell startCell = Game.grid.getCell(11, 2);
            Game.player = new ship(0, 100, playerImg, startCell);

            Image horiEnemy = Game.getGameObjectImage('h');
            GameCell h1 = Game.grid.getCell(3, 6);
            e1 = new enemy1(this, 100, Game.player, GameDirection.Left, horiEnemy, h1);

            Image horiEnemy2 = Game.getGameObjectImage('h');
            GameCell h2 = Game.grid.getCell(4, 22);
            e2 = new enemy1(this, 100, Game.player, GameDirection.Left, horiEnemy2, h2);

            Game.ships.Add(e1);
            Game.ships.Add(e2);

            printMaze(grid);
        }
        void printMaze(GameGrid grid)
        {
            for (int x = 0; x < Game.grid.Rows; x++)
            {
                for (int y = 0; y < Game.grid.Cols; y++)
                {
                    GameCell cell = Game.grid.getCell(x, y);
                    this.Controls.Add(cell.PictureBox);
                }
            }
        }

        private void gametimer1_Tick(object sender, EventArgs e)
        {
            HealthOfPlyer();

            if (Keyboard.IsKeyPressed(Key.LeftArrow))
            {
                Game.player.move(GameDirection.Left);

            }
            else if (Keyboard.IsKeyPressed(Key.RightArrow))
            {
                Game.player.move(GameDirection.Right);

            }

            else if (Keyboard.IsKeyPressed(Key.UpArrow))
            {

                Game.player.move(GameDirection.Up);

            }
            else if (Keyboard.IsKeyPressed(Key.DownArrow))
            {
                Game.player.move(GameDirection.Down);
            }
            else if (Keyboard.IsKeyPressed(Key.Space))
            {
                Game.player.generateBullet();
            }
            Game.generateRandomReward();
            foreach (enemyShip h in Game.ships)
            {
                h.move();
                h.generateBullet();
                h.setbarposition();
                h.setbarvalue();

                if (h.getLives() == 0)
                {
                    h.setisELive(false);
                    h.CurrentCell.PictureBox.Image = spacewar.Properties.Resources.explosion;
                    GameObject gameObj = Game.getBlankGameObject();
                    this.Controls.Remove(h.getbar());
                    h.CurrentCell.CurrentGameObject = gameObj;
                    Game.enemycount++;
                }
            }
            for (int x = 0; x < Game.ships.Count; x++)
            {
                if (Game.ships[x].getIsELive() == false)
                {
                    Game.ships.Remove(Game.ships[x]);
                }
            }

            if (Game.enemycount == 3)
            {
                Image RandomEnemy = Game.getGameObjectImage('R');
                GameCell h3 = Game.grid.getCell(3, 6);
                R1 = new RandomEnemy(this, 100, Game.player, GameDirection.Right, RandomEnemy, h3);
                Game.ships.Add(R1);
                Game.enemycount = -1;
                printMaze(grid);
            }
            if (Game.ships.Count == 0)
            {
                gametimer1.Enabled = false;
                this.Hide();
                Thread.Sleep(1000);
                Form4 f2 = new Form4();
                f2.Show();
            }

        }

        private void bullettimer2_Tick(object sender, EventArgs e)
        {
            foreach (Bullet b in Game.bullets)
            {
                b.move();
            }
            for (int x = 0; x < Game.bullets.Count; x++)
            {
                if (Game.bullets[x].getIsActive() == false)
                {
                    Game.bullets.RemoveAt(x);
                }
            }

            foreach (Bullet b in Game.bulletE)
            {
                b.move();
            }
            for (int x = 0; x < Game.bulletE.Count; x++)
            {
                if (Game.bulletE[x].getIsActive() == false)
                {
                    Game.bulletE.RemoveAt(x);
                }
            }
        }
        void HealthOfPlyer()
        {
            guna2ProgressBar1.Value = Game.player.getHealth();
            if (guna2ProgressBar1.Value == 0)
            {
                //gametimer1.Enabled = false;
                //MessageBox.Show(" GAME OVER \n You Lost!", "Message Box with caption", MessageBoxButtons.OK, MessageBoxIcon.Error);
                //this.Close();
                if (Game.lives > 0)
                {
                    Game.lives--;
                    Game.player.setHealth(100);
                }
                else if (Game.lives == 0)
                {
                    gametimer1.Enabled = false;
                    this.Close();
                    Form5 f = new Form5();
                    f.Show();

                }
            }

            label2.Text = "Score: " + Game.score;
            //.Text = "Lives: " + Game.lives;
        }
    }
}