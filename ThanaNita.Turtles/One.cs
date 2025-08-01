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
    public static void TurnLeft(float angle)
    {
        Turtle.TurnLeft(angle);
    }
    public static void TurnRight(float angle)
    {
        Turtle.TurnRight(angle);
    }
    public static void ArcLeft(float radius, float angle)
    {
        Turtle.ArcLeft(radius, angle);
    }
    public static void ArcRight(float radius, float angle)
    {
        Turtle.ArcRight(radius, angle);
    }
    public static void Dot(Color color, float diameter = 10)
    {
        Turtle.Dot(color, diameter);
    }
    public static void Fill(Color color)
    {
        Turtle.Fill(color);
    }
    public static void PenUp() { Turtle.PenUp(); }
    public static void PenDown() { Turtle.PenDown(); }
    public static void HideTurtle() { Turtle.HideTurtle(); }
    public static void ShowTurtle() { Turtle.ShowTurtle(); }
    public static void SetPenSize(float size) { Turtle.SetPenSize(size); }
    public static void SetPenColor(Color color) { Turtle.SetPenColor(color); }
    public static void SetSpeed(float speed) { Turtle.SetSpeed(speed); }
}
