using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FindWords.Utillity
{
    public static class Sort
    {
        public static string[] mergeSort(string[] array)
        {
            string[] left;
            string[] right;
            string[] result = new string[array.Length];
            
            if (array.Length <= 1)
            {
                return array;
            }
            int midPoint = array.Length / 2;
            left = new string[midPoint];
            if (array.Length % 2 == 0)
            {
                right = new string[midPoint];
            }
            else
            {
                right = new string[midPoint + 1];
            }
                
            for (int i = 0; i < midPoint; i++)
            {
                left[i] = array[i];
            }  

            int x = 0;

            for (int i = midPoint; i < array.Length; i++)
            {
                right[x] = array[i];
                x++;
            }

            left = mergeSort(left);
            right = mergeSort(right);
            result = merge(left, right);
            return result;
        }

        //This method will be responsible for combining our two sorted arrays into one giant array
        public static string[] merge(string[] left, string[] right)
        {
            int resultLength = right.Length + left.Length;
            string[] result = new string[resultLength];
            int indexLeft = 0, indexRight = 0, indexResult = 0;

            while (indexLeft < left.Length || indexRight < right.Length)
            {  
                if (indexLeft < left.Length && indexRight < right.Length)
                {
                    if (left[indexLeft].CompareTo(right[indexRight]) <= 0)
                    {
                        result[indexResult] = left[indexLeft];
                        indexLeft++;
                        indexResult++;
                    }
                    else
                    {
                        result[indexResult] = right[indexRight];
                        indexRight++;
                        indexResult++;
                    }
                }
                else if (indexLeft < left.Length)
                {
                    result[indexResult] = left[indexLeft];
                    indexLeft++;
                    indexResult++;
                }
                else if (indexRight < right.Length)
                {
                    result[indexResult] = right[indexRight];
                    indexRight++;
                    indexResult++;
                }
            }
            return result;
        }
    }
}
