using System;
using DLLMaincalc.MainCalc;

namespace Calculator
{
    internal class Program
    {
        static void Main(string[] args)
        {
            MainCalc calculator = new MainCalc(); // Only one instance, contains memory

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
                    case 2: // Minus
                        Console.Write("Enter number: ");
                        if (!decimal.TryParse(Console.ReadLine(), out decimal num))
                        {
                            Console.WriteLine("Invalid input. Please enter a valid number.");
                            break;
                        }

                        decimal lastResult = calculator.Result;
                        if (choice == 1)
                        {
                            calculator.Plus(lastResult, num);
                        }
                        else
                        {
                            calculator.Minus(lastResult, num);
                        }

                        calculator.SaveToMemory();
                        Console.WriteLine($"New Result: {calculator.Result}");
                        break;

                    case 3: // Show memory
                        calculator.ShowMemory();
                        break;

                    case 4: // Work on Memory (Fix applied)
                        if (calculator.IsMemoryEmpty()) // Use memory from calculator
                        {
                            Console.WriteLine("Memory is empty!");
                            break;
                        }

                        int lastMemoryIndex = calculator.MemoryIndex();
                        if (lastMemoryIndex == -1)
                        {
                            lastMemoryIndex = calculator.GetMemoryItems().Count - 1; // Автоматаар сүүлчийн элемент сонгох
                        }

                        decimal memValue = calculator.SelectMemoryItem();
                        Console.WriteLine($"\nMemory Value Selected: {memValue}");

                        Console.WriteLine("1. Plus (+)");
                        Console.WriteLine("2. Minus (-)");
                        Console.Write("Choose operation: ");

                        if (!int.TryParse(Console.ReadLine(), out int memoryChoice))
                        {
                            Console.WriteLine("Invalid choice.");
                            break;
                        }

                        Console.Write($"Enter number to apply on {memValue}: ");
                        if (!decimal.TryParse(Console.ReadLine(), out decimal numMem))
                        {
                            Console.WriteLine("Invalid number.");
                            break;
                        }

                        if (memoryChoice == 1)
                        {
                            calculator.Plus(memValue, numMem);
                        }
                        else if (memoryChoice == 2)
                        {
                            calculator.Minus(memValue, numMem);
                        }
                        else
                        {
                            Console.WriteLine("Invalid operation.");
                            break;
                        }

                        calculator.ReplaceItem(lastMemoryIndex, calculator.Result);
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
