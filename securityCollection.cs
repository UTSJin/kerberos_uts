using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Threading.Tasks;

namespace WindowsFormsApplication1
{
    public class securityCollection
    {

        Color ncolor;

        public securityCollection()
        {
            
        }

        public string encryption(string input, tableCollection tc, string key, Form1 f)
        {

            /* 1. Get plaintext
             * 2. divide message with 64(Because blocks should be 64bit)
             * 3. get quotient and remainder
             * 4. if the remainder is 0 the message size will be quotient
             * 5. if the remainder is not 0 
             * 6. the message size will be quotient + 1, and the last block will be padded with zero as much total 64 bit
             * 7. if the remainder is 0
             * 8. for loop encryption as much quotient times.
             * 9. and append all the message chunks.
             * 10. if the remainder is not zero
             * 9. make last chunk as 64 bit size, padding left with 0s.
             * 10.for loop encryption as much quotient -1 times.
             * 11. append all the messages
             * */
            
            string[] messagePart;
            string ciphertext = null; 
            int q = input.Length / 64, r = input.Length % 64; // Get message block size and remainder of the last block
            if (q == 0)
            {
                messagePart = new string[1];
            }
            else
            {
                if (r == 0)
                {
                    messagePart = new string[q];
                }
                else
                {
                    messagePart = new string[q + 1];
                }
            }

            setMessagChunk(messagePart, q, r, input); // Divide message into 64bit blocks
           
            string[] subKey = new string[16];
            
            string leftSt;
            string rightSt;
            string tempRight;
            char[] left = new char[32];
            char[] right = new char[32];
            char[] binMessage = new char[64];
            
            generateKey(key, tc, subKey); // Generate gubkeys for feistel rounds
            printSubKey(subKey, f); 

            for(int j=0; j<messagePart.Length; j++)
            {
                f.printProcess("\nBlock "+(j+1), Color.Navy);
                StringBuilder sb = new StringBuilder();
                StringBuilder sb1 = new StringBuilder();
                string iped = pBoxing(messagePart[j], tc);
                binMessage = iped.ToCharArray();

                for (int i = 0; i < left.Length; i++) // Generate Left half of the message
                {
                    left[i] = binMessage[i];
                }
                for (int k = 0; k < left.Length; k++)
                {
                    sb.Append(left[k].ToString());
                }
                leftSt = sb.ToString();

                for (int i = 0; i < right.Length; i++)//Generate Right half of the message
                {
                    right[i] = binMessage[32 + i];
                }
                for (int k = 0; k < right.Length; k++)
                {
                    sb1.Append(right[k].ToString());
                }
                rightSt = sb1.ToString();

                for (int i = 0; i < 16; i++)
                {
                    tempRight = rightSt;
                    rightSt = feistel(rightSt, i, tc, subKey); // Feistel round, using subkey 1->16
                    leftSt = xor(leftSt, rightSt); 
                    rightSt = leftSt;
                    leftSt = tempRight;
                    
                    printRound(leftSt, rightSt, i, f);//Print left and right per round from 1~16

                }

                iped = rightSt + leftSt;
                iped = ipBoxing(iped, tc);
                ciphertext += iped;
                
            }

            f.printProcess("\nEncryption Result : "+ciphertext,Color.Olive);
            return ciphertext;
         }


        private void printSubKey(string[] subKey, Form1 f)
        {
            int size = subKey.Length;
            Color ncolor = Color.Red;
            f.printProcess("\n ", ncolor);
            for(int i=0; i<size; i++)
            {
                f.printProcess("Subkey " +(i+1)+" : "+" "+  subKey[i], ncolor);
            }
        }

        private void printRound(string left, string right, int i, Form1 f)
        {
            Color ncolor = Color.Navy;
            f.printProcess("Round " + (i+1) + " Left :  " + left +"\t Right : " + right, ncolor);
            
        }

