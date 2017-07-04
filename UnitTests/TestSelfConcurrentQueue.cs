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
                queue.Pop();   
            });

            var popTask2 = new Task(() =>
            {
                // пытаемся достать 2й элемент из очереди
                queue.Pop();
            });

            var popTask3 = new Task(() =>
            {
                // пытаемся достать 2й элемент из очереди
                queue.Pop();
            });

            popTask1.Start();
            popTask2.Start();
            popTask3.Start();
            
            // добавляем элементы в очередь
            // а popTask'и ждут, пока они появится
            queue.Push(1);
            queue.Push(2);
            queue.Push(3);

            popTask1.Wait();
            popTask2.Wait();
            popTask3.Wait();
            Assert.IsFalse(popTask1.IsFaulted);
            Assert.IsFalse(popTask2.IsFaulted);
            Assert.IsFalse(popTask3.IsFaulted);
            Assert.IsTrue(queue.Count == 0);
        }
    }
}
