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
    public partial class UserForm : Form
    {
        public static string UserName, Email;
        public bool AdminFormClick = false; //Used To Open Admin Form//

        public UserForm()
        {
            InitializeComponent();
        }


        //Exit Application//
        private void btnExit_Click(object sender, EventArgs e)
        {
            DialogResult D = MessageBox.Show("Are You Sure To Exit","Exit",MessageBoxButtons.YesNo,MessageBoxIcon.Question);

            if (D == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        //Open Admin Login Form//
        private void linklblAdmin_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            AdminFormClick = true; //Used To Open Admin Form; Used in Program.cs//
            this.Dispose(); //Closing User Form//
        }

        //LoginIn//
        private void btnLogin_Click(object sender, EventArgs e)
        {
            string Pass, encryptedPassword, encryptedEmail; //Used To Get Passwrod From File//
            try
            {                
                Decryption Dr = new Decryption(); //To Use Decryption Class//
                StreamReader SR = new StreamReader(@"UserLogin/Users/"+txtUsername.Text+".txt"); //Opening User File//
                SR.ReadLine(); //Reading Lines From File To Get To The Password//
                SR.ReadLine(); //Reading Lines From File To Get To The Password//
                Email = SR.ReadLine(); //Reading Lines From File To Get To The Password//
                SR.ReadLine(); //Reading Lines From File To Get To The Password//
                encryptedPassword = SR.ReadLine(); //Reading Encrypter Password From File//

                encryptedEmail = Dr.Decrypt(Email);
                Pass = Dr.Decrypt(encryptedPassword); //Sending Data to Decrpyt Method In Decryption Class//
                
                //Checking if File Password is equal to Input Password//                
                if (txtPassword.Text.Equals(Pass))
                {                    
                    StreamWriter SW = new StreamWriter(@"UserLogin/UserLog/" + txtUsername.Text + ".txt", true);// Creating User Log//
                    SW.WriteLine("User: " + txtUsername.Text + " Logged In at " + DateTime.Now); //Writing Log File//
                    SW.Flush();
                    SW.Close();
                    UserName = txtUsername.Text;
                    Email = encryptedEmail;
                    this.Hide();
                    HomeScreen Home = new HomeScreen();
                    Home.Show();                    
                }
                else
                {
                    MessageBox.Show("Incorrect Username Or Password","Incorrect User",MessageBoxButtons.OK,MessageBoxIcon.Error);
                }
            }
            catch (FileNotFoundException)
            {
                MessageBox.Show("User Not Found, Create New User");
            }
         }
        //-----------------------------------------------------------//

        //To Use Enter Button//
        private void txtPassword_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnLogin_Click(null, null);
            }
        }

        //To Use Enter Button//
        private void txtUsername_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnLogin_Click(null, null);
            }
        }

        //To Open Registration Form.//
        private void lnklblNewUser_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            UserRegistrationForm UF = new UserRegistrationForm();
            UF.ShowDialog();
        }

        //When Mouse is Clicking The Show Password Button Then The Password Will Be Visible//
        private void btnVisiblePass_MouseDown(object sender, MouseEventArgs e)
        {
            txtPassword.UseSystemPasswordChar = false;         
        }

        //When The Mouse Leaves The Click of Show Password Button Then The Password Will Hide Again//
        private void btnVisiblePass_MouseUp(object sender, MouseEventArgs e)
        {
            txtPassword.UseSystemPasswordChar = true;
        }
    }
}
