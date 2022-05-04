using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System;

namespace Test
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            //Dictionary<int, int> dic = new Dictionary<int, int>();
            IndexDictionary<int, int> dic = new IndexDictionary<int, int>();
            dic.Add(1, 1);
            dic.Add(2, 1);
            dic.Remove(1);
            dic.Add(3, 1);

            List<int> expected = new List<int>(new int[] { 2, 3 });
            int index = 0;
            foreach (int key in dic.Keys)
            {
                Assert.AreEqual(expected[index++], key);
            }
        }

        [TestMethod]
        public void TestMethod2()
        {
            IndexDictionary<int, int> dic = new IndexDictionary<int, int>();
            dic.Add(1, 1);
            dic.Add(2, 2);
            int value;
            dic.TryGetValueByIndex(1, out value);
            Assert.AreEqual(value, 2);
        }
    }
}
