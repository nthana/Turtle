using System.Numerics;

namespace ThanaNita.Turtles;

public static class Prime
{
    public static Turtle Turtle { get { CheckInit(); return turtle!; } }
    private static Turtle? turtle;
    private static void CheckInit()
    {
        if (turtle != null)
            return;

        turtle = new Turtle();
    }

    public static Color PenColor { get { return Turtle.PenColor; } set { Turtle.PenColor = value; } }
    public static Vector2 Position { get { return Turtle.Position; } set { Turtle.Position = value; } }
    public static float Speed { get { return Turtle.Speed; } set { Turtle.Speed = value; } }

    public static float Direction 
    { 
        get { return Turtle.Direction; } 
        set { Turtle.Direction = value; }
    }

    public static void Forward(float distant)
    {
        Turtle.Forward(distant);
    }
}
