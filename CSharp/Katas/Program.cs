using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
namespace CSharp
{
    class Program
    {
        public static string IsSortedAndHow(int[] array)
        {
            bool asc = true;
            for(int i=1; i< array.Length ;i++)
            {
            if(array[i] > array[i-1] && asc)
                continue;
            else if(array[i] > array[i-1] && !asc && i >1)
                return "no";
            else if(array[i] < array[i-1] && asc && i> 1)
                return "no";
            else if(array[i] < array[i-1])
                asc = false;
            }
            if(asc) return "yes, ascending"; else return "yes, descending";
        }
        public static int TrailingZeros(int n)
        {
            ulong fact = 1;
            for(int i = 1; i<= n; i++)
            {
                fact = fact * (UInt64)i;
            }
            var s = fact.ToString().Reverse();
            int count = 0;
            foreach(var c in s)
            {
                if(c=='0')
                    count++;
                else 
                    break;
            }
            return count;
        }
        public static char FindMissingLetter(char[] array)
        {
            string alpha2 = "abcdefghijklmnopqrstuvwxyz";
            var array2 =  new string(array);
            if(Char.IsUpper(array[0]))
            {
                alpha2 = alpha2.ToUpper();
                array2= array2.ToUpper();
            }
            var firstCharIndex = alpha2.IndexOf(array2[0]);
            var subAlpha = alpha2.Substring(firstCharIndex,array2.Length);
            for(int i = 0; i< alpha2.Length; i++)
            {
                if(subAlpha[i]!=array2[i])
                    return subAlpha[i];
            }
            return ' ';
        }
         
            
        static void Main(string[] args)
        {
            var s = FindMissingLetter(new [] { 'a','b','c','d','f' });
            Console.WriteLine(s);
            Console.WriteLine(TrailingZeros(25));
        }
    }
}
