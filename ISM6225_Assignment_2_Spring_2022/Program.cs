using System;
using System.Collections.Generic;

namespace ISM6225_Assignment_2_Spring_2022
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Question 2");
            string paragraph = "Bob hit a ball, the hit BALL flew far after it was hit.";
            string[] banned = { "hit" };
            string commonWord = MostCommonWord(paragraph, banned);
            //Console.WriteLine("Most frequent word is {0}:", commonWord);
            Console.WriteLine();
        }
        
        public static string MostCommonWord(string paragraph, string[] banned)
        {
            try
            {
                //write your code here.
                paragraph = paragraph.ToLower();
                if(paragraph == banned)
                Console.WriteLine(paragraph);

                return "";
            }
            catch (Exception)
            {

                throw;
            }
        }

    }
}