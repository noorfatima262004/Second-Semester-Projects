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
    public partial class Form6 : Form
    {
        public Form6()
        {
            InitializeComponent();
        }

        private void Form6_Load(object sender, EventArgs e)
        {
            MessageBox.Show(" GAME END \n You WON!", "Message Box with caption", MessageBoxButtons.OK, MessageBoxIcon.Stop);
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
