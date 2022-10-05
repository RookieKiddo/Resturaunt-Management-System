using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace Pizza_Hut_App
{
    public partial class UserRegistrationForm : Form
    {
        public UserRegistrationForm()
        {
            InitializeComponent();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            DialogResult D = MessageBox.Show("Are You Sure To Exit", "Exit", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (D == DialogResult.Yes)
            {
                this.Dispose(); // Closes Registration Form//
            }
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            string FirstName, LastName, Email, UserName, Password;
            //Checking If All Fields Are Complete or Not//
            if (txtFName.Text.Trim() == string.Empty)
            {
                MessageBox.Show("Please Fill All Required Fields", "Incomplete Fields", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                txtFName.Focus();
            }
            else if (txtLName.Text.Trim() == string.Empty)
            {
                MessageBox.Show("Please Fill All Required Fields", "Incomplete Fields", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                txtLName.Focus();
            }
            else if (txtEmail.Text.Trim() == string.Empty)
            {
                MessageBox.Show("Please Fill All Required Fields", "Incomplete Fields", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                txtEmail.Focus();
            }
            else if (txtUserName.Text.Trim() == string.Empty)
            {
                MessageBox.Show("Please Fill All Required Fields", "Incomplete Fields", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                txtUserName.Focus();
            }
            else if (txtPassword.Text.Trim() == string.Empty)
            {
                MessageBox.Show("Please Fill All Required Fields", "Incomplete Fields", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                txtPassword.Focus();
            }
            else if (txtRPassword.Text.Trim() == string.Empty)
            {
                MessageBox.Show("Please Fill All Required Fields", "Incomplete Fields", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                txtRPassword.Focus();
            }
            else
            {
                //Admin Authoraization Requirment.//
                AdminAuthorization AD = new AdminAuthorization();
                AD.ShowDialog();

                //Creating New Account//
                if (AD.PasswordChecker == true)
                {
                    if (txtPassword.Text.Equals(txtRPassword.Text))
                    {
                        Encrption En = new Encrption(); //To Use The Encryption Class//
                        StreamWriter SW = new StreamWriter(@"UserLogin/Users/" + txtUserName.Text + ".txt", true);

                        //Sending Data To Encryption Class To Encrypt The Data//
                        FirstName = En.Encrypt(txtFName.Text);
                        LastName = En.Encrypt(txtLName.Text);
                        Email = En.Encrypt(txtEmail.Text);
                        UserName = En.Encrypt(txtUserName.Text);
                        Password = En.Encrypt(txtPassword.Text);
                        //--------------------------------------//

                        //Writing The Encrypted Data In File//
                        SW.WriteLine(FirstName);
                        SW.WriteLine(LastName);
                        SW.WriteLine(Email);
                        SW.WriteLine(UserName);
                        SW.WriteLine(Password);
                        SW.Flush();
                        SW.Close();
                        //-------------------------//

                        MessageBox.Show("New Account Created Successfully", "Account Created", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.Dispose();
                    }
                    else
                    {
                        MessageBox.Show("Password Doesn't Match", "Retype Password", MessageBoxButtons.OK, MessageBoxIcon.Exclamation); //If Password Doesn't Match with retype password.//
                        txtRPassword.Text = null;
                        txtRPassword.Focus();
                    }
                }
            }
        }

        //Show or Hide Password//
        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked == true)
            {
                txtPassword.UseSystemPasswordChar = false;
                txtRPassword.UseSystemPasswordChar = false;
            }
            else if (checkBox1.Checked == false)
            {
                txtPassword.UseSystemPasswordChar = true;
                txtRPassword.UseSystemPasswordChar = true;
            }
        }
    }
}
