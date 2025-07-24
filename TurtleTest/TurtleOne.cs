using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace TurtleTest;

public static class TurtleOne
{
    public static Turtle t1 { get { CheckInit(); return turtle!; } }
    private static Turtle? turtle;
    private static void CheckInit()
    {
        if (turtle != null)
            return;

        turtle = new Turtle();
    }

    public static float direction 
    { 
        get { CheckInit(); return turtle!.direction; } 
        set { CheckInit(); turtle!.direction = value; }
    }

    public static void fd(float distant)
    {
        CheckInit();

        turtle!.fd(distant);
    }
}
