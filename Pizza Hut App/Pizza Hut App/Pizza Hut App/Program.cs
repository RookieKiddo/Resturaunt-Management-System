using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace Pizza_Hut_App
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            UserForm login = new UserForm(); //Creating an object for Userform to use the public variable 'AdminFormClick'.//
            Application.Run(login); //Running the UserForm When Application starts.//
            AdminForm AdminLogin = new AdminForm(); //Creating an object for Userform to use the public variable 'UserFormClick'.//

            if (login.AdminFormClick)
            {
                Application.Run(AdminLogin); //To Start AdminLogin Form.//               
            }
                    

            if (AdminLogin.UserFormClick)
            {
                Application.Restart(); //To Start UserLogin Form.//
            }
                                    
        }
    }
}
