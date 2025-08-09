using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThanaNita.Turtles
{
    internal static class PerThread
    {
        [ThreadStatic]
        public static ManualResetEvent finishCommandEvent = new ManualResetEvent(false);
    }
}
