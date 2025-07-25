using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace ThanaNita.Turtles;

public static class Prime
{
    public static Turtle t1 { get { CheckInit(); return turtle!; } }
    private static Turtle? turtle;
    private static void CheckInit()
    {
        if (turtle != null)
            return;

        turtle = new Turtle();
    }

    public static float Direction 
    { 
        get { CheckInit(); return turtle!.Direction; } 
        set { CheckInit(); turtle!.Direction = value; }
    }

    public static void Forward(float distant)
    {
        CheckInit();

        turtle!.Forward(distant);
    }
}
