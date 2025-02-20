using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using CalculatorLAB.Memory;

namespace CalculatorLAB.Memory
{
    internal class Meemory
    {
        private List<MemoryItem> memoryItems = new List<MemoryItem>();
        public void Save(decimal value)
        {
            memoryItems.Add(new MemoryItem(value));
            Console.WriteLine("Added value");
        }
        public void Display()
        {
            if (memoryItems.Count == 0)
            {
                Console.WriteLine("Memory is empty!");
            }
            Console.WriteLine("\n Memory Items");
            for (int i = 0; i < memoryItems.Count; i++)
            {
                Console.WriteLine($" {i + 1} {memoryItems[i].value} ");
            }

        }
        private int lastSelectedMemoryIndex = 1;
        public decimal SelectMemoryItem()
        {
            if (memoryItems.Count == 0)
            {
                Console.WriteLine("No memory Items");
                return 0;
            }
            Display();
            Console.WriteLine("Select memory item");
            if (int.TryParse(Console.ReadLine(), out int index))
            {
                lastSelectedMemoryIndex = index;
                return memoryItems[index - 1].value;
            }
            return 0;
        }
        public int GetLastSelectedMemoryIndex()
        {
            return lastSelectedMemoryIndex;
        }
        public void ReplaceItem(int index, decimal number)
        {
            memoryItems[index - 1].value = number;
        }
    }
}
