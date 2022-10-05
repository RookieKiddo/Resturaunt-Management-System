using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace Pizza_Hut_App.User_Main_Layout
{
    public partial class CheckoutForm : Form
    {
        public CheckoutForm()
        {
            InitializeComponent();
            //Setting The Location Postion When The Form Starts//
            this.StartPosition = FormStartPosition.Manual;
            this.Location = new Point(0, 0);
            //------------------------------------------------//
            cmbTableNo.Enabled = false;
            groupBox2.Enabled = false;
            LOADOID();
            orderType();

            //Intializaing Grid//
            ReciptGridView.Columns.Add("A", "S.No");
            ReciptGridView.Columns.Add("B", "Flavour");
            ReciptGridView.Columns.Add("C", "Size");
            ReciptGridView.Columns.Add("D", "Drink");
            ReciptGridView.Columns.Add("E", "Salad");
            ReciptGridView.Columns.Add("F", "Order-Type");
            //--------------------//
        }

        public void LOADOID()
        {
            int oid;
            string Oid;

            Oid = File.ReadAllText(@"OID.txt");
            oid = int.Parse(Oid);
            txtOID.Text = Oid;
        }

        public void orderType()
        {            
            if (MenuForm.OrderType == "Dine-In")
            {
                cmbTableNo.Enabled = true;
            }
            else if (MenuForm.OrderType == "Delivery")
            {
                groupBox2.Enabled = true;
            }
        }
    }
}
