/* 
 
YOU ARE NOT ALLOWED TO MODIFY ANY FUNCTION DEFINATION's PROVIDED.
WRITE YOUR CODE IN THE RESPECTIVE QUESTION FUNCTION BLOCK


*/

using System;
using System.Collections.Generic;

namespace ISM6225_Assignment_2_Spring_2022
{
    class Program
    {
        static void Main(string[] args)
        {

            //Question 1:
            Console.WriteLine("Question 1:");
            int[] nums1 = { 0, 1, 2, 3, 12 };
            Console.WriteLine("Enter the target number:");
            int target = Int32.Parse(Console.ReadLine());
            int pos = SearchInsert(nums1, target);
            Console.WriteLine("Insert Position of the target is : {0}", pos);
            Console.WriteLine("");

            //Question2:
            Console.WriteLine("Question 2");
            string paragraph = "Bob hit a ball, the hit BALL flew far after it was hit.";
            string[] banned = { "hit" };
            string commonWord = MostCommonWord(paragraph, banned);
            Console.WriteLine("Most frequent word is {0}:", commonWord);
            Console.WriteLine();

            //Question 3:
            Console.WriteLine("Question 3");
            int[] arr1 = { 2, 2, 3, 4 };
            int lucky_number = FindLucky(arr1);
            Console.WriteLine("The Lucky number in the given array is {0}", lucky_number);
            Console.WriteLine();

            //Question 4:
            Console.WriteLine("Question 4");
            string secret = "1807";
            string guess = "7810";
            string hint = GetHint(secret, guess);
            Console.WriteLine("Hint for the guess is :{0}", hint);
            Console.WriteLine();


            //Question 5:
            Console.WriteLine("Question 5");
            string s = "ababcbacadefegdehijhklij";
            List<int> part = PartitionLabels(s);
            Console.WriteLine("Partation lengths are:");
            for (int i = 0; i < part.Count; i++)
            {
                Console.Write(part[i] + "\t");
            }
            Console.WriteLine();

            //Question 6:
            Console.WriteLine("Question 6");
            int[] widths = new int[] { 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10 };
            string bulls_string9 = "abcdefghijklmnopqrstuvwxyz";
            List<int> lines = NumberOfLines(widths, bulls_string9);
            Console.WriteLine("Lines Required to print:");
            for (int i = 0; i < lines.Count; i++)
            {
                Console.Write(lines[i] + "\t");
            }
            Console.WriteLine();
            Console.WriteLine();

            //Question 7:
            Console.WriteLine("Question 7:");
            string bulls_string10 = "()[]{}";
            bool isvalid = IsValid(bulls_string10);
            if (isvalid)
                Console.WriteLine("Valid String");
            else
                Console.WriteLine("String is not Valid");

            Console.WriteLine();
            Console.WriteLine();


            //Question 8:
            Console.WriteLine("Question 8");
            string[] bulls_string13 = { "gin", "zen", "gig", "msg" };
            int diffwords = UniqueMorseRepresentations(bulls_string13);
            Console.WriteLine("Number of with unique code are: {0}", diffwords);
            Console.WriteLine();
            Console.WriteLine();

            //Question 9:
            Console.WriteLine("Question 9");
            int[,] grid = { { 0, 1, 2, 3, 4 }, { 24, 23, 22, 21, 5 }, { 12, 13, 14, 15, 16 }, { 11, 17, 18, 19, 20 }, { 10, 9, 8, 7, 6 } };
            int time = SwimInWater(grid);
            Console.WriteLine("Minimum time required is: {0}", time);
            Console.WriteLine();

            //Question 10:
            Console.WriteLine("Question 10");
            string word1  = "horse";
            string word2 = "ros";
            int minLen = MinDistance( word1,  word2);
            Console.WriteLine("Minimum number of operations required are {0}", minLen);
            Console.WriteLine();
        }
    

        /*
        
        Question 1:
        Given a sorted array of distinct integers and a target value, return the index if the target is found. If not, return the index where it would be if it were inserted in order.
        Note: The algorithm should have run time complexity of O (log n).
        Hint: Use binary search
        Example 1:
        Input: nums = [1,3,5,6], target = 5
        Output: 2
        Example 2:
        Input: nums = [1,3,5,6], target = 2
        Output: 1
        Example 3:
        Input: nums = [1,3,5,6], target = 7
        Output: 4
        */

