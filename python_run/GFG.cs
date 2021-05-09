// C# implementation for above approach
using System;
using System.Collections.Generic;
using System.Linq;

namespace python_run
{
    class GFG
    {
        // Convert the number to Lth
        // base and print the sequence
        static IEnumerable<string> convert_To_Len_th_base(int n, string[] arr,
                                           int len, int L)
        {
            // Sequence is of length L
            for (int i = 0; i < L; i++)
            {
                // Print the ith element
                // of sequence
                yield return arr[n % len];
                n /= len;
            }
        }

        // Print all the permuataions
        public static IEnumerable<List<string>> permutations(string[] arr, int len, int L)
        {
            // There can be (len)^l
            // permutations
            for (int i = 0;
                    i < (int)Math.Pow(len, L); i++)
            {
                // Convert i to len th base
                yield return convert_To_Len_th_base(i, arr, len, L).ToList();
            }
        }

        // Driver code
        // public static void test(String[] args)
        // {
        //     int[] arr = { 1, 2, 3 };
        //     int len = arr.Length;
        //     int L = 2;

        //     // function call
        //     print(arr, len, L);
        // }
    }
}

// This code is contributed by Rajput-Ji