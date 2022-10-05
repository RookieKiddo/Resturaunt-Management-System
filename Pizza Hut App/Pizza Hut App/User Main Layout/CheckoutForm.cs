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
        static MenuForm menu;
        public List<string> DrinkL = new List<string>();
        public List<int> DrinkPriceL = new List<int>();
        public List<string> Salad = new List<string>();

        public CheckoutForm()
        {
            InitializeComponent();
            //Setting The Location Postion When The Form Starts//
            this.StartPosition = FormStartPosition.Manual;
            this.Location = new Point(0, 0);
            //------------------------------------------------//
            cmbTableNo.Enabled = false;
            groupBox2.Enabled = false;
            LOADOID();//Loads OID From File//
            orderType();//Check Order Type//
            GrandTotalLoad();//Load Grand Total From Menu Form To Checkout Form//
            //Intializaing Grid//
            ReciptGridView.Columns.Add("A", "S.No");
            ReciptGridView.Columns.Add("B", "Flavour");
            ReciptGridView.Columns.Add("C", "Size");
            ReciptGridView.Columns.Add("D", "Price");
            //--------------------//

            //Intializaing Extras ReciptGrid//
            ReciptGridExtras.Columns.Add("A", "S.No");
            ReciptGridExtras.Columns.Add("B", "Item");
            ReciptGridExtras.Columns.Add("C", "Price");
            //-------------------//
            ReciptGridView.Rows.Clear();
            ReciptGridExtras.Rows.Clear();

            DataGridView();
        }
        
        private void LOADOID()
        {
            int oid;
            string Oid;

            Oid = File.ReadAllText(@"OID.txt");
            oid = int.Parse(Oid);
            txtOID.Text = Oid;
        }

        private void orderType()
        {            
            if (MenuForm.OrderType == "Dine-In")
            {
                cmbTableNo.Enabled = true;
                txtOrderType.Text = "Dine-In";
            }
            else if (MenuForm.OrderType == "Delivery")
            {
                groupBox2.Enabled = true;
                txtOrderType.Text = "Delivery";
            }
            else
            {
                txtOrderType.Text = "Take-Out";
            }
        }

        private void GrandTotalLoad()
        {
            lblGrandTotalChk.Text = MenuForm.GrandTotal.ToString();
        }

        private void DataGridView()
        {
            int i = 0;
            menu = new MenuForm();
            int SNO = 0;           
            int counter1 = MenuForm.PizzaFlavourL.Count;
            int counter2 = MenuForm.DrinkL.Count;
            for (int k = 0; k < counter1 ; k++)
            {
                ReciptGridView.Rows.Add(SNO, MenuForm.PizzaFlavourL[k], MenuForm.SizeL[k], MenuForm.PizzaTotalL[k]);
                SNO++;
            }

            SNO = 0;

            for (i = 0; i < counter2; i++)
            {
                ReciptGridExtras.Rows.Add();
                ReciptGridExtras.Rows[i].Cells[0].Value = SNO;
                ReciptGridExtras.Rows[i].Cells[1].Value = MenuForm.DrinkL[i].ToString();
                ReciptGridExtras.Rows[i].Cells[2].Value = MenuForm.DrinkPriceL[i];
                SNO++;
            }

            int counter3 = MenuForm.SaladL.Count;

            if (counter3 != 0)
            { 
                for (int j = 0; j < counter3; j++,i++)
                {
                    ReciptGridExtras.Rows.Add();
                    ReciptGridExtras.Rows[i].Cells[0].Value = SNO;
                    ReciptGridExtras.Rows[i].Cells[1].Value = MenuForm.SaladL[j].ToString();
                    ReciptGridExtras.Rows[i].Cells[2].Value = MenuForm.SaladPriceL[j];
                }
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            int oid;
            string Oid;
            string Data = null;
            if (txtOrderType.Text == "Dine-In")
            {
                StreamWriter SW = new StreamWriter(@"Orders/DINEINOrders.txt", true);
                SW.Write(txtOID.Text + "#" + txtOrderType.Text + "#" + cmbTableNo.Text);
                for (int row = 0; row < ReciptGridView.Rows.Count - 1 ; row++)
                {
                    for (int col = 0; col < ReciptGridExtras.Columns.Count ; col++)
                    {
                        Data = ReciptGridView.Rows[row].Cells[col].Value.ToString();
                        SW.Write("#"+Data +"#");
                    }
                }
                for (int row = 0; row < ReciptGridView.Rows.Count - 1; row++)
                {
                    for (int col = 0; col < ReciptGridExtras.Columns.Count; col++)
                    {
                        Data = ReciptGridExtras.Rows[row].Cells[col].Value.ToString();
                        SW.Write("#" + Data + "#");
                    }
                }

                SW.Flush();
                SW.Close();
            }
            else if (txtOrderType.Text == "Delivery")
            {
                StreamWriter SW = new StreamWriter(@"Orders/DeliveryOrders.txt", true);
                SW.Write(txtOID.Text + "#" + txtOrderType.Text + "#" + txtCustomerName.Text + "#" + txtCustomerPhone.Text + "#" + txtCustomerAddress.Text + "#");

                for (int row = 0; row < ReciptGridView.Rows.Count - 1; row++)
                {
                    for (int col = 0; col < ReciptGridView.Columns.Count; col++)
                    {
                        Data = ReciptGridView.Rows[row].Cells[col].Value.ToString();
                        SW.Write("#" + Data + "#");
                    }
                }
                for (int row = 0; row < ReciptGridExtras.Rows.Count - 1; row++)
                {
                    for (int col = 0; col < ReciptGridView.Columns.Count; col++)
                    {
                        Data = ReciptGridExtras.Rows[row].Cells[col].Value.ToString();
                        SW.Write("#" + Data + "#");
                    }
                }
                SW.Flush();
                SW.Close();
            }
            else
            {
                StreamWriter SW = new StreamWriter(@"Orders/TakeoutOrders.txt", true);
                SW.Write(txtOID.Text + "#" + txtOrderType.Text);
                for (int row = 0; row < ReciptGridView.Rows.Count - 1; row++)
                {
                    for (int col = 0; col < ReciptGridView.Columns.Count; col++)
                    {
                        Data = ReciptGridView.Rows[row].Cells[col].Value.ToString();
                        SW.Write("#" + Data + "#");
                    }
                }
                for (int row = 0; row < ReciptGridExtras.Rows.Count - 1; row++)
                {
                    for (int col = 0; col < ReciptGridView.Columns.Count; col++)
                    {
                        Data = ReciptGridExtras.Rows[row].Cells[col].Value.ToString();
                        SW.Write("#" + Data + "#");
                    }
                }
                SW.Flush();
                SW.Close();
            }
            
            Oid = File.ReadAllText(@"OID.txt");
            oid = int.Parse(Oid);
            oid = oid + 1;
            File.WriteAllText(@"OID.txt", oid.ToString());

            MessageBox.Show("Data Saved Succesfully", "Save Successfull", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
        }
        
    }
}
