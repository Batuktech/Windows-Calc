using System;
using System.Collections.Generic;
using DLLMaincalc.MainCalc;
using DLLMemory.Memory;
using Microsoft.VisualStudio.TestPlatform.Utilities;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CalculatorUnitTest
{
    [TestClass]
    public sealed class Test1
    {
        private MainCalc calculator;

        [TestInitialize]
        public void Setup()
        {
            calculator = new MainCalc();
        }

        [TestMethod]
        public void Test_Addition()
        {
            calculator.Plus(5, 10);
            Assert.AreEqual(15, calculator.Result, "Addition failed.");
        }

        [TestMethod]
        public void Test_Subtraction()
        {
            calculator.Minus(10, 4);
            Assert.AreEqual(6, calculator.Result, "Subtraction failed.");
        }

        [TestMethod]
        public void Test_SaveToMemory()
        {
            calculator.Plus(3, 7);
            calculator.SaveToMemory();

            List<MemoryItem> memoryItems = calculator.GetMemoryItems();
            Assert.AreEqual(1, memoryItems.Count, "Memory count is incorrect.");
            Assert.AreEqual(10, memoryItems[0].Value, "Memory value is incorrect.");
        }

        [TestMethod]
        public void Test_IsMemoryEmpty_InitiallyTrue()
        {
            Assert.IsTrue(calculator.IsMemoryEmpty(), "Memory should be empty initially.");
        }

        [TestMethod]
        public void Test_IsMemoryEmpty_AfterAddingItem()
        {
            calculator.Plus(8, 2);
            calculator.SaveToMemory();
            Assert.IsFalse(calculator.IsMemoryEmpty(), "Memory should not be empty after saving a value.");
        }

        [TestMethod]
        public void Test_SelectMemoryItem()
        {
            calculator.Plus(2, 3);
            calculator.SaveToMemory();

            calculator.Plus(4, 1);
            calculator.SaveToMemory();

            decimal lastMemoryValue = calculator.SelectMemoryItem();
            Assert.AreEqual(5, lastMemoryValue, "SelectMemoryItem did not return the correct last stored value.");
        }

        [TestMethod]
        public void Test_MemoryIndex_Default()
        {
            Assert.AreEqual(-1, calculator.MemoryIndex(), "Default memory index should be -1.");
        }

        [TestMethod]
        public void Test_ReplaceMemoryItem()
        {
            calculator.Plus(2, 2);
            calculator.SaveToMemory();

            calculator.ReplaceItem(0, 10);
            List<MemoryItem> memoryItems = calculator.GetMemoryItems();
            Assert.AreEqual(10, memoryItems[0].Value, "Memory value did not update correctly.");
        }


        [TestMethod]
        public void ShowMemory_Empty()
        {
  
            MainCalc calculator = new MainCalc();

            string result = calculator.ShowMemory();


            Assert.AreEqual("Memory is empty!", result);
        }

        [TestMethod]
        public void ShowMemory_HasItem()
        {
            
            MainCalc calculator = new MainCalc();
            calculator.Plus(5, 10);
            calculator.SaveToMemory();


            string result = calculator.ShowMemory();

            
            string expected = "Memory Items:\n 1. 15";
            Assert.AreEqual(expected, result);
        }


    }
}
