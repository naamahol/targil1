﻿//Kayla Nayman 341438992 and Naama Holzer 322277724
//This program makes 2 arrays of random numbers between 18-122 and creates a 3rd array that contains the differences between the elements in the first 2 arrays.
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dotNet5780_01_7724_8992
{
    class part1
    {
        static void Main(string[] args)
        {
            Random rand = new Random(DateTime.Now.Millisecond);
            //Creating and initializing the first 2 arrays.
            int[] A = new int[20];
            int[] B = new int[20];
            for (int i = 0; i < 20; i++)
            {
                A[i] = rand.Next(18, 122);
                B[i] = rand.Next(18, 122);
            }
            //Creating the 3rd array.
            int[] C = new int[20];
            for (int j = 0; j < 20; j++)
            {
                C[j] = Math.Abs(A[j] - B[j]);
            }
            //Printing the arrays
            for (int k = 0; k < 19; k++)
            {
                Console.Write("{0,-3} ", A[k]);
            }
            Console.WriteLine("{0,-3} ", A[19]);
            for (int k = 0; k < 19; k++)
            {
                Console.Write("{0,-3} ", B[k]);
            }
            Console.WriteLine("{0,-3} ", B[19]);
            for (int k = 0; k < 19; k++)
            {
                Console.Write("{0,-3} ", C[k]);
            }
            Console.WriteLine("{0,-3} ", C[19]);
        }
    }
}