        private void setMessagChunk(string [] messagePart, int q, int r , string input)
        {
            int j = 0;
            if (r == 0)
            {
                if (q == 0)
                {
                    for (int k = 0; k < 64; k++)
                    {
                        messagePart[0] += input[j++];
                    }
                }
                else
                {
                    for (int i = 0; i < q; i++)
                    {
                        for (int k = 0; k < 64; k++)
                        {
                            messagePart[i] += input[j++];
                        }
                    }
                }
            }
            else
            {

                if (q == 0)
                {
                    for (int i = 0; i < 64 - r; i++)
                    {
                        messagePart[0] += "0";
                    }
                    for (int i = 0; i < r; i++)
                    {
                        messagePart[0] += input[j++];
                    }

                }
                else
                {
                    int a = 0;
                    for (a = 0; a < q; a++)
                    {
                        for (int k = 0; k < 64; k++)
                        {
                            messagePart[a] += input[j++];
                        }

                    }

                    for (int i = 0; i < 64 - r; i++)
                    {
                        messagePart[a] += "0";
                    }
                    for (int i = 0; i < r; i++)
                    {
                        messagePart[a] += input[j++];
                    }
                }

            }
        }
        public string decryption(string input, tableCollection tc, string key, Form1 f)
        {
            string leftSt;
            string rightSt;
            string tempRight;
            char[] left = new char[32];
            char[] right = new char[32];
            char[] binMessage = new char[64];
            string[] subKey = new string[16];
            string[] messagePart;
            string ciphertext = null;
            int q = input.Length / 64, r = input.Length % 64;
            if (q == 0)
            {
                messagePart = new string[1];
            }
            else
            {
                if (r == 0)
                {
                    messagePart = new string[q];
                }
                else
                {
                    messagePart = new string[q + 1];
                }
            }
            setMessagChunk(messagePart, q, r, input);
            
            generateKey(key, tc, subKey);
            printSubKey(subKey, f);
            for(int j=0; j<messagePart.Length; j++)
            {
                f.printProcess("\nBlock " + (j + 1), Color.Navy);
                StringBuilder sb = new StringBuilder();
                StringBuilder sb1 = new StringBuilder();
                string iped = pBoxing(messagePart[j], tc);
                binMessage = iped.ToCharArray();
            
                for (int i = 0; i < left.Length; i++)
                {
                    left[i] = binMessage[i];
                }
                for (int k = 0; k < left.Length; k++)
                {
                    sb.Append(left[k].ToString());
                }
                leftSt = sb.ToString();


                for (int i = 0; i < right.Length; i++)
                {
                    right[i] = binMessage[32 + i];
                }
                for (int k = 0; k < right.Length; k++)
                {
                    sb1.Append(right[k].ToString());
                }
                rightSt = sb1.ToString();

                for (int i = 0; i < 16; i++)
                {
                    tempRight = rightSt;
                    rightSt = feistel(rightSt, 15 - i, tc, subKey); // Feistel round, using subkey 16->1(reverse order of encryption)
                    leftSt = xor(leftSt, rightSt);
                    rightSt = leftSt;
                    leftSt = tempRight;
                     
                    printRound(leftSt, rightSt, i, f);//Print left and right per round from 1~16
                }

                iped = rightSt + leftSt;
                iped = ipBoxing(iped,tc);
            
                if(j==messagePart.Length-1)
                {
                    iped=iped.TrimStart(new Char[] { '0' } );
                    iped.PadLeft(iped.Length + 1, '0');
                    
                    int remainder = iped.Length % 8;
                    for (int i = 0; i < 8-remainder; i++ )
                    {
                        iped = "0" + iped;
                    }
                    ciphertext += iped;
                }
                else
                {
                    ciphertext += iped;
                }
            }
            f.printProcess("\nDecryption Result : " + ciphertext, Color.Olive);
            return ciphertext;

        }

        public string feistel(string rightMessage, int i, tableCollection tc, string [] subKey)
        {
            //input is 32bit right message and key order number
            /*1. EXP the 32bit to the 48bit v
             *2. XOR 48bit message and key[i] v
             *3. split to 6bit 8 strings 
             *4. sboxing 6bit to 4bit
             *5. integrate the 4bit 88 strings
             *6. 32bit pboxing
             *7. return
             * */
            string message;


            message = expBoxing(rightMessage, tc);
            message = xor(message, subKey[i]);
            message = sBoxing(message, tc);
            message = pBoxing32(message, tc);


            return message;
        }

