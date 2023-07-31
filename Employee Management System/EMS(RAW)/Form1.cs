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
using EMS_RAW_.UI;
using Guna.UI2.WinForms;

namespace EMS_RAW_
{
    public partial class Form1 : Form
    {
        string path = "AdminData.txt";
        public Form1()
        {
            InitializeComponent();
            SignInPassword.UseSystemPasswordChar = true;
            AdminPassword.UseSystemPasswordChar = true;
            if (AdminDL.getcount() != 0)
            {
                loginPannelToFront();   // sign in comes in front
            }
            else
            {
                AdminSignUpPannel.Show();
                guna2CustomGradientPanel2.Hide();
            }
        }


        private void SignIn_Click(object sender, EventArgs e)
        {
            if (validationForLogininEmty() == true)
            {
                Credential signIn = takeInputForLogin();
                if (AdminDL.getcount() != 0)
                {
                    AdminBL ad = AdminDL.signIn(signIn);
                    if (ad == null)
                    {
                        if (EmployeeDL.getList().Count != 0)
                        {
                            EmployeeBL emp = EmployeeDL.SignIn(signIn);
                            if (emp == null)
                            {
                                MessageBox.Show("Acount not found.");
                            }
                            else if (emp != null)
                            {
                               // emp.Employee = emp;
                                MessageBox.Show("User Login");
                                EmployeeDL.CurrentUser = emp;
                                this.Hide();
                                EmployeeForm form = new EmployeeForm();
                                form.Show();

                            }
                        }
                    }
                    else if (ad != null)
                    {
                        this.Hide();
                        Form2 form = new Form2();
                        form.Show();
                    }
                }
             
            }
        }
        private void AdminName_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsLetter(e.KeyChar) && e.KeyChar != '\b') // Allow backspace (\b) for editing
            {
                e.Handled = true; // Ignore the input character
            }
        }
        private void AdminPassword_KeyPress(object sender, KeyPressEventArgs e) // admin signup password validation
        {
            if (!char.IsLetter(e.KeyChar) && e.KeyChar != '\b') // Allow backspace (\b) for editing
            {
                e.Handled = true; // Ignore the input character
            }
        }
        private void AdminRole_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsLetter(e.KeyChar) && e.KeyChar != '\b') // Allow backspace (\b) for editing
            {
                e.Handled = true; // Ignore the input character
            }
        }
        private Credential takeInputForSignUp() // take input for Sign Up
        {
            string name = AdminName.Text;
            string password = AdminPassword.Text;
            string Role = AdminRole.Text;
            Credential c = new Credential(name, password, Role);
            return c;
        }
        private void restPannels() // reset  form
        {
            adminCheckBox.Checked = false;
            AdminName.Text = null;
            AdminPassword.Text = null;
            SignInPassword.Text = null;
            AdminName.Text = null;
        }
        private void loginPannelToFront() //  bring login panel to front
        {
            guna2CustomGradientPanel2.Show();
            AdminSignUpPannel.Hide();
            restPannels();
        }
        private bool validationForLogininEmty() //   validation at login for empty input
        {
            if (string.IsNullOrEmpty(SignInName.Text.Trim()))
            {
                errorProvider1.SetError(SignInName, "User name is required");
                return false;
            }
            else
            {
                errorProvider1.SetError(SignInName, string.Empty);
            }
            if (string.IsNullOrEmpty(SignInPassword.Text.Trim()))
            {
                errorProvider2.SetError(SignInPassword, "Password is required");
                return false;
            }
            else
            {
                errorProvider2.SetError(SignInPassword, string.Empty);
            }
            return true;
        }
        private bool validationaForAdminSignUpEmty() //  valiadation for empty at sign up form
        {
            if (string.IsNullOrEmpty(AdminName.Text.Trim()))
            {
                errorProvider4.SetError(AdminName, "User name is required");
                return false;
            }
            else
            {
                errorProvider4.SetError(AdminName, string.Empty);
            }
            if (string.IsNullOrEmpty(AdminRole.Text.Trim()))
            {
                errorProvider5.SetError(AdminRole, "Role is required");
                return false;
            }
            else
            {
                errorProvider5.SetError(AdminRole, string.Empty);
            }
            if (string.IsNullOrEmpty(AdminPassword.Text.Trim()))
            {
                errorProvider6.SetError(AdminPassword, "Password is required");
                return false;
            }
            else
            {
                errorProvider6.SetError(AdminPassword, string.Empty);
            }
            if (adminCheckBox.Checked == false)
            {
                errorProvider7.SetError(adminCheckBox, "Agreeing to all is necessary");
                return false;
            }
            else
            {
                errorProvider7.SetError(adminCheckBox, string.Empty);
            }
            return true;
        }
        private Credential takeInputForLogin() // take input for login
        {
            string name = SignInName.Text;
            string password = SignInPassword.Text;
            Credential c = new Credential(name, password);
            return c;
        }

        // for Password
        private void guna2ToggleSwitch1_CheckedChanged(object sender, EventArgs e)   // for password show
        {
            if (guna2ToggleSwitch1.Checked == true)
            {
                SignInPassword.UseSystemPasswordChar = false;
            }
            if (guna2ToggleSwitch1.Checked == false)
            {
                SignInPassword.UseSystemPasswordChar = true;
            }
        }
      
        private void SignUp_Click(object sender, EventArgs e)
        {
            if (validationaForAdminSignUpEmty() == true)
            {
                Credential obj = takeInputForSignUp();
                bool validity = validation.checkname(obj.Name);
                if (validity)
                {
                    errorProvider11.SetError(AdminName, string.Empty);
                    bool role = validation.checkroleadmin(obj.Role);
                    if (role)
                    {
                        errorProvider11.SetError(AdminRole, string.Empty);
                        bool validPass = validation.checkpassword(obj.Password);
                        if (validPass)
                        {
                            errorProvider11.SetError(AdminPassword, string.Empty);
                            bool valid = EmployeeDL.UserCheck(obj);
                            if (valid == false)
                            {
                                AdminBL ad = new AdminBL(obj);
                                MessageBox.Show("Add");
                                AdminDL.storeDataInList(ad);
                                MessageBox.Show("Your Id has been created.");
                              AdminDL.savedataAdmin(ref path, ad);
                                loginPannelToFront();
                            }
                            if (valid == true)
                            {
                                MessageBox.Show("Account already exist.");
                            }
                        }
                        else
                        {
                            errorProvider11.SetError(AdminPassword, "Invalid Password");
                        }
                    }
                    else
                    {
                        errorProvider11.SetError(AdminRole, "Invalid Role.");
                    }
                }
                else
                {
                    errorProvider11.SetError(AdminName, "Invalid Name.");

                }
            }

        }

        private void guna2ToggleSwitch2_CheckedChanged(object sender, EventArgs e)
        {
           
                if (guna2ToggleSwitch2.Checked == true)
                {
                    AdminPassword.UseSystemPasswordChar = false;
                }
                if (guna2ToggleSwitch2.Checked == false)
                {
                    AdminPassword.UseSystemPasswordChar = true;
                }
            

        }

        private void guna2Panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void AdminRole_TextChanged(object sender, EventArgs e)
        {

        }

        private void guna2Panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void AdminPassword_TextChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label14_Click(object sender, EventArgs e)
        {

        }

        private void SignInPassword_TextChanged(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void guna2CustomGradientPanel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void guna2ControlBox4_Click(object sender, EventArgs e)
        {

        }

        private void AdminName_TextChanged(object sender, EventArgs e)
        {

        }

        private void guna2ControlBox3_Click(object sender, EventArgs e)
        {

        }

        private void guna2ControlBox1_Click(object sender, EventArgs e)
        {

        }

        private void AdminSignUpPannel_Paint(object sender, PaintEventArgs e)
        {

        }

        private void SignInName_TextChanged(object sender, EventArgs e)
        {

        }

        private void guna2ControlBox2_Click(object sender, EventArgs e)
        {

        }

        private void adminCheckBox_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
