using System;
using DLLCalc.Calc;
using DLLMemory.Memory;
using DLLinterface;

namespace DLLMaincalc.MainCalc
{
    public class MainCalc : Calc1, IOperation
    {
        public override decimal Result { get; set; }   // Result утгыг хадгалах
        private Meemory memory = new Meemory();         // `Memory` класс ашиглах

        public void ShowMemory()                      // Санах ой дахь утгуудыг харуулах
        {
            var items = memory.GetMemoryItems();
            if (items.Count == 0)
            {
                Console.WriteLine("Memory is empty!");
                return;
            }

            Console.WriteLine("\nMemory Items:");
            for (int i = 0; i < items.Count; i++)
            {
                Console.WriteLine($" {i + 1}. {items[i].Value}");
            }
        }

        public decimal SelectMemoryItem()
        {
            int lastIndex = memory.GetLastSelectedMemoryIndex();

            // If no memory index has been selected, default to the last memory item
            if (lastIndex == -1)
            {
                List<MemoryItem> memoryItems = memory.GetMemoryItems();
                if (memoryItems.Count == 0)
                {
                    return 0;
                }

                lastIndex = memoryItems.Count - 1; // Select the last item
            }

            return memory.SelectMemoryItem(lastIndex);
        }


        public void Plus(decimal number1, decimal number2) // Нэмэх үйлдэл
        {
            this.Result = number1 + number2;
        }

        public void Minus(decimal number1, decimal number2) // Хасах үйлдэл
        {
            this.Result = number1 - number2;
        }

        public void SaveToMemory() // Санах ойд хадгалах
        {
            memory.Save(Result);
        }

        public void ReplaceItem(int index, decimal number) // Санах ойн элемент шинэчлэх
        {
            memory.ReplaceItem(index, number);
        }

        public int MemoryIndex() // Сүүлд сонгосон санах ойн индекс авах
        {
            return memory.GetLastSelectedMemoryIndex();
        }
        public bool IsMemoryEmpty()
        {
            return memory.IsEmpty();
        }

        public List<MemoryItem> GetMemoryItems()
        {
            return memory.GetMemoryItems();
        }
    }
}
