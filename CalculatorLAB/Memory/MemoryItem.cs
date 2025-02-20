using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalculatorLAB.Memory
{
    internal class MemoryItem
    {
        public decimal value { get; set; }
        public MemoryItem(decimal value) { 
            this.value = value;
        }
    }
}
