using System;
using System.Text;

class BitRotation
{
    static void PrintResult(bool isNumber, int number)
    {
        Console.Write("The created symbol is: ");
        if (isNumber)
        {
            Console.WriteLine(number);
        }
        else
        {
            Console.WriteLine((char)number);
        }

        Console.WriteLine(Convert.ToString(number, 2).PadLeft(32, '0'));
    }

    static int RotateBits(int number, byte firstBeginningPosition, byte secondBeginningPosition, byte range)
    {
        byte distance = (byte)(secondBeginningPosition - firstBeginningPosition);
        for (int bit = firstBeginningPosition; bit < (firstBeginningPosition + range); bit++)
        {
            int firstMask = 1 << bit;
            int firstMaskNumber = number & firstMask;
            byte firstBitValue = (byte)(firstMaskNumber >> bit);                  //0 or 1
            int secondMask = 1 << (bit + distance);
            int secondMaskNumber = number & firstMask;
            byte secondBitValue = (byte)(firstMaskNumber >> (bit + distance));    //0 or 1
            if (firstBitValue == 1)
            {                                                                     //Change bit (i + range) to 1
                int changeNumber = SetBitToOne((byte)(bit + distance), number);
                if (secondBitValue == 1)
                {                                                                 //Change bit i to 1
                    number = SetBitToOne((byte)bit, changeNumber);
                }
                else
                {                                                                 //Change bit i to 0
                    number = SetBitToZero((byte)bit, changeNumber);
                }
            }
            else
            {                                                                     //Change bit (i + range) to 0
                int changeNumber = SetBitToZero((byte)(bit + distance), number);
                if (secondBitValue == 1)
                {                                                                 //Change bit i to 1
                    number = SetBitToOne((byte)bit, changeNumber);
                }
                else
                {                                                                //Change bit i to 0
                    number = SetBitToZero((byte)bit, changeNumber);
                }
            }
        }

        return number;
    }

    static int SetBitToOne(byte position, int number)
    {
        int changeMask = 1 << position;
        int changeNumber = number | changeMask;
        return changeNumber;
    }

    static int SetBitToZero(byte position, int number)
    {
        int changeMask = ~(1 << position);
        int changeNumber = number & changeMask;
        return changeNumber;
    }


    static void Main()
    {
        Console.OutputEncoding = Encoding.UTF8;
        Console.WriteLine("This program exchange the bits in the intervals");
        Console.WriteLine("[first beginning position; first beginning position + range)");
        Console.WriteLine("and\n[second beginning position; second beginning position + range)");
        Console.WriteLine("Enter symbol");

        int number;
        string input = Console.ReadLine();
        bool isNumber = int.TryParse(input, out number);
        if (!isNumber)
        {
            number = (int)input[0];
        }

        Console.WriteLine(Convert.ToString(number, 2).PadLeft(32, '0'));

        Console.WriteLine("Enter first beginning position");
        byte firstBeginningPosition = byte.Parse(Console.ReadLine());
        Console.WriteLine("Enter second beginning position");
        byte secondBeginningPosition = byte.Parse(Console.ReadLine());
        Console.WriteLine("Enter range");
        byte range = byte.Parse(Console.ReadLine());

        number = RotateBits(number, firstBeginningPosition, secondBeginningPosition, range);

        PrintResult(isNumber, number);
    }
}
