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
        private static ManualResetEvent? finishCommandEvent;

        public static ManualResetEvent FinishCommandEvent
        {
            get
            {
                finishCommandEvent ??= new ManualResetEvent(false);
                return finishCommandEvent;
            }
        }
    }
}
