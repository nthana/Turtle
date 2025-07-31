using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThanaNita.Turtles;

public class StaticDisplay
{
    private static Display? _value = null;
    public static Display Value
    {
        get
        {
            if (_value == null)
                _value = Display.CreateUIThread();

            return _value;
        }
    }
}
