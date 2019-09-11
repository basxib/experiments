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
                var x = 'a' - 'b';
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


         public static int GetUnique(IEnumerable<int> numbers) => numbers.GroupBy(y=>y).First(x=>x.Count() == 1).First();
            
        public static int[] FoldArray(int[] array, int runs)
         {
             if(array.Length == 1 || runs == 0)
                return array;
            var marker = (array.Length % 2) == 0?array.Length/2:(array.Length - 1) / 2;
            

            int j = array.Length-1;
            List<int> res = new List<int>();
            for(int i=0; i< marker; i++)
            {
                res.Add(array[i]+array[j]);
                j--;

            }
            if(array.Length% 2 != 0)
                res.Add(array[marker]);
            return FoldArray(res.ToArray(), runs-1);
        }
        static void Main(string[] args)
        {
            FoldArray(new int[] { 1, 2, 3, 4, 5 }, 1);

            Console.WriteLine(TrailingZeros(25));
        }
    }
}
