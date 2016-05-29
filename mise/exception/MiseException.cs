using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mise.exception
{
    public class MiseException : Exception
    {
        public MiseException() : base() { }
        public MiseException(string msg) : base(msg) { }
        public MiseException(string msg, Exception inner) : base(msg, inner) { }
    }
}
