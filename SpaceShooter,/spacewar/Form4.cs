using spacewar.GameGL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace spacewar
{
    public partial class Form4 : Form
     {
        public Form4()
        {
            InitializeComponent();
        }

        private void Form4_Load(object sender, EventArgs e)
        {
            MessageBox.Show(" WELCOME TO \n LEVEL TWO", "Message Box with caption", MessageBoxButtons.OK, MessageBoxIcon.Information);
          
            label1.Text =  Game.score.ToString();
        }
       

      

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            this.Close();
            Form2 f = new Form2();
            f.Show();
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }

        private void guna2Button3_Click(object sender, EventArgs e)
        {
            this.Close();
            Form1 f = new Form1();
            f.Show();
        }
    }
}
