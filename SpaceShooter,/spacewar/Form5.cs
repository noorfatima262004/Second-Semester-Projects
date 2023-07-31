using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;

namespace spacewar
{
    public partial class Form5 : Form
    {
        public Form5()
        {
            InitializeComponent();
        }

        private void Form5_Load(object sender, EventArgs e)
        {
            Thread.Sleep(1000);   
            MessageBox.Show(" GAME OVER \n You Lost!", "Message Box with Icon", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
