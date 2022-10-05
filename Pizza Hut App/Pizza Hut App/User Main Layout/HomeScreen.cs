using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Pizza_Hut_App.User_Main_Layout;
using System.Diagnostics;

namespace Pizza_Hut_App
{
    public partial class HomeScreen : Form
    {
        static MenuForm menu;
        static CheckoutForm chkout;

        public HomeScreen()
        {
            InitializeComponent();
        }
                
        private void HomeScreen_Load(object sender, EventArgs e)
        {
            MediaPlayerControls();//Calling The Method For Playing Media Player//
            UserInformation();//Calling the method for displaying UserName and login DateTime//
        }

        //Media Player Controls//
        private void MediaPlayerControls()
        {
            MediaPlayer.URL = @"E:\DHA SUFFA UNIVERSITY\Semester 2\Courses\Object Oriented Programming\Project Pizza Hut\Pizza Hut App\Pizza Hut App\bin\Debug\Videos\Pizza Hut Main Video.mp4"; //Url For The Video That Plays on the Home Screen//
            MediaPlayer.Ctlcontrols.play();//Playing the video on Homescreen//
            MediaPlayer.settings.mute = true; //Muting the video running on homescreen//
        }
        //----------------------------------------------------------//

        //Exit From Menu Strip//
        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult D = MessageBox.Show("Are You Sure To Exit", "Exit", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (D == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        //LogOut From Menu Strip.//
        private void logOutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult D = MessageBox.Show("Are You Sure To Log-Out", "Log-Out", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            //If The User clicks on Yes then disspose the Home Screen and switch to User Login Form//
            if (D == DialogResult.Yes)
            {
                this.Dispose();
                UserForm User = new UserForm();
                User.Show();
            }
        }

        private void btnLogOut_Click(object sender, EventArgs e)
        {
            DialogResult D = MessageBox.Show("Are You Sure To Log-Out", "Log-Out", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            //If The User clicks on Yes then disspose the Home Screen and switch to User Login Form//
            if (D == DialogResult.Yes)
            {
                this.Dispose();
                UserForm User = new UserForm();
                User.Show();
            }
        }

        //Exit Button//
        private void btnExit_Click(object sender, EventArgs e)
        {
            DialogResult D = MessageBox.Show("Are You Sure To Exit", "Exit", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (D == DialogResult.Yes)
            {
                Application.Exit();
            }
        }
        //--------------------------//

        //This is the about box link label//
        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            AboutBox1 about = new AboutBox1();
            about.ShowDialog();
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AboutBox1 about = new AboutBox1();
            about.ShowDialog();
        }

        //This Timer is used to play the media video in seamless continous loop//
        private void timerMediaPlayer_Tick(object sender, EventArgs e)
        {
            if (MediaPlayer.Ctlcontrols.currentPosition > MediaPlayer.Ctlcontrols.currentItem.duration - 0.01)
            {
                MediaPlayer.Ctlcontrols.currentPosition = 0;
            }
        }

        //Method to show username, Email and LoggedIn DateTime On The Display.//
        private void UserInformation()
        {           
            lblUser.Text = UserForm.UserName;
            lblEmail.Text = UserForm.Email;
            lblDateTime.Text = DateTime.Now.ToString();
        }

        //Social Media Buttons//
        private void btnFacebook_Click(object sender, EventArgs e)
        {
            Process.Start("https://www.facebook.com/PizzaHutPak/");
        }

        private void btnInstagram_Click(object sender, EventArgs e)
        {
            Process.Start("https://www.instagram.com/pizzahutpak/"); 
        }

        private void btnTwitter_Click(object sender, EventArgs e)
        {
            Process.Start("https://twitter.com/pizzahut?ref_src=twsrc%5Egoogle%7Ctwcamp%5Eserp%7Ctwgr%5Eauthor"); 
        }
        //------------------------------------//

        private void btnMenu_Click(object sender, EventArgs e)
        {
            MediaPlayer.Hide();
            menu = new MenuForm();
            menu.MdiParent = this;
            menu.Show();
            
        }

        //Displays Video Again On Clicking Home//
        private void btnHome_Click(object sender, EventArgs e)
        {
            MediaPlayer.Show();
            menu.Dispose();
            chkout.Dispose();
        }
        //-------------------------------------//

        //To Dispose MenuForm//
        public void MenuFormDispose()
        {
            menu.Dispose();
        }
        //--------------------//
        
        private void btnCheckout_Click(object sender, EventArgs e)
        {
            MediaPlayer.Hide();
            chkout = new CheckoutForm();
            chkout.MdiParent = this;
            chkout.Show();
        }

        //TO Dispose Chekout Form//
        private void CheckoutDipsose()
        {
            chkout.Dispose();
        }
        //-----------------//
    }
}