        public static int SearchInsert(int[] nums, int target)
        {
            try
            {
                
                int len = nums.Length;
                int lo, hi;       // boundary variables
                lo = 0;
                hi = len - 1;                
                int mid = (lo + hi) / 2;         // calc mid
                while(lo <= hi){       // boundary condition for BS
                    if(nums[mid] == target)         // if target found, return the index
                        return mid;
                    if(nums[mid] < target)          // Else, trim the search space 
                        lo = mid + 1;
                    else if(nums[mid] > target)
                        hi = mid - 1;
                    mid = (lo + hi) / 2;            // update the mid
                }   
                if(nums[mid] < target)          // this condition means that we haven't found the element in the array: so if the mid is less, then return lo
                    return lo;
                return hi;          
            }
            catch (Exception)
            {
                throw;
            }
        }

        /*
         
        Question 2
       
        Given a string paragraph and a string array of the banned words banned, return the most frequent word that is not banned. It is guaranteed there is at least one word that is not banned, and that the answer is unique.
        The words in paragraph are case-insensitive and the answer should be returned in lowercase.

        Example 1:
        Input: paragraph = "Bob hit a ball, the hit BALL flew far after it was hit.", banned = ["hit"]
        Output: "ball"
        Explanation: "hit" occurs 3 times, but it is a banned word. "ball" occurs twice (and no other word does), so it is the most frequent non-banned word in the paragraph. 
        Note that words in the paragraph are not case sensitive, that punctuation is ignored (even if adjacent to words, such as "ball,"), and that "hit" isn't the answer even though it occurs more because it is banned.

        Example 2:
        Input: paragraph = "a.", banned = []
        Output: "a"
        */

        public static string MostCommonWord(string paragraph, string[] banned)
        {
            try
            {
                
                //write your code here.
                paragraph = paragraph.ToLower();            // change to lower case and remove punctuations
                paragraph = paragraph.Replace(".", "");
                paragraph = paragraph.Replace(",", "");
                
                string[] words = paragraph.Split();         // split to string array

                // dict for mapping words to their frequency in the paragraph
                Dictionary<string, int> dict = new Dictionary<string, int>();

                for (int i = 0; i < words.Length; i++)      // fills/ updates dict
                {
                    if (Array.IndexOf(banned, words[i]) == -1)      // if not a banned word,
                    {
                        if (dict.ContainsKey(words[i]) == true)     // increment frequency in dict
                            dict[words[i]] += 1;
                        else
                            dict.Add(words[i], 1);
                    }
                }

                int mx = -1;
                string str = "";
                foreach (KeyValuePair<string, int> kp in dict)  // for all kps in dict,
                {
                    if (kp.Value >= mx)         // process the maximum val key.
                    {
                        str = kp.Key;
                        mx = kp.Value;
                    }
                }
                return str;     // return the maximum freq word which is not banned.
            }
            catch (Exception)
            {

                throw;
            }
        }

        /*
        Question 3:
        Given an array of integers arr, a lucky integer is an integer that has a frequency in the array equal to its value.
        Return the largest lucky integer in the array. If there is no lucky integer return -1.
 
        Example 1:
        Input: arr = [2,2,3,4]
        Output: 2
        Explanation: The only lucky number in the array is 2 because frequency[2] == 2.

        Example 2:
        Input: arr = [1,2,2,3,3,3]
        Output: 3
        Explanation: 1, 2 and 3 are all lucky numbers, return the largest of them.

        Example 3:
        Input: arr = [2,2,2,3,3]
        Output: -1
        Explanation: There are no lucky numbers in the array.
         */

        public static int FindLucky(int[] arr)
        {
            try
            {
                //write your code here.\

                // dict for mapping integers to their frequency in the array.
                Dictionary<int, int> dict = new Dictionary<int,int>();
		
                for(int i=0;i<arr.Length;i++){  /// fills/updates the dict
                    if(dict.ContainsKey(arr[i]) == true)
                        dict[arr[i]]+=1;
                    else
                        dict.Add(arr[i],1);
                }
                
                int k = -1;
                foreach(KeyValuePair<int, int> kp in dict){   // for each val in the dict
                    if(kp.Value == kp.Key){         // if it's a lucky number, and greater one than prev llucky no, store it
                        if(k < kp.Key)
                            k = kp.Key;
                    }
                }
                return k;       // return the number
            }
            catch (Exception)
            {

                throw;
            }

        }