         private string expBoxing(string input, tableCollection tc)
        {
             /* change input 32bit into 48 bit message to be used for FEISTEL round
              * 
              * */
            int[] before = new int[input.Length];
            int[] result = new int[48];
            char[] ch = input.ToCharArray(); // string to chararray

            for (int i = 0; i < input.Length; i++)
            {
                before[i] = int.Parse(ch[i].ToString()); // chararray to intarray
            }

            for (int j = 0; j < result.Length; j++)
            {
                int flag = tc.exPbox[j];
                result[j] = before[flag];

            }

            StringBuilder sb = new StringBuilder();
            for (int k = 0; k < result.Length; k++)
            {
                sb.Append(result[k].ToString());// 1111111->011111111
            }


            return sb.ToString();
        }

         private string pBoxing32(string input, tableCollection tc)
         {
             int[] before = new int[input.Length];
             int[] result = new int[input.Length];
             char[] ch = input.ToCharArray(); // string to chararray

             for (int i = 0; i < input.Length; i++)
             {
                 before[i] = int.Parse(ch[i].ToString()); // chararray to intarray
             }

             for (int j = 0; j < input.Length; j++)
             {
                 int flag = tc.pbox32[j];
                 result[flag] = before[j];

             }

             StringBuilder sb = new StringBuilder();
             for (int k = 0; k < result.Length; k++)
             {
                 sb.Append(result[k].ToString());// 1111111->011111111
             }


             return sb.ToString();
         }

        private string sBoxing(string input, tableCollection tc)
         {
             int flag = 0;
            
             char[,] splittedBit = new char[8, 6];
             int[,] sBoxedBit = new int[8, 4];
             string pre;
             string content;
             string[] smallChunk = new string[8];
             string message = null;
             for (int k = 0; k < 8; k++)
             {
                 for (int j = 0; j < 6; j++)
                 {
                     splittedBit[k, j] = input[flag];
                     flag++;

                 }
             }

             for (int k = 0; k < 8; k++)
             {
                 for (int i = 0; i < 4; i++)
                 {
                     pre = splittedBit[k, 0].ToString() + splittedBit[k, 5].ToString();
                     content = splittedBit[k, 1].ToString() + splittedBit[k, 2].ToString() + splittedBit[k, 3].ToString() + splittedBit[k, 4].ToString();
                     sBoxedBit[k, i] = tc.sbox[k, Convert.ToInt64(pre, 2), Convert.ToInt64(content, 2)];
                     smallChunk[k] = Convert.ToString(sBoxedBit[k, i], 2).PadLeft(4, '0');
                 }
             }

             for (int i = 0; i < 8; i++)
             {
                 message += smallChunk[i];
             }
             return message;
         }
        
        private string ipBoxing(string input, tableCollection tc)
        {

            int[] before = new int[input.Length];
            int[] result = new int[input.Length];
            char[] ch = input.ToCharArray(); // string to chararray

            for (int i = 0; i < input.Length; i++)
            {
                before[i] = int.Parse(ch[i].ToString()); // chararray to intarray
            }

            for (int j = 0; j < input.Length; j++)
            {
                int flag = tc.ipbox64[j];
                result[flag] = before[j];

            }

            StringBuilder sb = new StringBuilder();
            for (int k = 0; k < result.Length; k++)
            {
                sb.Append(result[k].ToString());
            }


            return sb.ToString();
        }
        private string pBoxing(string input, tableCollection tc)
        {

            int[] before = new int[input.Length];
            int[] result = new int[input.Length];
            char[] ch = input.ToCharArray(); // string to chararray

            for (int i = 0; i < input.Length; i++)
            {
                before[i] = int.Parse(ch[i].ToString()); // chararray to intarray
            }

            for (int j = 0; j < input.Length; j++)
            {
                int flag = tc.pbox64[j];
                result[flag] = before[j];

            }

            StringBuilder sb = new StringBuilder();
            for (int k = 0; k < result.Length; k++)
            {
                sb.Append(result[k].ToString());
            }


            return sb.ToString();
        }
       

        public string getBit(string st)
        {
            StringBuilder bitstring = new StringBuilder();
            foreach (byte bit in Encoding.ASCII.GetBytes(st))
            {
                bitstring.Append(Convert.ToString(bit, 2).PadLeft(8, '0'));// 1111111->011111111
            }
            return bitstring.ToString();
        }

