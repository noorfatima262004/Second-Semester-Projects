using Guna.UI2.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Security;
using System.Windows.Forms;

namespace EMS_RAW_
{
    public partial class TaskOfEmployee : UserControl
    {
        private static TaskOfEmployee instance;
        private static string path = "UserData.txt";
        public static TaskOfEmployee Instance
        {
            get
            {
                if (instance == null)
                    instance = new TaskOfEmployee();
                return instance;
            }


        }
        public TaskOfEmployee()
        {
            InitializeComponent();
            showData();
            guna2DateTimePicker1.Enabled = false;
        }

        private void TaskOfEmployee_Load(object sender, EventArgs e)
        {
            dataBind();
        }
        public void refresh()
        {

            dataBind();
        }
        private void dataBind()
        {
            DataTable.DataSource = null;        // Clear the DataTable to remove existing data
            foreach (var o in EmployeeDL.CurrentUser.getlist())
            {
                DataTable.DataSource = EmployeeDL.CurrentUser.getlist().Select(c => new { c.AssignTasks1, c.Taskname, c.Duration, c.TaskStatus, c.TaskDoneTime }).ToList();
            }
            DataTable.Refresh();
        }

        public void showData()
        {
            Name.ReadOnly = true;
            Name.Text = EmployeeDL.CurrentUser.EmployeeData.Name;
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void SaveBttn_Click(object sender, EventArgs e)
        {

        }


        private void guna2DateTimePicker1_ValueChanged(object sender, EventArgs e)  // date time picker
        {

        }

        private void guna2TextBox1_TextChanged(object sender, EventArgs e)  // text box of task
        {

        }

        private void guna2GradientCircleButton1_Click_1(object sender, EventArgs e)  // circle button
        {
            guna2CustomCheckBox2.Checked = false;

        }

        private void SaveBttn_Click_1(object sender, EventArgs e)  // savebuttonn
        {
            if (guna2CustomCheckBox2.Checked == false)
            {
                errorProvider1.SetError(guna2CustomCheckBox2, "This checkbox cannot be left empty.");
            }
            else
            {
                // Clear the error message since the CheckBox is checked
                errorProvider1.Clear();
                EmployeeDL.CurrentUser.Taskassigned[DataTable.CurrentRow.Index].TaskStatus = guna2CustomCheckBox2.Checked;
                if (EmployeeDL.CurrentUser.Taskassigned[DataTable.CurrentRow.Index].Duration > guna2DateTimePicker1.Value)
                {
                    EmployeeDL.CurrentUser.Taskassigned[DataTable.CurrentRow.Index].TaskDoneTime = "Done On Time";

                }
                else
                {
                    EmployeeDL.CurrentUser.Taskassigned[DataTable.CurrentRow.Index].TaskDoneTime = "Done Late";

                }
                EmployeeDL.updatedata(ref path);
                dataBind();
            }
        }

        private void DataTable_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if(e.RowIndex >=0 && e.ColumnIndex >=0) {
                DataGridViewRow clickedRow = DataTable.Rows[e.RowIndex];
                string task = clickedRow.Cells[0].Value?.ToString();
                guna2TextBox1.Text = task;
            }
        }
    }
}
