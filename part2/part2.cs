//Naama Holzer 322277724
//Kayla Nayman 341438992
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Program
    {
        public static void addDay(ref int day, ref int month)
        {
            if (day != 31)
                day++;
            else
            {
                day = 1;
                month++;
            }
        }

        public static void addReservation(ref bool[,] matrix)
        {
            Console.WriteLine("Enter date and length of stay");
            string date = System.Console.ReadLine();
            string length = System.Console.ReadLine();
            int fixLength = Int32.Parse(length);
            int day = Int32.Parse(new string(date[0], 1)) * 10 + Int32.Parse(new string(date[1], 1));
            int month = Int32.Parse(new string(date[3], 1)) * 10 + Int32.Parse(new string(date[4], 1));
            int sum = 0;
            bool flag = true;
            int origDay = day, origMonth = month;
            if (matrix[month, day] == true)
            {
                sum++;
                addDay(ref day, ref month);
                if (matrix[month, day] == true)
                {
                    Console.WriteLine("Request Denied");
                    return;
                }
            }
            while (sum < (fixLength - 1) && flag)
            {
                if (matrix[month, day] == false)
                {
                    sum++;
                    addDay(ref day, ref month);
                }
                else
                    flag = false;
            }
            if (!flag)
            {
                Console.WriteLine("Request Denied\n");

            }
            else
            {
                Console.WriteLine("Request accepted\n");
                for (int i = 0; i < fixLength; i++)
                {
                    matrix[origMonth, origDay] = true;
                    addDay(ref origDay, ref origMonth);
                }
            }
        }

        public static void displayOccupancy(bool[,] matrix)
        {
            int checkDay = 1, checkMonth = 1;
            int counter = 1;
            while (counter != 371)
                if (matrix[checkMonth, checkDay])
                {
                    Console.Write("{0}.{1}-", checkDay, checkMonth);
                    while (matrix[checkMonth, checkDay])
                    {
                        addDay(ref checkDay, ref checkMonth);
                        counter++;
                    }
                    if (checkDay != 1)
                        checkDay--;
                    else
                    {
                        checkDay = 31;
                        checkMonth--;
                    }

                    Console.WriteLine("{0}.{1}\n", checkDay, checkMonth);
                    addDay(ref checkDay, ref checkMonth);
                }
                else
                {
                    addDay(ref checkDay, ref checkMonth);
                    counter++;
                }
        }

        public static void displaySumandPerc(bool[,] matrix)
        {
            int sum = 0;

            for (int i = 1; i < 12; i++)
                for (int j = 1; j < 32; j++)
                {
                    if (matrix[i, j])
                        sum++;
                }
            float percentage = ((float)(sum) / 372) * 100;
            Console.WriteLine("Total days occupied: {0}\n", sum);
            Console.WriteLine("Percentage of occupancy: {0}\n", percentage);
        }


        static void Main(string[] args)
        {
            bool[,] matrix = new bool[13, 32];
            for (int i = 1; i < 13; i++)
                for (int j = 1; j < 32; j++)
                    matrix[i, j] = false;
            int intAnswer = 0;
            do
            {
                Console.WriteLine("Menu\n");
                Console.WriteLine("Choose one of the following:\n");
                Console.WriteLine("1: Book a new stay\n");
                Console.WriteLine("2: Display yearly occupancy\n");
                Console.WriteLine("3: Display number of occupied days a year and the yearly occupancy percentage\n");
                Console.WriteLine("4: Exit\n");
                string answer = System.Console.ReadLine();
                intAnswer = Int32.Parse(answer);
                switch (intAnswer)
                {
                    case 1:
                        addReservation(ref matrix);
                        break;
                    case 2:
                        displayOccupancy(matrix);
                        break;
                    case 3:
                        displaySumandPerc(matrix);
                        break;
                    case 4:
                        break;
                    default:
                        Console.WriteLine("ERROR");
                        break;
                }
            } while (intAnswer != 4);
        }
    }
}
//Menu

//Choose one of the following:

//1: Book a new stay

//2: Display yearly occupancy

//3: Display number of occupied days a year and the yearly occupancy percentage

//4: Exit

//1
//Enter date and length of stay
//28.01
//6
//Request accepted

//Menu

//Choose one of the following:

//1: Book a new stay

//2: Display yearly occupancy

//3: Display number of occupied days a year and the yearly occupancy percentage

//4: Exit

//1
//Enter date and length of stay
//02.02
//3
//Request accepted

//Menu

//Choose one of the following:

//1: Book a new stay

//2: Display yearly occupancy

//3: Display number of occupied days a year and the yearly occupancy percentage

//4: Exit

//1
//Enter date and length of stay
//10.06
//10
//Request accepted

//Menu

//Choose one of the following:

//1: Book a new stay

//2: Display yearly occupancy

//3: Display number of occupied days a year and the yearly occupancy percentage

//4: Exit

//2
//28.1-4.2

//10.6-19.6

//Menu

//Choose one of the following:

//1: Book a new stay

//2: Display yearly occupancy

//3: Display number of occupied days a year and the yearly occupancy percentage

//4: Exit

//3
//Total days occupied: 18

//Percentage of occupancy: 4.838709

//Menu

//Choose one of the following:

//1: Book a new stay

//2: Display yearly occupancy

//3: Display number of occupied days a year and the yearly occupancy percentage

//4: Exit