        /*
        
        Question 4:
        You are playing the Bulls and Cows game with your friend.
        You write down a secret number and ask your friend to guess what the number is. When your friend makes a guess, you provide a hint with the following info:
        •	The number of "bulls", which are digits in the guess that are in the correct position.
        •	The number of "cows", which are digits in the guess that are in your secret number but are located in the wrong position. Specifically, the non-bull digits in the guess that could be rearranged such that they become bulls.
        Given the secret number secret and your friend's guess guess, return the hint for your friend's guess.
        The hint should be formatted as "xAyB", where x is the number of bulls and y is the number of cows. Note that both secret and guess may contain duplicate digits.
 
        Example 1:
        Input: secret = "1807", guess = "7810"
        Output: "1A3B"
        Explanation: Bulls relate to a '|' and cows are underlined:
        "1807"
          |
        "7810"

        */

        public static string GetHint(string secret, string guess)
        {
            try
            {
                //write your code here.
                int len = secret.Length;
		
                // dict for mapping chars to their frequency in the string
                Dictionary<char, int> dict = new Dictionary<char, int>();
                
                for(int i=0;i<len;i++){       // performs the same
                    if(dict.ContainsKey(secret[i]) == true)
                        dict[secret[i]]+=1;
                    else
                        dict.Add(secret[i], 1);
                }
                
                int bulls = 0;
                int cows = 0;
                for(int i=0;i<len;i++){            // calculate the number of bulls: if same char in both string( check in dict), then increment bulls
                    if(secret[i] == guess[i]){
                        bulls++;
                        dict[guess[i]]-=1;      // decrement count so that we dont confuse this with cows
                    }
                }
                for(int i=0;i<len;i++){             // calculate cows: if the char present in main string(check in dict) but not in place, then increment cows
                    if(secret[i] != guess[i]) {
                        if(dict.ContainsKey(guess[i]) == true){
                            if(dict[guess[i]] > 0)
                                cows++;
                        }
                    }
                }
                string result = bulls.ToString() + "A" + cows.ToString() + "B";        // format output and return result
                return result;
            }
            catch (Exception)
            {

                throw;
            }
        }


        /*
        Question 5:
        You are given a string s. We want to partition the string into as many parts as possible so that each letter appears in at most one part.
        Return a list of integers representing the size of these parts.

        Example 1:
        Input: s = "ababcbacadefegdehijhklij"
        Output: [9,7,8]
        Explanation:
        The partition is "ababcbaca", "defegde", "hijhklij".
        This is a partition so that each letter appears in at most one part.
        A partition like "ababcbacadefegde", "hijhklij" is incorrect, because it splits s into less parts.

        */

        public static List<int> PartitionLabels(string s)
        {
            try
            {
                //write your code here.
                List<int> list = new List<int>();
        
                int ind = 0;        // the partitioning index
                int len = s.Length;
                
                int i = 0;
                // dict for mapping chars to their last known position
                Dictionary<char, int> dict = new Dictionary<char, int>();
                int prev = 0;  // for keeping track of last known partition index
                while(i < len){
                    char par = s[i];  // store the first char in this partition
                    for(int j=i;j<len;j++){
                        if(dict.ContainsKey(s[j]) == true){    // if key present,
                            if(s[j] == par || dict[s[j]] <= ind)        // if it's the first char, or the char already present in this partition,
                                ind = j;        // increase the width of the partition
                                
                            dict[s[j]] = j;     // update dict
                        } else {                // else just add to dict
                            dict.Add(s[j], j);
                        }
                    }
                    int entry = ind + 1;        

                    if(i != 0){
                        entry = entry - prev;           // calcs the size of the partition
                    }
                    list.Add(entry);        // add to list

                    i = ind + 1;        // update i to last index of the partition
                    prev = ind + 1;
                }
                return list;
                
            }
            catch (Exception)
            {
                throw;
            }
        }

