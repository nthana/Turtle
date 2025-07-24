using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TurtleTest;

public static class TurtleOne
{
    private static Turtle? turtle;
    private static void CheckInit()
    {
        if (turtle != null)
            return;

        turtle = new Turtle();
    }

    public static void fd(float distant)
    {
        CheckInit();

        turtle!.fd(distant);
    }
}
