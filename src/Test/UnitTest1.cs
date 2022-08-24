using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System;

#pragma warning disable IDE0028

namespace Test
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            IndexDictionary<int, int> dic = new IndexDictionary<int, int> ();
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
            Assert.AreEqual(2, value);
        }

        [TestMethod]
        public void TestMethod3()
        {
            IndexDictionary<int, int> dic = new IndexDictionary<int, int>();
            dic[1] = 1;
            List<int> expected = new List<int>(new int[] { 1 });
            int index = 0;
            foreach (int key in dic.Keys)
            {
                Assert.AreEqual(expected[index++], key);
            }

            Assert.AreEqual(1, index);
        }
    }
}

#pragma warning restore IDE0028