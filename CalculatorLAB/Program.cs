using System;
using CalculatorLAB.MainCalc;

namespace Calculator
{
    internal class Program
    {
        static void Main(string[] args)
        {
            MainCalc calculator = new MainCalc(); // ✅ Create instance once to maintain memory

            while (true)
            {
                Console.WriteLine("\nMenu");
                Console.WriteLine("1. Plus (+)");
                Console.WriteLine("2. Minus (-)");
                Console.WriteLine("3. Show Memory");
                Console.WriteLine("4. Work on Memory");
                Console.WriteLine("5. Exit");

                Console.Write("Choose option: ");

                if (!int.TryParse(Console.ReadLine(), out int choice))
                {
                    Console.WriteLine("Invalid choice. Please enter a number between 1 and 5.");
                    continue;
                }

                switch (choice)
                {
                    case 1: // Plus
                        Console.Write("Enter first number: ");
                        if (!decimal.TryParse(Console.ReadLine(), out decimal num1))
                        {
                            Console.WriteLine("Invalid input. Please enter a valid number.");
                            break;
                        }

                        Console.Write("Enter second number: ");
                        if (!decimal.TryParse(Console.ReadLine(), out decimal num2))
                        {
                            Console.WriteLine("Invalid input. Please enter a valid number.");
                            break;
                        }
                        //garaas 2 utgaa avsan
                        //calculator object iin Plus function duudna
                        calculator.Plus(num1, num2);
                        calculator.SaveToMemory(); // uildel hiisnii daraa memoryd Result iig hadgalna
                        Console.WriteLine($"New Result: {calculator.Result}");
                        break;

                    case 2: // Minus
                        Console.Write("Enter first number: ");
                        if (!decimal.TryParse(Console.ReadLine(), out decimal num3))
                        {
                            Console.WriteLine("Invalid input. Please enter a valid number.");
                            break;
                        }

                        Console.Write("Enter second number: ");
                        if (!decimal.TryParse(Console.ReadLine(), out decimal num4))
                        {
                            Console.WriteLine("Invalid input. Please enter a valid number.");
                            break;
                        }
                        //garaas 2 utgaa avsan
                        //calculator object iin Minus function duudna
                        calculator.Minus(num3, num4);
                        calculator.SaveToMemory(); // uildel hiisnii daraa memoryd Result iig hadgalna
                        Console.WriteLine($"New Result: {calculator.Result}");
                        break;

                    case 3: // Show memory
                        calculator.ShowMemory();
                        break;

                    case 4: // Work on memory
                        int memoryIndex = calculator.MemoryIndex();
                        decimal memValue = calculator.SelectMemoryItem();
                        Console.WriteLine($"\nMemory Value Selected: {memValue}");
                        Console.WriteLine("1. Plus (+)");
                        Console.WriteLine("2. Minus (-)");

                        if (!int.TryParse(Console.ReadLine(), out int memoryChoice))
                        {
                            Console.WriteLine("Invalid choice.");
                            break;
                        }

                        Console.Write($"Enter number to apply on {memValue}: ");
                        if (!decimal.TryParse(Console.ReadLine(), out decimal num))
                        {
                            Console.WriteLine("Invalid number.");
                            break;
                        }

                        if (memoryChoice == 1)
                        {
                            calculator.Plus(memValue, num);
                        }
                        else if (memoryChoice == 2)
                        {
                            calculator.Minus(memValue, num);
                        }
                        else
                        {
                            Console.WriteLine("Invalid operation.");
                            break;
                        }

                        calculator.ReplaceItem(memoryIndex, calculator.Result); // uildel hiisnii daraa memoryd Result iig hadgalna
                        Console.WriteLine($"New Memory Result: {calculator.Result}");
                        break;

                    case 5:
                        return;

                    default:
                        Console.WriteLine("Invalid choice. Please enter a number between 1 and 5.");
                        break;
                }
            }
        }
    }
}
