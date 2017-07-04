using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace InterviewClassesLib.Collections
{
    public class SelfConcurrentQueue<T> : ISelfConcurrentQueue<T>
    {
        private object _lockObj = new object();
        private Queue<T> _queue = new Queue<T>();

        public T Pop()
        {
            lock (_lockObj)
            {
                // ждем пока появится хотя бы 1 элемент (блокируем поток)
                while (_queue.Count == 0)
                    Monitor.Wait(_lockObj);
                return _queue.Dequeue();
            }
        }

        public void Push(T obj)
        {
            lock (_lockObj)
            {
                _queue.Enqueue(obj);
                // если очеред была пуста, а затем появился элемент
                // разрешаем его отдать в Pop()
                if (_queue.Count == 1)
                    Monitor.PulseAll(_lockObj);
            }
        }

        // для тестов - число элементов в очереди
        public int Count
        {
            get
            {
                return _queue.Count;
            }
        }
    }
}
