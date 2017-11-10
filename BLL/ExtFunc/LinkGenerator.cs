using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.ExtFunc
{
    //Generate random link class
    public static class LinkGenerator
    {
        //char list for generating
        private static readonly char[] charList;
 
        //add standard azAZ09 chars to list
        static LinkGenerator()
        {
            //a-zA-Z0-9 char array length
            charList = new char[26*2+10];
            
            int i = 0;

            //add 0-9
            while(i!=10)
            {
                charList[i] = i.ToString()[0];
                i++;
            }

            char ch;

            //add a-z
            for(ch = 'a';ch<='z';ch++)
            {
                charList[i] = ch;
                i++;
            }

            //add A-Z
            for (ch = 'A'; ch <= 'Z'; ch++)
            {
                charList[i] = ch;
                i++;
            }
        }

        //Random
        private static Random rand = new Random();

        //Generate random link
        public static String Generate(int linkLenght)
        {           
            StringBuilder sBuilder = new StringBuilder();

            int index;            

            for (int i = 0; i < linkLenght;i++)
            {
                index = rand.Next(charList.Length);

                //append to result string from char array
                sBuilder.Append(charList[index]);
            }

            return sBuilder.ToString();
        }
    }
}