        /*
        Question 6

        You are given a string s of lowercase English letters and an array widths denoting how many pixels wide each lowercase English letter is. Specifically, widths[0] is the width of 'a', widths[1] is the width of 'b', and so on.
        You are trying to write s across several lines, where each line is no longer than 100 pixels. Starting at the beginning of s, write as many letters on the first line such that the total width does not exceed 100 pixels. Then, from where you stopped in s, continue writing as many letters as you can on the second line. Continue this process until you have written all of s.
        Return an array result of length 2 where:
             •	result[0] is the total number of lines.
             •	result[1] is the width of the last line in pixels.
 
        Example 1:
        Input: widths = [10,10,10,10,10,10,10,10,10,10,10,10,10,10,10,10,10,10,10,10,10,10,10,10,10,10], s = "abcdefghijklmnopqrstuvwxyz"
        Output: [3,60]
        Explanation: You can write s as follows:
                     abcdefghij  	 // 100 pixels wide
                     klmnopqrst  	 // 100 pixels wide
                     uvwxyz      	 // 60 pixels wide
                     There are a total of 3 lines, and the last line is 60 pixels wide.



         Example 2:
         Input: widths = [4,10,10,10,10,10,10,10,10,10,10,10,10,10,10,10,10,10,10,10,10,10,10,10,10,10], 
         s = "bbbcccdddaaa"
         Output: [2,4]
         Explanation: You can write s as follows:
                      bbbcccdddaa  	  // 98 pixels wide
                      a           	 // 4 pixels wide
                      There are a total of 2 lines, and the last line is 4 pixels wide.

         */

        public static List<int> NumberOfLines(int[] widths,string s)
        {
            try
            {
                //write your code here.

                // dictionary for mapping letters to their respective pixels required
                Dictionary<char, int> dict = new Dictionary<char, int>();
		
                for(int i=0;i<widths.Length;i++){           // maps the same
                    dict.Add((char)((int)'a'+i), widths[i]);
                }
                
                int count = 0;      // var for counting the number of pixels we wrote so far
                int lines = 1;       // var for counting lines we wrote so far
                for(int i=0;i<s.Length; i++){
                    if(count + dict[s[i]] > 100){       // if > 100,
                        count = dict[s[i]];             // write to next line and replace count
                        lines++;    
                    }
                    else
                        count = count + dict[s[i]];	        // else, just add to count
                }

                return new List<int>() {lines, count};      // return list of lines and count
            }
            catch (Exception)
            {
                throw;
            }

        }


        /*
        
        Question 7:

        Given a string bulls_string containing just the characters '(', ')', '{', '}', '[' and ']', determine if the input string is valid.
        An input string is valid if:
            1.	Open brackets must be closed by the same type of brackets.
            2.	Open brackets must be closed in the correct order.
 
        Example 1:
        Input: bulls_string = "()"
        Output: true

        Example 2:
        Input: bulls_string  = "()[]{}"
        Output: true

        Example 3:
        Input: bulls_string  = "(]"
        Output: false

        */

        public static bool IsValid(string bulls_string10)
        {
            try
            {
                //write your code here.
                int len = bulls_string10.Length;
		
                int a, b, c;
                a = b = c = 0;      // variables for '(',  '[' , '{' respectively
                for(int i=0;i<len;i++){
                    if(bulls_string10[i] == '(')
                        a++;                            // if open bracket, increment
                    else if(bulls_string10[i] == ')')
                        a--;                                // if closed bracket, decrement
                    else if(bulls_string10[i] == '[')
                        b++;
                    else if(bulls_string10[i] == ']')
                        b--;
                    else if(bulls_string10[i] == '{')
                        c++;
                    else if(bulls_string10[i] == '}')
                        c--;
                }
                if(a == 0 && b == 0 && c == 0)          // if all values are 0, meaning that paranthesis is valid
                    return true;
                return false;                       // else invalid
            }
            catch (Exception)
            {
                throw;
            }


        }



        /*
         Question 8
        International Morse Code defines a standard encoding where each letter is mapped to a series of dots and dashes, as follows:
        •	'a' maps to ".-",
        •	'b' maps to "-...",
        •	'c' maps to "-.-.", and so on.

        For convenience, the full table for the 26 letters of the English alphabet is given below:
        [".-","-...","-.-.","-..",".","..-.","--.","....","..",".---","-.-",".-..","--","-.","---",".--.","--.-",".-.","...","-","..-","...-",".--","-..-","-.--","--.."]
        Given an array of strings words where each word can be written as a concatenation of the Morse code of each letter.
            •	For example, "cab" can be written as "-.-..--...", which is the concatenation of "-.-.", ".-", and "-...". We will call such a concatenation the transformation of a word.
        Return the number of different transformations among all words we have.
 
        Example 1:
        Input: words = ["gin","zen","gig","msg"]
        Output: 2
        Explanation: The transformation of each word is:
        "gin" -> "--...-."
        "zen" -> "--...-."
        "gig" -> "--...--."
        "msg" -> "--...--."
        There are 2 different transformations: "--...-." and "--...--.".

        */

