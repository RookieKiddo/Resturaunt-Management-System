using System;

namespace Pizza_Hut_App
{
    class Decryption
    {
        public Decryption()
        {
            //Constructor//
        }

        public string Decrypt(string Arr)
        {
            char[] ch = Arr.ToCharArray();
            for (int i = 0; i < ch.Length; i++)
            {
                ch[i] = --ch[i];
            }
            return new string(ch);
        }
    }
}
