using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Pizza_Hut_App.Classes;
using System.IO;

namespace Pizza_Hut_App.User_Main_Layout
{
    public partial class MenuForm : Form
    {
        private bool OrderTypeValidate;
        public static bool saladCheck;
        public static string OrderType;
        public string PizzaFlavour;
        public static int GrandTotal = 0;
        public static List<string> PizzaFlavourL = new List<string>(); //Sending Pizza Flavours to Chekout Form//
        public static List<int> PriceL = new List<int>(); //Sending Pizza Price to Checkout Form//
        public static List<string> SizeL = new List<string>(); //Sending Pizza Size To Checkout Form//
        public static List<string> DrinkL = new List<string>();
        public static List<int> DrinkPriceL = new List<int>();
        public static List<string> SaladL = new List<string>();
        public static int PizzaTotal = 0;
        public static List<int> PizzaTotalL = new List<int>();
        public static List<int> SaladPriceL = new List<int>();
        public static int ExtrasTotal = 0;
        private int SNO = 0;
        int j = 0;
        int k = 0;
        int L = 0;

        Menu1 mnu;

        public MenuForm()
        {
            InitializeComponent();
            
            //Setting The Location Postion When The Form Starts//
            this.StartPosition = FormStartPosition.Manual;
            this.Location = new Point(0, 0);
            //------------------------------------------------//

            //Grid For Pizza//
            ReciptGridB.Columns.Add("A", "S.No");
            ReciptGridB.Columns.Add("B", "Item");
            ReciptGridB.Columns.Add("C", "Qty");
            ReciptGridB.Columns.Add("D", "Total");
            //----------------//
  
            //Grid For Extras/Miscallneous//
            ReciptGridM.Columns.Add("A", "S.No");
            ReciptGridM.Columns.Add("B", "Item");
            ReciptGridM.Columns.Add("C", "Total");


            GetDrink(); //Calling Get Drink Method on form Load//
            OrderTypeValidate = false;
            saladCheck = false;
            IsOrderTypeValidated();
            SaladCheck();
        }
               
        //Method To Get Drink Names In ComboBox//
        public void GetDrink()
        {
            mnu = new Menu1();
            mnu.Drink();
            cmbDrinkD.Items.Clear();
            for (int i = 0; i < mnu.DrinkLength; i++)
            {
                cmbDrinkD.Items.Add(Menu1.drinkName[i]);//Combo-Box For Dine-In Tab//                
            }
        }
        //--------------------------------//

        //To Disable The Menu if OrderType is not selected//
        public void IsOrderTypeValidated()
        {
            if (OrderTypeValidate == false)
            {
                grpFlavours.Enabled = false;
                grpMiscellaneous.Enabled = false;
                grpPizzaSize.Enabled = false;                
            }
            else
            {
                grpFlavours.Enabled = true;
                grpMiscellaneous.Enabled = true;
                grpPizzaSize.Enabled = true;
            }                        
        }
        //---------------------------//

        //Checking Salad//
        private void SaladCheck()
        {
            if (saladCheck == false)
            {
                rdbtnSaladSmallD.Enabled = false;
                rdbtnSaladMediumD.Enabled = false;
                rdbtnSaladLargeD.Enabled = false;
            }
            else
            {
                rdbtnSaladSmallD.Enabled = true;
                rdbtnSaladMediumD.Enabled = true;
                rdbtnSaladLargeD.Enabled = true;
            }
        }
        //--------------//

