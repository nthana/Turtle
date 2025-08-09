using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThanaNita.Turtles;

public class StaticDisplay
{
    private static Display? _value = null;
    private static Mutex mut = new Mutex();
    // ref. https://learn.microsoft.com/en-us/dotnet/api/system.threading.mutex?view=net-9.0
    public static Display Value
    {
        // thread-safe getter with lazy init (singleton design pattern)
        // preparing for multi-thread turtles
        get
        {
            mut.WaitOne();

            MyAppConfig.Initialize();
            if (_value == null)
                _value = Display.CreateUIThread();

            mut.ReleaseMutex();

            return _value;
        }
    }
}
