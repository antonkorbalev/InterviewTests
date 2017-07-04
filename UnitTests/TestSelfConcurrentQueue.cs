using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Threading.Tasks;
using InterviewClassesLib.Collections;
using System.Threading;

namespace UnitTests
{
    [TestClass]
    public class TestSelfConcurrentQueue
    {
        /// <summary>
        /// Проверяет методы Pop() и Push()
        /// Push вставляет элемент и выходит
        /// Pop ждет, пока появится элемент в очереди
        /// и отдает его
        /// </summary>
        [TestMethod]
        public void TestQueue()
        {
            var queue = new SelfConcurrentQueue<int>();
            var popTask1 = new Task(() => 
            {
                // пытаемся достать 1й элемент из очереди
                var element = queue.Pop();   
            });
            popTask1.Start();

            var popTask2 = new Task(() =>
            {
                // пытаемся достать 2й элемент из очереди
                var element = queue.Pop();
            });
            popTask2.Start();
            
            // добавляем элементы в очередь
            // а popTask'и ждут, пока они появится
            queue.Push(1);
            queue.Push(2);

            popTask1.Wait();
            popTask2.Wait();
            Assert.IsFalse(popTask1.IsFaulted);
            Assert.IsFalse(popTask2.IsFaulted);
            Assert.IsTrue(queue.Count == 0);
        }
    }
}
