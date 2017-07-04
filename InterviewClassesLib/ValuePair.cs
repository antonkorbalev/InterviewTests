using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterviewClassesLib
{
    public struct ValuePair
    {
        public int Value1 { get; set; }
        public int Value2 { get; set; }

        public ValuePair(int v1, int v2)
        {
            Value1 = v1;
            Value2 = v2;
        }
    }
}
