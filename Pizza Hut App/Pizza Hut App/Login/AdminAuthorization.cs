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
    public partial class AdminAuthorization : Form
    {
        public bool PasswordChecker = false; //Used in UserRegistrationForm To Grant Access//

        public AdminAuthorization()
        {
            InitializeComponent();
        }

        //Checking The Password From File//
        private void btnEnter_Click(object sender, EventArgs e)
        {
            string Pass, encryptedPassword;
            try
            {
                Decryption Dr = new Decryption(); //To Use Decryption Class//
                StreamReader SR = new StreamReader(@"AdminLogin/Users/" + txtUserName.Text + ".txt");
                SR.ReadLine();
                encryptedPassword = SR.ReadLine(); //Reading Encrypter Password From File//

                Pass = Dr.Decrypt(encryptedPassword); //Sending Data to Decrpyt Method In Decryption Class//

                if (txtPassword.Text.Equals(Pass))
                {
                    PasswordChecker = true;
                    MessageBox.Show("Authorization Granted","Authorization Successfull",MessageBoxButtons.OK,MessageBoxIcon.Information);
                    this.Dispose();
                }
                else
                {
                    PasswordChecker = false;
                    MessageBox.Show("Incorrect Username Or Password");
                }
            }
            catch (FileNotFoundException)
            {
                PasswordChecker = false;
                MessageBox.Show("User Not Found");
            }
        }

        //Disposing The Dialog of Admin Authorization//
        private void btnExit_Click(object sender, EventArgs e)
        {
            PasswordChecker = false;
            this.Dispose();
        }

        //To use Enter Button of KeyBoard//
        private void txtPassword_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnEnter_Click(null, null);
            }
        }
    }
}
