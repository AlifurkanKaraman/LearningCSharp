using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Learning.ExceptionLearning
{
    internal class ThrowExceptionPart3
    {
        public void Learn()
        {
            // Prompt the user for the lower and upper bounds
            Console.Write("Enter the lower bound: ");
            int lowerBound = int.Parse(Console.ReadLine());

            Console.Write("Enter the upper bound: ");
            int upperBound = int.Parse(Console.ReadLine());

            decimal averageValue = 0;
            bool exit = false;

            // Calculate the sum of the even numbers between the bounds
            do
            {
                try
                {
                    averageValue = AverageOfEvenNumbers(lowerBound, upperBound);
                    Console.WriteLine($"The average of even numbers between {lowerBound} and {upperBound} is {averageValue}.");
                    exit = true;
                }
                catch (ArgumentOutOfRangeException ex)
                {
                    Console.WriteLine("An error has occurred.");
                    Console.WriteLine(ex.Message);
                    Console.WriteLine($"The upper bound must be greater than {lowerBound}");
                    Console.Write($"Enter a new upper bound: ");
                    string? userResponse = Console.ReadLine();
                    if (userResponse.ToLower().Contains("exit"))
                    {
                        exit = true;
                    }
                    else
                    {
                        upperBound = int.Parse(userResponse);
                    }
                }
            } while (exit == false);

            // Display the value returned by AverageOfEvenNumbers in the console

            // Wait for user input
            Console.ReadLine();

            static decimal AverageOfEvenNumbers(int lowerBound, int upperBound)
            {
                if (lowerBound >= upperBound)
                {
                    throw new ArgumentOutOfRangeException("upperBound", "ArgumentOutOfRangeException: upper bound must be greater than lower bound.");
                }
                int sum = 0;
                int count = 0;
                decimal average = 0;

                for (int i = lowerBound; i <= upperBound; i++)
                {
                    if (i % 2 == 0)
                    {
                        sum += i;
                        count++;
                    }
                }

                average = (decimal)sum / count;

                return average;
            }
        }
    }
}
