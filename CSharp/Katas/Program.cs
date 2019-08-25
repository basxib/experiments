﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
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
        static void Main(string[] args)
        {
            var s = IsSortedAndHow(new [] { 2, 1 });
            Console.WriteLine(s);
            Console.WriteLine(TrailingZeros(25));
        }
    }
}