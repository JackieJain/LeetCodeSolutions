using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public class MyClass
    {
        static MyClass()
        {
            // Static constructor logic here
            Console.WriteLine("Static constructor called.");
        }


        public static void DisplayMessage()
        {
            Console.WriteLine("Static method called.");
        }

        public void reverseNumber()
        {
            Console.WriteLine("Enter a number to reverse");
            var number = Console.ReadLine();
            var numArr = number.ToArray();
            string revNum = "";
            for (int i = 0; i < numArr.Length; i++)
            {
                revNum += numArr[(numArr.Length - 1) - i];
            }
            Console.WriteLine("Your reversed number is :" + revNum);
        }

        public static int RomanToInt(string s)
        {
            Dictionary<char, int> romanNumber = new Dictionary<char, int>();
            romanNumber.Add('I', 1);
            romanNumber.Add('V', 5);
            romanNumber.Add('X', 10);
            romanNumber.Add('L', 50);
            romanNumber.Add('C', 100);
            romanNumber.Add('D', 500);
            romanNumber.Add('M', 1000);
            var romanArr = s.ToArray();
            int number = 0;
            int prevVal = 0;
            foreach (var a in romanArr)
            {
                if (prevVal != 0)
                {
                    if (prevVal < romanNumber[a])
                    {
                        //number -= prevVal;
                        number += romanNumber[a] - prevVal;
                        number -= romanNumber[a];
                    }
                    else
                    {
                        number += prevVal;
                    }
                }
                prevVal = romanNumber[a];
            }
            number += romanNumber[romanArr.Last()];
            return number;
        }

        public static int LengthOfLongestSubstring(string s)
        {
            var arr = s.ToArray();
            List<char> list = new List<char>();
            int substrlength = 0;
            int longestsubstr = 0;

            foreach (var item in arr)
            {

                if (list.IndexOf(item) != -1)
                {
                    substrlength = substrlength - (list.IndexOf(item) + 1);
                    list.RemoveRange(0, (list.IndexOf(item) + 1));
                }
                substrlength++;
                longestsubstr = longestsubstr < substrlength ? substrlength : longestsubstr;
                list.Add(item);
            }
            return longestsubstr;
        }

        public static int[] SearchRange(int[] nums, int target)
        {
            if (Array.IndexOf(nums, target) != -1)
            {
                int start = Array.IndexOf(nums, target);
                int[] startend = new int[2];
                startend[0] = start;
                for (int i = start; i < nums.Length; i++)
                {
                    if (nums[i] == target)
                    {
                        startend[1] = i;
                    }
                }
                return startend;

            }
            return new int[] { -1, -1 };
        }


        public static string ZigZagConversion(string s, int numRows)
        {
            List<string> list = new List<string>();
            var sArr = s.ToArray();
            int sArrIndex = 0;
            int prepostcheck = 0;

            int listIndex = 0;
            for (int i = 0; sArrIndex < sArr.Length; i++)
            {
                if (prepostcheck % 2 == 0)
                {
                    while (listIndex < numRows && sArr.Length > sArrIndex)
                    {
                        if (i == 0)
                        {
                            list.Add(sArr[sArrIndex].ToString());
                        }
                        else
                        {
                            list[listIndex] += sArr[sArrIndex];
                        }

                        sArrIndex++;
                        listIndex++;
                    }
                    listIndex -= 2;
                }
                else
                {
                    while (listIndex > 0 && sArr.Length > sArrIndex)
                    {
                        list[listIndex] += sArr[sArrIndex];

                        sArrIndex++;
                        listIndex--;
                    }
                }
                prepostcheck++;
            }

            string zigzagStr = "";
            for (int j = 0; j < numRows; j++)
            {
                zigzagStr += list[j];
            }
            return zigzagStr;
        }

        public static void Main()
        {
            // Console.WriteLine(RomanToInt("MCMXCIV"));
            // LengthOfLongestSubstring("abcabcbb");
            //var result = SearchRange(new int[] { 1 }, 1);
            //Console.WriteLine(string.Join(",", result));
            var result = ZigZagConversion("A", 2);
            Console.WriteLine(result);
            Thread.Sleep(10000);
        }
    }

}
