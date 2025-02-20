using System;
using CalculatorLAB.Calc;
using CalculatorLAB.Memory;

namespace CalculatorLAB.MainCalc
{
    internal class MainCalc : Calc1, IOperation
    {
        public override decimal Result { get; set; }
        private Meemory memory = new Meemory(); 

        public void ShowMemory()
        {
            memory.Display();
        }

        public decimal SelectMemoryItem()
        {
            return memory.SelectMemoryItem();
        }

        public void Plus(decimal number1, decimal number2)
        {
            this.Result = number1 + number2;
        }

        public void Minus(decimal number1, decimal number2)
        {
            this.Result = number1 - number2;
        }

        public void SaveToMemory() 
        {
            memory.Save(Result);
        }

        public void ReplaceItem(int index, decimal number)
        {
            memory.ReplaceItem(index, number);
        }

        public int MemoryIndex()
        {
            return memory.GetLastSelectedMemoryIndex();
        }
    }
}