        public static int UniqueMorseRepresentations(string[] words)
        {
            try
            {
                //write your code here.
                // declare morse codes for all 26 alphabets
                string[] morse_codes = {".-","-...","-.-.","-..",".","..-.","--.","....","..",".---","-.-",".-..","--","-.","---",".--.","--.-",".-.","...","-","..-","...-",".--","-..-","-.--","--.."};
                

                // dictionary for mapping letters to their morse codes
                Dictionary<char, string> letters_to_morse = new Dictionary<char, string>();
                
                for(int i=0; i<morse_codes.Length;i++){   // maps letters to morse codes
                    letters_to_morse.Add((char)((int)'a'+i), morse_codes[i]);
                }
                // dict for keeping track of unique morse codes
                Dictionary<string, int> morse_cnt = new Dictionary<string ,int>();
                for(int i=0;i<words.Length;i++){
                    string word = words[i].ToLower();  // convert to lowercase
                    string morse = "";
                    for(int j = 0; j < word.Length; j++)    // concatenate the chars to form the morse code for the respective word
                        morse += letters_to_morse[word[j]];
                    if(morse_cnt.ContainsKey(morse) == true)   // if already present in dict
                        morse_cnt[morse]+=1;
                    else                    // else add the morse code to dictionary: 
                        morse_cnt.Add(morse, 1);	
                }
                return morse_cnt.Count;  // return the number of keys in the dictionary: number of different transformations.
            }
            catch (Exception)
            {
                throw;
            }

        }

      


        /*
        
        Question 9:
        You are given an n x n integer matrix grid where each value grid[i][j] represents the elevation at that point (i, j).
        The rain starts to fall. At time t, the depth of the water everywhere is t. You can swim from a square to another 4-directionally adjacent square if and only if the elevation of both squares individually are at most t. You can swim infinite distances in zero time. Of course, you must stay within the boundaries of the grid during your swim.
        Return the least time until you can reach the bottom right square (n - 1, n - 1) if you start at the top left square (0, 0).

        Example 1:
        Input: grid = [[0,1,2,3,4],[24,23,22,21,5],[12,13,14,15,16],[11,17,18,19,20],[10,9,8,7,6]]
        Output: 16
        Explanation: The final route is shown.
        We need to wait until time 16 so that (0, 0) and (4, 4) are connected.

        */

        public static int SwimInWater(int[,] grid)
        {
            try
            {
               return 0;       
            }
            catch (Exception)
            {

                throw;
            }
        }

        /*
         
        Question 10:
        Given two strings word1 and word2, return the minimum number of operations required to convert word1 to word2.
        You have the following three operations permitted on a word:

        •	Insert a character
        •	Delete a character
        •	Replace a character
         Note: Try to come up with a solution that has polynomial runtime, then try to optimize it to quadratic runtime.

        Example 1:
        Input: word1 = "horse", word2 = "ros"
        Output: 3
        Explanation: 
        horse -> rorse (replace 'h' with 'r')
        rorse -> rose (remove 'r')
        rose -> ros (remove 'e')

        */

        public static int MinDistance(string word1, string word2)
        {
            try
            {
                int p = word1.Length;          // get the size of both the strings
                int q = word2.Length;

                int [,] dp = new int[p+1, q+1];     // declare a 2d array for storing recurring subproblems in dp fashion 

                // each entry in the dp : dp[i,j] represents the min operations req to change the string with len i to string with len j (strings being word1 and word2)

                                                     // iterate through the 2d array and fill values in a bottom up manner
                for(int i=0;i<=p;i++){             
                    for(int j=0;j<=q;j++){
                        if(i == 0 && j == 0)     // if both the lengths of the strings are 0, then we need not change anything so, 0 operations rq
                            dp[i,j] = 0;
                        else if(i == 0)          // if the word1 length is 0, then we have to insert all chars to form word2 so j operations req.
                            dp[i,j] = j;
                        else if(j == 0)         // if the word2 length is 0, then we have to remove all chars from word1, so i operations required.
                            dp[i,j] = i;
                        else if(word1[i-1] == word2[j-1])  // if the last char of both the strings are same, then no ops required to change that char, so the number of 
                            dp[i,j] = dp[i-1, j-1];         // ops required are same as the strings with length - 1.
                        else                                // if both chars are not same, then perform all the three insert, remove, replace operations on word1 and get the
                            dp[i,j] = 1 + Math.Min(dp[i,j-1], Math.Min(dp[i-1,j], dp[i-1, j-1]));  // minimum out of them both.
                    }
                }
                return dp[p,q];       // return the min number of operations required for changing a string of length p to a string of len q.
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
