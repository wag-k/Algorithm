using Microsoft.VisualStudio.TestTools.UnitTesting;
using Algorithm;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;

namespace Algorithm.Tests
{
    [TestClass()]
    public class BinarySearchTests
    {
        static int RandCounter { get; set; }
        
        [TestMethod()]
        public void SearchTest_Int()
        {
            int totalTestCnt = 100;
            var rand = new Random(DateTime.Now.GetHashCode()+RandCounter);
            for (int testCnt = 1; testCnt <= totalTestCnt; ++testCnt){
                // 様々な大きさの配列でテスト
                var testCase = (
                    from index in Enumerable.Range(0, testCnt)
                    let num = rand.Next()
                    orderby num
                    select num
                ).ToArray();
                var testKey = rand.Next();
                
                var expected = testCase.Length;
                for (int index = 0; index < testCase.Length; ++index){
                    if(BinarySearch<int>.DefaultIsOK(testCase, index, testKey)) {
                        expected = index;
                        break;
                    }
                }
                Debug.WriteLine($"TestCase: {testCnt}, Key: {testKey}");
                Debug.WriteLine(String.Join(",", testCase));

                var actual = BinarySearch<int>.Search(testCase, testKey);
                Assert.AreEqual(expected, actual);
            }
        }

        [TestMethod()]
        public void SearchTest_Int2()
        {
            // 様々な大きさの配列でテスト
            var testCase = new int[]{2, 2, 2, 3};
            
            var actual1 = BinarySearch<int>.Search(testCase, 1);
            var actual2 = BinarySearch<int>.Search(testCase, 2);
            var actual3 = BinarySearch<int>.Search(testCase, 3);
            var actual4 = BinarySearch<int>.Search(testCase, 4);
            Assert.AreEqual(0, actual1);
            Assert.AreEqual(0, actual2);
            Assert.AreEqual(3, actual3);
            Assert.AreEqual(4, actual4);
        }
        
        [TestMethod()]
        public void SearchTest_Double()
        {
            int totalTestCnt = 100;
            var rand = new Random(DateTime.Now.GetHashCode()+RandCounter);
            for (int testCnt = 1; testCnt <= totalTestCnt; ++testCnt){
                // 様々な大きさの配列でテスト
                var testCase = (
                    from index in Enumerable.Range(0, testCnt)
                    let num = rand.NextDouble()
                    orderby num
                    select num
                ).ToArray();
                var testKey = rand.Next();
                
                var expected = testCase.Length;
                for (int index = 0; index < testCase.Length; ++index){
                    if(BinarySearch<double>.DefaultIsOK(testCase, index, testKey)) {
                        expected = index;
                        break;
                    }
                }
                Debug.WriteLine($"TestCase: {testCnt}, Key: {testKey}");
                Debug.WriteLine(String.Join(",", testCase));

                var actual = BinarySearch<double>.Search(testCase, testKey);
                Assert.AreEqual(expected, actual);
            }
        }
        
    }
}