        private void btnAddToCartD_Click(object sender, EventArgs e)
        {
            

            if (OrderTypeValidate == false)
            {
                MessageBox.Show("Please Select The Order Type First", "Select Order Type", MessageBoxButtons.OK);
            }

            else
            {
                //Order Type--------------//
                if (rdbtnDineIn.Checked == true)
                {
                    OrderType = rdbtnDineIn.Text;
                }
                else if (rdbtnTakeOut.Checked == true)
                {
                    OrderType = rdbtnTakeOut.Text;
                }
                else if (rdbtnDelivery.Checked == true)
                {
                    OrderType = rdbtnDelivery.Text;
                }
                //-------------------------//

                //Pizza Flavour-------------------//
                if (rdbtnAfghaniTikka.Checked == false && rdbtnCheeseLover.Checked == false && rdbtnChickenFajita.Checked == false && rdbtnChikenSupreme.Checked == false && rdbtnChickenTikka.Checked == false && rdbtnFajitaSicilian.Checked == false && rdbtnSuperSicilian.Checked == false)
                {
                    MessageBox.Show("Please Select Pizza Flavour", "Select Pizza Flavour", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                else if (rdbtnAfghaniTikka.Checked == true)
                {
                    PizzaFlavour = rdbtnAfghaniTikka.Text;
                    PizzaFlavourL.Add(PizzaFlavour);
                    if (rdbtnPizzaSmallD.Checked == false && rdbtnPizzaMediumD.Checked == false && rdbtnPizzaLargeD.Checked == false)
                    {
                        MessageBox.Show("Please Select Pizza Size", "Select Pizza Size", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    }
                    else if (rdbtnPizzaSmallD.Checked == true)
                    {
                        PriceL.Add(500);
                        SizeL.Add(rdbtnPizzaSmallD.Text);
                    }
                    else if (rdbtnPizzaMediumD.Checked == true)
                    {
                        PriceL.Add(800);
                        SizeL.Add(rdbtnPizzaMediumD.Text);
                    }
                    else if (rdbtnPizzaLargeD.Checked == true)
                    {
                        PriceL.Add(1000);
                        SizeL.Add(rdbtnPizzaLargeD.Text);
                    }                        
                }
                else if (rdbtnCheeseLover.Checked == true)
                {
                    PizzaFlavour = rdbtnCheeseLover.Text;
                    PizzaFlavourL.Add(PizzaFlavour);
                    if (rdbtnPizzaSmallD.Checked == false && rdbtnPizzaMediumD.Checked == false && rdbtnPizzaLargeD.Checked == false)
                    {
                        MessageBox.Show("Please Select Pizza Size", "Select Pizza Size", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    }
                    else if (rdbtnPizzaSmallD.Checked == true)
                    {
                        PriceL.Add(500);
                        SizeL.Add(rdbtnPizzaSmallD.Text);
                    }
                    else if (rdbtnPizzaMediumD.Checked == true)
                    {
                        PriceL.Add(800);
                        SizeL.Add(rdbtnPizzaMediumD.Text);
                    }
                    else if (rdbtnPizzaLargeD.Checked == true)
                    {
                        PriceL.Add(1000);
                        SizeL.Add(rdbtnPizzaLargeD.Text);
                    }
                }
                else if (rdbtnChickenFajita.Checked == true)
                {
                    PizzaFlavour = rdbtnChickenFajita.Text;
                    PizzaFlavourL.Add(PizzaFlavour);
                    if (rdbtnPizzaSmallD.Checked == false && rdbtnPizzaMediumD.Checked == false && rdbtnPizzaLargeD.Checked == false)
                    {
                        MessageBox.Show("Please Select Pizza Size", "Select Pizza Size", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    }
                    else if (rdbtnPizzaSmallD.Checked == true)
                    {
                        PriceL.Add(500);
                        SizeL.Add(rdbtnPizzaSmallD.Text);
                    }
                    else if (rdbtnPizzaMediumD.Checked == true)
                    {
                        PriceL.Add(800);
                        SizeL.Add(rdbtnPizzaMediumD.Text);
                    }
                    else if (rdbtnPizzaLargeD.Checked == true)
                    {
                        PriceL.Add(1000);
                        SizeL.Add(rdbtnPizzaLargeD.Text);
                    }
                }
                else if (rdbtnChikenSupreme.Checked == true)
                {
                    PizzaFlavour = rdbtnChikenSupreme.Text;
                    PizzaFlavourL.Add(PizzaFlavour);
                    if (rdbtnPizzaSmallD.Checked == false && rdbtnPizzaMediumD.Checked == false && rdbtnPizzaLargeD.Checked == false)
                    {
                        MessageBox.Show("Please Select Pizza Size", "Select Pizza Size", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    }
                    else if (rdbtnPizzaSmallD.Checked == true)
                    {
                        PriceL.Add(500);
                        SizeL.Add(rdbtnPizzaSmallD.Text);
                    }
                    else if (rdbtnPizzaMediumD.Checked == true)
                    {
                        PriceL.Add(800);
                        SizeL.Add(rdbtnPizzaMediumD.Text);
                    }
                    else if (rdbtnPizzaLargeD.Checked == true)
                    {
                        PriceL.Add(1000);
                        SizeL.Add(rdbtnPizzaLargeD.Text);
                    }
                }
                else if (rdbtnChickenTikka.Checked == true)
                {
                    PizzaFlavour = rdbtnChickenTikka.Text;
                    PizzaFlavourL.Add(PizzaFlavour);
                    if (rdbtnPizzaSmallD.Checked == false && rdbtnPizzaMediumD.Checked == false && rdbtnPizzaLargeD.Checked == false)
                    {
                        MessageBox.Show("Please Select Pizza Size", "Select Pizza Size", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    }
                    else if (rdbtnPizzaSmallD.Checked == true)
                    {
                        PriceL.Add(500);
                        SizeL.Add(rdbtnPizzaSmallD.Text);
                    }
                    else if (rdbtnPizzaMediumD.Checked == true)
                    {
                        PriceL.Add(800);
                        SizeL.Add(rdbtnPizzaMediumD.Text);
                    }
                    else if (rdbtnPizzaLargeD.Checked == true)
                    {
                        PriceL.Add(1000);
                        SizeL.Add(rdbtnPizzaLargeD.Text);
                    }
                }
                else if (rdbtnFajitaSicilian.Checked == true)
                {
                    PizzaFlavour = rdbtnFajitaSicilian.Text;
                    PizzaFlavourL.Add(PizzaFlavour);
                    if (rdbtnPizzaSmallD.Checked == false && rdbtnPizzaMediumD.Checked == false && rdbtnPizzaLargeD.Checked == false)
                    {
                        MessageBox.Show("Please Select Pizza Size", "Select Pizza Size", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    }
                    else if (rdbtnPizzaSmallD.Checked == true)
                    {
                        PriceL.Add(500);
                        SizeL.Add(rdbtnPizzaSmallD.Text);
                    }
                    else if (rdbtnPizzaMediumD.Checked == true)
                    {
                        PriceL.Add(800);
                        SizeL.Add(rdbtnPizzaMediumD.Text);
                    }
                    else if (rdbtnPizzaLargeD.Checked == true)
                    {
                        PriceL.Add(1000);
                        SizeL.Add(rdbtnPizzaLargeD.Text);
                    }
                }
                else if (rdbtnSuperSicilian.Checked == true)
                {
                    PizzaFlavour = rdbtnSuperSicilian.Text;
                    PizzaFlavourL.Add(PizzaFlavour);
                    if (rdbtnPizzaSmallD.Checked == false && rdbtnPizzaMediumD.Checked == false && rdbtnPizzaLargeD.Checked == false)
                    {
                        MessageBox.Show("Please Select Pizza Size", "Select Pizza Size", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    }
                    else if (rdbtnPizzaSmallD.Checked == true)
                    {
                        PriceL.Add(500);
                        SizeL.Add(rdbtnPizzaSmallD.Text);
                    }
                    else if (rdbtnPizzaMediumD.Checked == true)
                    {
                        PriceL.Add(800);
                        SizeL.Add(rdbtnPizzaMediumD.Text);
                    }
                    else if (rdbtnPizzaLargeD.Checked == true)
                    {
                        PriceL.Add(1000);
                        SizeL.Add(rdbtnPizzaLargeD.Text);
                    }
                }
                //--------------------------------------//

                if (numericQty.Value != 0)
                {
                    PizzaTotalL.Add(PriceL[j] * Convert.ToInt32(numericQty.Value));
                    ReciptGridB.Rows.Add(SNO, PizzaFlavour, numericQty.Value, PizzaTotalL[j]);
                    GrandTotal += PizzaTotalL[j];
                    GrandTotalMaker();
                    SNO++;
                    j++;
                }
                else
                {
                    MessageBox.Show("Please Select Quantity Value Other Then '0'", "Select Valid Quantity", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                }
            }   
        }

        //Checking Salad Box//
        private void chkSaladD_CheckedChanged(object sender, EventArgs e)
        {
            if (chkSaladD.Checked == true)
            {
                saladCheck = true;
                SaladCheck();
            }
            else if (chkSaladD.Checked == false)
            {
                saladCheck = false;
                SaladCheck();
            }
        }
        //------------------------//

        //Checking OrderType//
        private void rdbtnDineIn_CheckedChanged(object sender, EventArgs e)
        {
            if (rdbtnDineIn.Checked == true)
            {
                OrderTypeValidate = true;
                IsOrderTypeValidated();
            }
        }

        private void rdbtnTakeOut_CheckedChanged(object sender, EventArgs e)
        {
            if (rdbtnTakeOut.Checked == true)
            {
                OrderTypeValidate = true;
                IsOrderTypeValidated();
            }
        }

        private void rdbtnDelivery_CheckedChanged(object sender, EventArgs e)
        {
            if (rdbtnDelivery.Checked == true)
            {
                OrderTypeValidate = true;
                IsOrderTypeValidated();
            }
        }

        private void btnAddExtra_Click(object sender, EventArgs e)
        {                        
            int SaladPrice = 0;
            mnu = new Menu1();
            SNO = 0;
            for (int i = 0; ; i++,k++)
            {
                if (cmbDrinkD.SelectedIndex == i)
                {
                    DrinkL.Add(Menu1.drinkName[i]);
                    DrinkPriceL.Add(Convert.ToInt32(Menu1.Drinkprice[i]));
                    GrandTotal += Convert.ToInt32(Menu1.Drinkprice[i]);
                    GrandTotalMaker();
                    break;
                }
            }
            ReciptGridM.Rows.Add(SNO, cmbDrinkD.Text, Menu1.Drinkprice[k]);

            if (saladCheck == true)
            {
                if (rdbtnSaladSmallD.Checked == true)
                {
                    SaladPrice = 100;
                    SaladL.Add(rdbtnSaladSmallD.Text);
                    SaladPriceL.Add(SaladPrice);
                    GrandTotal += SaladPrice;
                    GrandTotalMaker();
                    ReciptGridM.Rows.Add(SNO, chkSaladD.Text + rdbtnSaladSmallD.Text, SaladPrice);
                }
                else if (rdbtnSaladMediumD.Checked == true)
                {
                    SaladPrice = 200;
                    SaladL.Add(rdbtnSaladMediumD.Text);
                    SaladPriceL.Add(SaladPrice);
                    GrandTotal += SaladPrice;
                    GrandTotalMaker();
                    ReciptGridM.Rows.Add(SNO, chkSaladD.Text + rdbtnSaladMediumD.Text, SaladPrice);
                }
                else if (rdbtnSaladLargeD.Checked == true)
                {
                    SaladPrice = 300;
                    SaladL.Add(rdbtnSaladLargeD.Text);
                    SaladPriceL.Add(SaladPrice);
                    GrandTotal += SaladPrice;
                    GrandTotalMaker();
                    ReciptGridM.Rows.Add(SNO, chkSaladD.Text + rdbtnSaladLargeD.Text, SaladPrice);
                }
            }
        }
        //-----------------------------//

        private void GrandTotalMaker()
        {
            lblTotalD.Text = GrandTotal.ToString();
        }

    }
}
