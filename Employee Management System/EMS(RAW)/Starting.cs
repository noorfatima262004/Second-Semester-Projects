using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EMS_RAW_
{
    public partial class Starting : Form
    { 
        public Starting()
        {
            InitializeComponent();
        }

        private void Starting_Load(object sender, EventArgs e)
        {
            timer1.Start();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if(guna2ProgressBar1.Value < 100)
            {
                guna2ProgressBar1.Value += 1;
                guna2ProgressBar1.FillColor = Color.BlueViolet;
                guna2ProgressBar1.FillColor = Color.AliceBlue;

            }
            else
            {
                timer1.Stop();
                Form1 f = new Form1();
                f.Show();
                this.Hide();
            }
        }
    }
}
