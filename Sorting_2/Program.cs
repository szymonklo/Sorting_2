using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Collections;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.Serialization;
using System.Text.RegularExpressions;
using System.Text;
using System;

class Solution
{

    // Complete the closestNumbers function below.
    static int[] closestNumbers(int[] arr)
    {
        //int[] sorted = insertionSort2(arr);
        int[] sorted = arr.OrderBy(x => x).ToArray();


        List<int> results = new List<int>();
        int minDiff = sorted[1] - sorted[0];
        for (int i = 1; i < sorted.Length - 1; i++)
        {
            int diff = sorted[i + 1] - sorted[i];
            if (diff < minDiff)
            {
                minDiff = diff;
                results = new List<int>() { sorted[i], sorted[i + 1] };
            }
            else if (diff == minDiff)
            {
                results.Add(sorted[i]);
                results.Add(sorted[i + 1]);
            }
        }
        return results.ToArray();
    }

    static int[] insertionSort2(int[] arr)
    {
        int n = arr.Length;
        for (int j = 1; j < n; j++)
        {
            int temp = arr[j];
            for (int i = j - 1; i >= 0; i--)
            {
                if (arr[i] <= temp)
                {
                    arr[i + 1] = temp;
                    break;
                }
                else
                {
                    arr[i + 1] = arr[i];
                    arr[i] = temp;
                }
            }
            //return(arr);
        }
        return (arr);

    }

    static void Main(string[] args)
    {
        //TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

        int n = Convert.ToInt32(Console.ReadLine());

        int[] arr = Array.ConvertAll(Console.ReadLine().Split(' '), arrTemp => Convert.ToInt32(arrTemp))
        ;
        int[] result = closestNumbers(arr);

        Console.WriteLine(string.Join(" ", result));

        //textWriter.Flush();
        //textWriter.Close();
    }
}
