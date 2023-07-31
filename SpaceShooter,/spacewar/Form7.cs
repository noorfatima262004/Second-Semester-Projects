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
    public partial class Form7 : Form
    {
        public Form7()
        {
            InitializeComponent();
        }

        private void Form7_Load(object sender, EventArgs e)
        {
            MessageBox.Show(" WELCOME TO \n LEVEL THREE", "Message Box with caption", MessageBoxButtons.OK, MessageBoxIcon.Hand);
   
        }

      

        private void button2_Click(object sender, EventArgs e)  // restrat
        {
          
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }

      
        private void guna2Button1_Click(object sender, EventArgs e)
        {
            this.Close();
            Form3 f = new Form3();
            f.Show();

        }

        private void guna2Button3_Click(object sender, EventArgs e)
        {
            this.Close();
            Form1 f = new Form1();
            f.Show();
        }
    }
}