        public string getCharString(string bittext)
        {
            List<Byte> byteList = new List<Byte>();

            for (int i = 0; i < bittext.Length; i += 8)
            {
                  byteList.Add(Convert.ToByte(bittext.Substring(i, 8), 2)); ;
               
            }

            return Encoding.ASCII.GetString(byteList.ToArray());
        }
        private string xor(string left, string right)
        {
            int[] le = new int[left.Length];


            for (int i = 0; i < left.Length; i++)
            {
                le[i] = (((int)left[i] - 48) ^ ((int)right[i] - 48));
            }
            StringBuilder sb = new StringBuilder();
            for (int j = 0; j < left.Length; j++)
            {
                sb.Append(le[j].ToString());
            }

            return sb.ToString();
        }
        private string shift(string input)
        {
            char[] ch = new char[input.Length];
            char temp;
            int flag;

            for (int i = input.Length - 1; i >= 0; i--)
            {
                ch[i] = input[i];
            }
            temp = ch[0];
            for (flag = 0; flag < ch.Length - 1; flag++)
            {
                ch[flag] = ch[flag + 1];
            }
            ch[flag] = temp;

            StringBuilder sb = new StringBuilder();
            for (int j = 0; j < input.Length; j++)
            {
                sb.Append(ch[j]);
            }

            return sb.ToString();
        }
        
        public void generateKey(string key, tableCollection tc,  string[] subKey)
        {
            //1. get key 64bit
            //2. pc1
            //3. left shift
            //4. combine
            //5. pc2
            //6. store in subkey array

            char[] left = new char[28];
            char[] right = new char[28];
            char[] binKey = new char[key.Length]; // 64bit key to array

            string firstPCed; // 56bit key
            string secondPCed;
            string leftSt;
            string rightSt;

            key = getBit(key); // 64bit key
            binKey = key.ToCharArray();//64bit key array

            firstPCed = firstPC1(key, tc);

            for (int i = 0; i < left.Length; i++)
            {
                left[i] = binKey[i];
            }

            StringBuilder sb = new StringBuilder();
            for (int k = 0; k < left.Length; k++)
            {
                sb.Append(left[k].ToString());
            }
            leftSt = sb.ToString();


            for (int i = 0; i < right.Length; i++)
            {
                right[i] = binKey[right.Length + i];
            }
            StringBuilder sb1 = new StringBuilder();
            for (int k = 0; k < right.Length; k++)
            {
                sb1.Append(right[k].ToString());
            }
            rightSt = sb1.ToString();

            for (int i = 0; i < 16; i++)// Subkey 0,1,8,15 will have one left shift, the others will have two time left shift
            {
                if (i == 0 || i == 1 || i == 8 || i == 15) 
                {
                    leftSt = shift(leftSt);
                    rightSt = shift(rightSt);
                    firstPCed = leftSt + rightSt;
                    secondPCed = secondPC2(firstPCed, tc);
                    
                    subKey[i] = secondPCed;
                }
                else
                {
                    leftSt = shift(leftSt);
                    leftSt = shift(leftSt);
                    rightSt = shift(rightSt);
                    rightSt = shift(rightSt);
                    firstPCed = leftSt + rightSt;
                    secondPCed = secondPC2(firstPCed, tc);
                    
                    subKey[i] = secondPCed;
                }

            }
        }
        
        
        private string firstPC1(string key, tableCollection tc)
        {
            char[] binKey = new char[key.Length];
            char[] ch = new char[56];
            key = getBit(key); // 64bit key
            binKey = key.ToCharArray();//64bit key array

            for (int i = 0; i < 56; i++)
            {
                int flag = tc.pc1[i];
                ch[i] = binKey[flag];
            }

            StringBuilder sb = new StringBuilder();
            for (int k = 0; k < ch.Length; k++)
            {
                sb.Append(ch[k].ToString());
            }
            return sb.ToString();
        }
        private string secondPC2(string key, tableCollection tc)
        {
            char[] binKey = new char[key.Length];
            char[] ch = new char[48];
            key = getBit(key); // 64bit key
            binKey = key.ToCharArray();//64bit key array

            for (int i = 0; i < 48; i++)
            {
                int flag = tc.pc2[i];
                ch[i] = binKey[flag];
            }

            StringBuilder sb = new StringBuilder();
            for (int k = 0; k < ch.Length; k++)
            {
                sb.Append(ch[k].ToString());
            }
            return sb.ToString();
        }
        
    }
}
