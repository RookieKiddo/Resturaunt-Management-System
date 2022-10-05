using System;

namespace Pizza_Hut_App
{
    class Encrption
    {
        public Encrption()
        {
            //Constructor//
        }

        //Method To Encrypt The Data//
        public string Encrypt(string Data)
        {
            char[] ch = Data.ToCharArray();
            for (int i = 0; i < ch.Length; i++)
            {
                ch[i] = ++ch[i];
            }
            return new string(ch);
        }    
    }
}
