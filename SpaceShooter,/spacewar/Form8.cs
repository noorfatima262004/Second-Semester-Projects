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
    public partial class Form8 : Form
    {
        public Form8()
        {
            InitializeComponent();
        }



        private void Form8_Load(object sender, EventArgs e)
        {
        }

        private void guna2Button4_Click(object sender, EventArgs e)
        {
            // this.Close();
            Form1 f = new Form1();
            f.Show();
            this.Hide();
        }
        private void guna2Button1_Click(object sender, EventArgs e)
        {
            Form2 f = new Form2();
            f.Show();
            this.Hide();
        

        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            Environment.Exit    (0);
        }
    }
}

