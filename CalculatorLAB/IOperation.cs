using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalculatorLAB
{
    internal interface IOperation
    {
        void Plus(decimal number1, decimal number2);
        void Minus(decimal number1, decimal number2);
    }
}
