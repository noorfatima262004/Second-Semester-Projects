using Guna.UI2.WinForms;
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
    public partial class SeePay : UserControl
    {
        private static SeePay instance;
        public static SeePay Instance
        {
            get
            {
                if (instance == null)
                    instance = new SeePay();
                return instance;
            }


        }
        public SeePay()
        {
            InitializeComponent();
            showData();
        }
        public void SetNull()
        {
            EmployeeName.Text = null;
            Role.Text = null;
            Attendence.Text = null;
            guna2TextBox1.Text = null;
        }
        public void showData()
        {
            EmployeeName.ReadOnly = true;
            Role.ReadOnly = true;
            Attendence.ReadOnly = true;
            guna2TextBox1.ReadOnly = true;
            EmployeeName.Text = EmployeeDL.CurrentUser.EmployeeData.Name;
            guna2TextBox1.Text = EmployeeDL.CurrentUser.Salarys1.ToString();
            Attendence.Text = EmployeeDL.CurrentUser.Attendence.Presents.ToString();
            Role.Text = EmployeeDL.CurrentUser.EmployeeData.Role;
        }

        private void SeePay_Load(object sender, EventArgs e)
        {
            showData();
        }
    }
}
