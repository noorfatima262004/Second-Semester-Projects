using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using EMS_RAW_.BL;
using EMS_RAW_.DL;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TaskbarClock;

namespace EMS_RAW_
{
    public partial class AssignTask : UserControl
    {
        private static string path = "UserData.txt";
        public AssignTask()
        {
            InitializeComponent();
        }

        private void AssignTask_Load(object sender, EventArgs e)
        {
            Header();
            dataBind();
            guna2DateTimePicker1.Visible = true;
            DisciptionBtn.Visible = true;
            SaveBttn.Enabled = false;
            guna2GradientCircleButton1.Enabled = false;
            guna2CustomCheckBox1.Visible = false;
            guna2CustomCheckBox2.Visible = false;
            label1.Visible = false;
        }
        public void refresh()
        {
            Header();
            dataBind();
        }
        private void dataBind()
        {
            DataTable.DataSource = null;
            DataTable.Rows.Clear();
         
            foreach (var o in EmployeeDL.getList())
            {
                foreach (var d in o.Taskassigned)
                {
                    DataTable.Rows.Add(o.EmployeeData.Name, o.EmployeeData.Role, o.Departments, d.AssignTasks1, d.Taskname, d.Duration);
                }
            }
            DataTable.Refresh();

        }

        private Credential takeInputForSignUp() // take input for Sign Up
        {
            string name = employeeName.Text;
            string password = EmployeePassword.Text;
            string Role = RoleEmployee.SelectedItem.ToString();
            Credential c = new Credential(name, password, Role);
            return c;
        }

        private void guna2GradientCircleButton1_Click(object sender, EventArgs e)
        {
            SaveBttn.Enabled = false;
            guna2GradientCircleButton1.Enabled = false;
            guna2CustomCheckBox1.Visible = false;
            guna2CustomCheckBox2.Visible = false;
            label1.Visible = false;
        }

        private void SearchEmployee_Click_1(object sender, EventArgs e)
        {

            Credential c = takeInputForSignUp();
            EmployeeBL emp = EmployeeDL.SignIn(c);
            if (emp != null)
            {
                List<EmployeeBL> emp1 = new List<EmployeeBL>() { emp };

                DataTable.DataSource = null;        // Clear the DataTable to remove existing data
                var employeeDataWithTasks = emp1.Select(employee => new
                {
                    employee.EmployeeData.Name,
                    employee.EmployeeData.Role,
                    employee.Departments,
                    AssignedTasks = string.Join(", ", employee.Taskassigned.Select(task => task.AssignTasks1))
                }).ToList();

                DataTable.DataSource = employeeDataWithTasks;
                DataTable.Refresh();

                SaveBttn.Enabled = true;
                guna2CustomCheckBox1.Visible = true;
                guna2CustomCheckBox2.Visible = true;
                label1.Visible = true;
                MessageBox.Show("You can Assign the Task.\n For Assigning  the task check Blue checkBox \n For Not Assigning  the task check Red checkBox ", "Message Box with Icon", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }

        }

        private void guna2DateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void SaveBttn_Click(object sender, EventArgs e)
        {
            SearchEmployee.Enabled = false;
            Credential c = takeInputForSignUp();
            EmployeeBL emp = EmployeeDL.SignIn(c);
            if (emp != null)
            {
                if (guna2CustomCheckBox2.Checked == true)
                {
                    string Assign = "Assigned";
                    MessageBox.Show("Saved");
                    guna2CustomCheckBox1.Checked = false;
                    guna2CustomCheckBox2.Checked = false;
                    guna2DateTimePicker1.Visible = true;
                    DisciptionBtn.Visible = true;
                    DateTime time = guna2DateTimePicker1.Value;
                    string Task = DisciptionBtn.Text;
                    task t = new task(Task, time, Assign);
                    t.AssignTasks1 = Assign;
                    t.Duration = time;
                    t.Taskname = Task;
                    emp.settask(t); 

                }
                else if (guna2CustomCheckBox1.Checked == true)
                {
                    string assign = "Not Assigned";
                    task t = new task(assign);
                    t.AssignTasks1 = assign;
                    emp.settask(t);
                    EmployeeDL.updatedata(ref path);
                    EmployeeDL.updatedata(ref path);
                    MessageBox.Show("Saved");
                    guna2CustomCheckBox1.Checked = false;
                    guna2CustomCheckBox2.Checked = false;
                }
                else if (guna2CustomCheckBox1.Checked == false || guna2CustomCheckBox2.Checked == false)
                {
                    errorProvider1.SetError(guna2CustomCheckBox1, "This checkbox cannot be left empty.");
                }
                else
                {
                    // Clear the error message since the CheckBox is checked
                    errorProvider1.Clear();
                }
                EmployeeDL.updatedata(ref path);
                dataBind();
            }

        }
        public void Header()
        {
            string[] columnHeaders = { "Name", "Role", "Department", "AssignTask", "TaskName", "Time For Task" };
            foreach (var column in columnHeaders)
            {
                DataGridViewTextBoxColumn col = new DataGridViewTextBoxColumn();
                col.HeaderText = column;
                DataTable.Columns.Add(col);
            }
            dataBind();
        }
        private void DataTable_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void guna2CustomCheckBox1_Click(object sender, EventArgs e)
        {

        }
    }
}
