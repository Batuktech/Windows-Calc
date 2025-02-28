using System;
using DLLCalc.Calc;
using DLLMemory.Memory;
using DLLinterface;

namespace DLLMaincalc.MainCalc
{
    public class MainCalc : Calc1, IOperation
    {
        public override decimal Result { get; set; }   // Result utgiig hadgalna
        private Meemory memory = new Meemory();         // memory class ashiglan object zarlana

        public string ShowMemory() // Return memory items
        {
            var items = memory.GetMemoryItems();
            if (items.Count == 0)
            {
                return "Memory is empty!";
            }

            string result = "Memory Items:";
            for (int i = 0; i < items.Count; i++)
            {
                result += $"\n {i + 1}. {items[i].Value}";
            }

            return result; // 
        }


        public decimal SelectMemoryItem()
        {
            int lastIndex = memory.GetLastSelectedMemoryIndex();

            //default aaraa -1 baival memory item aa songono
            if (lastIndex == -1)
            {
                List<MemoryItem> memoryItems = memory.GetMemoryItems();
                if (memoryItems.Count == 0)
                {
                    return 0;
                }

                lastIndex = memoryItems.Count - 1; // suuliin item iig songono
            }

            return memory.SelectMemoryItem(lastIndex);
        }


        public void Plus(decimal number1, decimal number2) // nemeh uildel
        {
            this.Result = number1 + number2;
        }

        public void Minus(decimal number1, decimal number2) // hasah uildel
        {
            this.Result = number1 - number2;
        }

        public void SaveToMemory() // sanah oid hadgalah
        {
            memory.Save(Result);
        }

        public void ReplaceItem(int index, decimal number) // sanah oid element shinecleh
        {
            memory.ReplaceItem(index, number);
        }

        public int MemoryIndex() // suuld songoson item iin index avah
        {
            return memory.GetLastSelectedMemoryIndex();
        }
        public bool IsMemoryEmpty() //memory hooson ugug shalgana
        {
            return memory.IsEmpty();
        }

        public List<MemoryItem> GetMemoryItems()    //memory itemuudig avna
        {
            return memory.GetMemoryItems();
        }
    }
}
