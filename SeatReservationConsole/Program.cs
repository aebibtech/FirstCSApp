using System;
using System.Threading;

namespace SeatReservationConsole
{
    class Program
    {
        static int numSeats;
        static int[] seatNumbers;
        static void Main(string[] args)
        {
            numSeats = GetNumberOfSeats();
            seatNumbers = initArray();
            while (true)
            {
                int choice;

                choice = GetInput();

                if (seatNumbers[choice - 1] != 0)
                {
                    seatNumbers[choice - 1] = 0;
                    Console.WriteLine($"Seat {choice} is reserved successfully.");
                }
                else
                {
                    Console.WriteLine("Seat is taken.");
                }
                Clear();
            }
        }

        static void DisplaySeats()
        {
            Console.WriteLine("************************************");
            Console.WriteLine("Seat Reservation Program");
            Console.WriteLine("\nAvailable Seats (X = taken)");
            for(int i = 0; i < seatNumbers.Length; i++)
            {
                if (seatNumbers[i] != 0)
                {
                    Console.Write(seatNumbers[i] + "\t");
                }
                else
                {
                    Console.Write("X\t");
                }
                if ((i + 1) % 10 == 0)
                {
                    Console.WriteLine();
                }
            }
            Console.Write("\nSelect a seat number: ");
        }

        static int GetInput()
        {
            int choice = 0;
            try
            {
                DisplaySeats();
                choice = Convert.ToInt32(Console.ReadLine());
                if(choice < 1 || choice > numSeats)
                {
                    Console.WriteLine($"Invalid seat choice. Enter a number from 1 to {numSeats}.\n");
                    Clear();
                    choice = GetInput();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message + $"\nEnter a number. Valid values are 1 up to {numSeats}.\n");
                Clear();
                choice = GetInput();
            }
            return choice;
        }

        static int[] initArray()
        {
            int[] arr = new int[numSeats];
            int number = 1;
            for(int i = 0; i < numSeats; i++)
            {
                arr[i] = number;
                number++;
            }
            return arr;
        }

        static int GetNumberOfSeats()
        {
            int num = 0;
            try
            {
                Console.Write("Number of seats: ");
                num = Convert.ToInt32(Console.ReadLine());
                if(num < 1)
                {
                    Console.WriteLine("Enter a number greater than 1.\n");
                    num = GetNumberOfSeats();
                }
            }
            catch (FormatException e)
            {
                Console.WriteLine($"{e.Message}\n");
                num = GetNumberOfSeats();
            }
            return num;
        }

        static void Clear()
        {
            Thread.Sleep(1200);
            Console.Clear();
        }
    }
}
