using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace DLLMemory.Memory
{
    public class Meemory
    {
        private List<MemoryItem> memoryItems = new List<MemoryItem>();

        private int lastSelectedMemoryIndex = -1; // Default utga, ehend yuc songogdohgu.

        // sanah oid utga nemeh
        public void Save(decimal value)
        {
            memoryItems.Add(new MemoryItem(value));
        }

        // buh sanah oin utguudiig avah
        public List<MemoryItem> GetMemoryItems()
        {
            return memoryItems;
        }

        // sanah oi hooson eshiig shalgana
        public bool IsEmpty()
        {
            return memoryItems.Count == 0;
        }

        // sanah oin index deh utgiig avna
        public decimal SelectMemoryItem(int index)
        {
            if (index < 0 || index >= memoryItems.Count)
            {
                return 0; //buruu utga bol o
            }

            lastSelectedMemoryIndex = index; // songoson index iig hadgalna
            return memoryItems[index].Value;
        }

        // suuld songoson item iin index iig avna
        public int GetLastSelectedMemoryIndex()
        {
            return lastSelectedMemoryIndex;
        }

        // memory iin item iig shinecleh.
        public void ReplaceItem(int index, decimal number)
        {
            if (index >= 0 && index < memoryItems.Count)
            {
                memoryItems[index].Value = number;
            }
        }
    }
}
