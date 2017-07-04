using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterviewClassesLib.Collections
{
    public interface ISelfConcurrentQueue<T>
    {
        void Push(T obj);
        T Pop();   
        int Count { get; } 
    }
}
