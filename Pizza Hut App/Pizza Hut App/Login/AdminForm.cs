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
    public partial class AdminForm : Form
    {
        public bool UserFormClick = false; //To Swith to User Mode//

        public AdminForm()
        {
            InitializeComponent();
        }

        //Eixting The Application//
        private void btnExit_Click(object sender, EventArgs e)
        {
            DialogResult D = MessageBox.Show("Are You Sure To Exit","Exit",MessageBoxButtons.YesNo,MessageBoxIcon.Question);

            if (D == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        //Used To Switch Back to User Mode//
        private void linklblUser_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            UserFormClick = true;
            if (UserFormClick == true)
            {
                this.Dispose();
            }
        }

        //Login Button//
        private void btnLogin_Click(object sender, EventArgs e)
        {
            string Pass, encryptedPassword;
            try
            {
                Decryption Dr = new Decryption(); //To Use Decryption Class//
                StreamReader SR = new StreamReader(@"AdminLogin/Users/" + txtUserName.Text + ".txt");
                SR.ReadLine();                
                encryptedPassword = SR.ReadLine(); //Reading Encrypter Password From File//

                Pass = Dr.Decrypt(encryptedPassword); //Sending Data to Decrpyt Method In Decryption Class//

                if (txtPasswrod.Text.Equals(Pass)) 
                {
                    StreamWriter SW = new StreamWriter(@"AdminLogin/AdminLog/" + txtUserName.Text + ".txt", true);// Creating Admin Log//
                    SW.WriteLine("User: " + txtUserName.Text + " Logged In at " + DateTime.Now); //Writing Log File//
                    SW.Flush();
                    SW.Close();
                    MessageBox.Show("CorrectPassword");
                }
                else
                {
                    MessageBox.Show("Incorrect Username Or Password");
                }
            }
            catch (FileNotFoundException)
            {
                MessageBox.Show("User Not Found","Incorrect User", MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
        }

        //To Use Enter Button of KeyBoard.//
        private void txtUserName_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnLogin_Click(null, null);
            }
        }

        //To Use Enter Button of KeyBoard.//
        private void txtPasswrod_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnLogin_Click(null, null);
            }
        }

        //To Show The Password//
        private void btnVisiblePass_MouseDown(object sender, MouseEventArgs e)
        {
            txtPasswrod.UseSystemPasswordChar = false;    
        }

        //To Hide The Password Again//
        private void btnVisiblePass_MouseUp(object sender, MouseEventArgs e)
        {
            txtPasswrod.UseSystemPasswordChar = true;
        }
       
    }
}
