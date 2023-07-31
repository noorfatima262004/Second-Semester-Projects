using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using EMS_RAW_.BL;
using EMS_RAW_.DL;

namespace EMS_RAW_
{
    public partial class Pay : UserControl
    {
        private static string path = "UserData.txt";
        public Pay()
        {
            InitializeComponent();
        }
      
        private void Pay_Load(object sender, EventArgs e)
        {
            dataBind();
            
        }
        public void refresh()
        {

            dataBind();
        }
        private void dataBind()
        {
            DataTable.DataSource = null; // Clear the DataTable to remove existing data
            foreach (var o in EmployeeDL.getList())
            {
                if (o.EmployeeData.Role == "TeamLeader")
                {
                    o.Salarys1 = o.GiveSalary(o);
                    DataTable.DataSource = EmployeeDL.getList().Select(c => new { c.EmployeeData.Name, c.EmployeeData.Role, c.Departments, c.Attendence.Presents ,c.Salarys1 }).ToList();
                }
                else if(o.InternStatus == "PaidIntern")
                {
                    DataTable.DataSource = EmployeeDL.getList().Select(c => new { c.EmployeeData.Name, c.EmployeeData.Role, c.Departments, c.Attendence.Presents, c.Salarys1 }).ToList();
                }
            }
            DataTable.Refresh();
        }

        private void guna2GradientButton1_Click(object sender, EventArgs e)
        {
            EmployeeDL.updatedata(ref path);
        }

        private void DataTable_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
