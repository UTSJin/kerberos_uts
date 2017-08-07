using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApplication1
{
    public class tableCollection
    {
        public int[] pbox64 = new int[64]; //pbox table: used for Initial Pbox;
        public int[] ipbox64 = new int[64];//Inversion pbox table: initial last pbox;
        public int[] exPbox = new int[48]; //Expansion Pbox 32bit to 48bit
        public int[] pc1 = new int[56];    // Permutation choice table1 64bit to 56bit
        public int[] pc2 = new int[48];    // permutation choice table2 56bit to 48bit
        public int[, ,] sbox = new int[8, 4, 16]; // Sbox for 6bit(48bit) chunk to 4bit(32bit)
        public int[] pbox32 = new int[32];  //Pbox table: to be used in feistel procedure
        
        public int[] tempBox64 = new int[64];
        public int[] tempPC1 = new int[56];
       
        private Random r = new Random();
        
        public tableCollection()
        {
            setPbox64(); // Used in Encryption and Decryption
            setIPbox64();// Used in Encryption and Decryption
            
            setPbox32(); // Used in Feistel
            setEXPbox(); // Used in Feistel 32->48
            
            setSbox();   // Used in Feistel 48->32
            setPC1();    //Used in Subkey Generation
            setPC2();    //Used in Subkey Generation
        }

        private void setPbox32()
        {
            for (int i = 0; i < pbox32.Length; i++)
            {
                int k = r.Next(0, pbox32.Length);

                if (i == 0)
                {
                    pbox32[i] = k;
                }
                else
                {
                    while (condition(i, k) == 1)
                    {
                        k = r.Next(0, pbox32.Length);
                    }
                    pbox32[i] = k;
                }

            }
        }
        private void setIPbox64()
        {
            for (int t = 0; t < pbox64.Length; t++)
            {
                int flag = pbox64[t];
                ipbox64[flag] = t;
            }
        }
        private void setPbox64()
        {
            for (int i = 0; i < pbox64.Length; i++)
            {
                int k = r.Next(0, pbox64.Length);

                if (i == 0)
                {
                    pbox64[i] = k;
                }
                else
                {
                    while (condition(i, k) == 1)
                    {
                        k = r.Next(0, pbox64.Length);
                    }
                    pbox64[i] = k;
                }

            }
        }
        private void setPC1()
        {


            for (int i = 0; i < tempBox64.Length; i++)
            {
                Random r1 = new Random();
                int k = r1.Next(0, tempBox64.Length);

                if (i == 0)
                {
                    tempBox64[i] = k;
                }
                else
                {
                    while (conditiontemp(i, k) == 1)
                    {
                        k = r1.Next(0, tempBox64.Length);
                    }
                    tempBox64[i] = k;
                }
            }
        }
        private void setPC2()
        {
            setTempPC1();
            Random r1 = new Random();
            for (int i = 0; i < pc2.Length; i++)
            {
                pc2[i] = tempPC1[i];
            }
        }
        private void setEXPbox()
        {
            for (int i = 0; i < exPbox.Length; i++)
            {
                int k = r.Next(0, exPbox.Length - 16);

                if (i == 0)
                {
                    exPbox[i] = k;
                }
                else
                {
                    while (conditionEXP(i, k) == 1)
                    {
                        k = r.Next(0, exPbox.Length - 16);
                    }
                    exPbox[i] = k;
                }

            }
        }
        private void setSbox()
        {
            for (int t = 0; t < 8; t++)
            {
                for (int i = 0; i < 4; i++)
                {
                    for (int j = 0; j < 16; j++)
                    {
                        int k = r.Next(0, 16);
                        if (j == 0)
                        {
                            sbox[t, i, j] = k;
                        }
                        else
                        {
                            while (conditionSbox(t, i, j, k) == 1)
                            {
                                k = r.Next(0, 16);
                            }
                            sbox[t, i, j] = k;
                        }
                    }
                }
            }
        }
        private void setTempPC1()
        {
            Random r1 = new Random();


            for (int i = 0; i < tempPC1.Length; i++)
            {
                int k = r1.Next(0, tempPC1.Length);

                if (i == 0)
                {
                    tempPC1[i] = k;
                }
                else
                {
                    while (conditiontemppc1(i, k) == 1)
                    {
                        k = r1.Next(0, tempPC1.Length);
                    }
                    tempPC1[i] = k;
                }
            }
        }

        private int conditionSbox(int p, int i, int j, int k)
        {
            int flag = 1;
            for (int t = 0; t < j; t++)
            {
                if (sbox[p, i, t] == k)
                {
                    flag = 0;
                }


            }
            if (flag == 0)
                return 1;
            else
                return 0;
        }
        private int condition(int i, int k)
        {
            int flag = 1;
            for (int j = 0; j < i; j++)
            {
                if (pbox64[j] == k)
                {
                    flag = 0;
                }
            }
            if (flag == 0)
                return 1;
            else
                return 0;
        }
        private int conditiontemppc1(int i, int k)
        {
            int flag = 1;
            for (int j = 0; j < i; j++)
            {
                if (tempPC1[j] == k)
                {
                    flag = 0;
                }


            }
            if (flag == 0)
                return 1;
            else
                return 0;
        }
        private int conditiontemp(int i, int k)
        {
            int flag = 1;
            for (int j = 0; j < i; j++)
            {
                if (tempBox64[j] == k)
                {
                    flag = 0;
                }


            }
            if (flag == 0)
                return 1;
            else
                return 0;
        }
        private int conditionEXP(int i, int k)
        {
            int flag = 1;
            if (i < exPbox.Length - 16)
            {
                for (int j = 0; j < i; j++)
                {
                    if (exPbox[j] == k)
                    {
                        flag = 0;
                    }
                   }
            }
            else
            {
                for (int j = exPbox.Length - 16; j < i; j++)
                {

                    if (exPbox[j] == k)
                    {
                        flag = 0;
                    }
                }
            }
            if (flag == 0)
                return 1;
            else
                return 0;
        }
    }
}
