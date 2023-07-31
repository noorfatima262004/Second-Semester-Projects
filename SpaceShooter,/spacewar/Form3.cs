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

namespace spacewar
{
    public partial class Form3 : Form
    {
        GameGrid grid;
        ship player;
        SmartEnemy s1;
        SmartEnemy s2;
        SmartEnemy s3;
        public Form3()
        {
            InitializeComponent();
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            grid = new GameGrid("maze3.txt", 13, 25);

            Image playerImage = GameGL.Game.getGameObjectImage('P');
            GameCell startCell = grid.getCell(11, 2);
            player = new ship(0, 100, playerImage, startCell);

            Image smartEnemy = Game.getGameObjectImage('L');
            GameCell h3 = grid.getCell(2, 3);
            s1 = new SmartEnemy(this, 100, player, GameDirection.Left, smartEnemy, h3);


            Game.ships.Add(s1);

            guna2ProgressBar1.Value = player.getHealth();
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

        private void gametimer1_Tick(object sender, EventArgs e)
        {
                label2.Text = Convert.ToString(Game.score);
                if (Keyboard.IsKeyPressed(Key.LeftArrow))
                {
                    player.move(GameDirection.Left);

                }
                else if (Keyboard.IsKeyPressed(Key.RightArrow))
                {
                    player.move(GameDirection.Right);

                }

                else if (Keyboard.IsKeyPressed(Key.UpArrow))
                {

                    player.move(GameDirection.Up);

                }
                else if (Keyboard.IsKeyPressed(Key.DownArrow))
                {
                    player.move(GameDirection.Down);


                }
                else if (Keyboard.IsKeyPressed(Key.Space))
                {
                    player.generateBullet();
                }
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
                if (Game.enemycount == 2)
                {
                    Image smartEnemy = Game.getGameObjectImage('L');
                    GameCell h3 = grid.getCell(4, 6);
                    s2 = new SmartEnemy(this, 100, player, GameDirection.Left, smartEnemy, h3);
                    Game.ships.Add(s2);
                    Game.enemycount = -1;
                    printMaze(grid);
                }
                if (Game.enemycount == 3)
                {
                    Image smartEnemy = Game.getGameObjectImage('L');
                    GameCell h3 = grid.getCell(6, 6);
                    s3 = new SmartEnemy(this, 100, player, GameDirection.Right, smartEnemy, h3);
                    Game.ships.Add(s3);
                    Game.enemycount = -1;
                    printMaze(grid);
                }
                if (Game.ships.Count == 0)
                {
                    gametimer1.Enabled = false;
                    this.Close();
                    Form6 f = new Form6();
                    f.Show();
                }
                guna2ProgressBar1.Value = player.getHealth();
                if (player.getHealth() == 0)
                {
                    gametimer1.Enabled = false;
                    MessageBox.Show(" GAME OVER \n You Lost!", "Message Box with caption", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.Close();
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
    }
}
