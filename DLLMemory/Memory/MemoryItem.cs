﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DLLMemory.Memory
{
    public class MemoryItem
    {
        public decimal Value { get; set; }

        public MemoryItem(decimal value)
        {
            Value = value;
        }
    }
}

