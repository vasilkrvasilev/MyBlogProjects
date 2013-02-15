using System;
using System.Collections.Generic;

class SearchAlgorithms
{
    static int[] GenerateArray(int number)
    {
        Console.WriteLine("Enter the number of elements in the array");
        int elements = int.Parse(Console.ReadLine());

        Console.WriteLine("Enter the min value");
        int downLimit = int.Parse(Console.ReadLine());

        Console.WriteLine("Enter the max value");
        int upperLimit = int.Parse(Console.ReadLine());

        int[] array = new int[elements];
        Random randomGenerator = new Random();

        for (int position = 0; position < elements; position++)
        {
            array[position] = randomGenerator.Next(downLimit + position, upperLimit);
        }

        for (int position = 0; position < elements; position++)
        {
            Console.Write("{0} ", array[position]);
        }

        Console.WriteLine();
        return array;
    }

    static void LinearSearch(int[] array, int number)
    {
        int linearIterations = 0;
        for (int position = 0; position < array.Length; position++)
        {
            linearIterations++;
            if (array[position] == number)
            {
                Console.WriteLine("{0} is the {1} element of the array", number, position + 1);
                Console.WriteLine("We did {0} iteration", linearIterations);
                break;
            }
            if ((position == (array.Length - 1)) && (array[position] != number))
            {
                Console.WriteLine("There is no {0} in the array", number);
                Console.WriteLine("We did {0} iteration", linearIterations);
            }
        }
    }

    static void BinarySearch(int[] array, int number)
    {
        Array.Sort(array);
        int elements = array.Length;
        int binaryIterations = 0;
        bool noNumber = true;
        int firstElement = 0;
        int endElement = elements - 1;
        int middleElement = elements / 2;

        while (elements > 0)
        {
            binaryIterations++;
            if (number == array[middleElement])
            {
                Console.WriteLine("{0} is on {1} position in the sorted array (from 0)", number, middleElement);
                Console.WriteLine("We did {0} iteration", binaryIterations);
                noNumber = false;
                break;
            }
            else if (number < array[middleElement])
            {
                if (firstElement != middleElement)
                {
                    endElement = middleElement - 1;
                    elements = middleElement - firstElement;
                    middleElement = firstElement + elements / 2;
                }
                else
                {
                    elements = 0;
                }
            }
            else
            {
                if (firstElement != middleElement)
                {
                    firstElement = middleElement + 1;
                    elements = endElement - middleElement;
                    middleElement = firstElement + elements / 2;
                }
                else
                {
                    elements = 0;
                }
            }
        }
        if (noNumber)
        {
            Console.WriteLine("There is no {0} in the array", number);
            Console.WriteLine("We did {0} iteration", binaryIterations);
        }
    }

    static void Main()
    {
        Console.WriteLine("Enter the number");
        int number = int.Parse(Console.ReadLine());

        int[] array = GenerateArray(number);

        LinearSearch(array, number);

        BinarySearch(array, number);
    }
}