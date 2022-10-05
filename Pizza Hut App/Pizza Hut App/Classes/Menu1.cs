using System;
using System.Collections.Generic;
using System.IO;

namespace Pizza_Hut_App.Classes
{
    class Menu1
    {        
        public static string[] drinkName = new string[50]; //Sending The Drink Name To MenuForm//
        public static string[] Drinkprice = new string[50]; //Sending The Drink Price To MenuForm//
        public int DrinkLength = 0; //Sending The File Length To MenuForm//

        //Getting The Drinks Name From File//
        public void Drink()
        {
            string sentence;
            string[] Arr;
            StreamReader SW = new StreamReader(@"Menu/Drink.txt");
            sentence = SW.ReadLine();
            for (int i = 0; sentence != null; i++)
            {
                Arr = sentence.Split('=');
                drinkName[i] = Arr[0];
                Drinkprice[i] = Arr[1];
                sentence = SW.ReadLine();
                DrinkLength = i;
            }            
            SW.Close();
        }
        //------------------------------//
    }
}
