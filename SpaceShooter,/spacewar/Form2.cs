using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using EZInput;
using spacewar;
using spacewar.GameGL;

namespace spacewar
{
    public partial class Form2 : Form
    {
        GameGrid grid;
        //  shipGame.player;
        enemy1 e1;
        enemy1 e2;
        SmartEnemy s1;
        SmartEnemy s2;
        public Form2()
        {
            InitializeComponent();
        }
        private void Form2_Load_1(object sender, EventArgs e)
        {
            grid = new GameGrid("maze2.txt", 13, 25);

            Image playerImage = GameGL.Game.getGameObjectImage('P');
            GameCell startCell = grid.getCell(11, 2);
            Game.player = new ship(0, 100, playerImage, startCell);


            Image smartEnemy = Game.getGameObjectImage('x');
            GameCell h1 = grid.getCell(1, 2);
            s1 = new SmartEnemy(this, 100, Game.player, GameDirection.Left, smartEnemy, h1);

            //Image smartEnemy2 = Game.getGameObjectImage('y');
            //GameCell h3 = grid.getCell(1, 22);
            //s2 = new SmartEnemy(this, 100,Game.player, GameDirection.Left, smartEnemy, h3);

            Image horiEnemy2 = Game.getGameObjectImage('h');
            GameCell h2 = grid.getCell(5, 22);
            e1 = new enemy1(this, 100, Game.player, GameDirection.Left, horiEnemy2, h2);

            Game.ships.Add(s1);
            Game.ships.Add(e1);
            //  Game.ships.Add(s2);

            printMaze(grid);

        }
        void printMaze(GameGrid grid)
        {
            for (int x = 0; x < grid.Rows; x++)
            {
                for (int y = 0; y < grid.Cols; y++)
                {
                    GameCell cell = grid.getCell(x, y);
                    this.Controls.Add(cell.PictureBox);
                }
            }
        }
        void HealthOfPlyer()
        {
            guna2ProgressBar1.Value = Game.player.getHealth();
            if (guna2ProgressBar1.Value == 0)
            {


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

        private void gametimer1_Tick_1(object sender, EventArgs e)
        {

            //  label2.Text = Convert.ToString(Game.score);
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
            HealthOfPlyer();

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
                Image horiEnemy = Game.getGameObjectImage('G');
                GameCell h1 = grid.getCell(5, 14);
                e2 = new enemy1(this, 100, Game.player, GameDirection.Left, horiEnemy, h1);
                Game.ships.Add(e2);
                Game.enemycount = -1;
                printMaze(grid);
            }
            if (Game.enemycount == 2)
            {
                Image smartEnemy = Game.getGameObjectImage('y');
                GameCell h1 = grid.getCell(2, 4);
                s1 = new SmartEnemy(this, 100, Game.player, GameDirection.Left, smartEnemy, h1);
                Game.ships.Add(s1);
                Game.enemycount = -1;
                printMaze(grid);
            }
            if (Game.ships.Count == 0)
            {
                gametimer1.Enabled = false;
                this.Hide();
                Form7 f2 = new Form7();
                f2.Show();
            }

        }

        private void bullettimer2_Tick_1(object sender, EventArgs e)
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
    }
}
