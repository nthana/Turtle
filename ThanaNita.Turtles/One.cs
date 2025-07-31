using System.Numerics;

namespace ThanaNita.Turtles;

public static class One
{
    public static Turtle Turtle { get { CheckInit(); return turtle!; } }
    private static Turtle? turtle;
    private static void CheckInit()
    {
        if (turtle != null)
            return;

        turtle = new Turtle();
    }

    public static bool Visible { get { return Turtle.Visible; } set { Turtle.Visible = value; } }
    public static bool PenOn { get { return Turtle.PenOn; } set { Turtle.PenOn = value; } }
    public static Color PenColor { get { return Turtle.PenColor; } set { Turtle.PenColor = value; } }
    public static float PenSize { get { return Turtle.PenSize; } set { Turtle.PenSize = value; } }
    public static Vector2 Position { get { return Turtle.Position; } set { Turtle.Position = value; } }
    public static float Speed { get { return Turtle.Speed; } set { Turtle.Speed = value; } }

    public static float Direction { get { return Turtle.Direction; } set { Turtle.Direction = value; } }

    public static void Forward(float distant)
    {
        Turtle.Forward(distant);
    }
    public static void Backward(float distant)
    {
        Turtle.Backward(distant);
    }
    public static void TurnRight(float angle)
    {
        Turtle.TurnRight(angle);
    }
    public static void TurnLeft(float angle)
    {
        Turtle.TurnLeft(angle);
    }
    public static void ArcLeft(float radius, float angle)
    {
        Turtle.ArcLeft(radius, angle);
    }
    public static void ArcRight(float radius, float angle)
    {
        Turtle.ArcRight(radius, angle);
    }
    public static void Fill(Color color)
    {
        Turtle.Fill(color);
    }
}
