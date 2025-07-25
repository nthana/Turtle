using System.Diagnostics;
using System.Numerics;
using ThanaNita.Turtles;
//using static ThanaNita.Turtles.Prime;


namespace TurtleTest;

internal static class Program
{
    [STAThread]
    static void Main()
    {
        // To customize application configuration such as set high DPI settings or default font,
        // see https://aka.ms/applicationconfiguration.
        ApplicationConfiguration.Initialize();

        var t1 = new Turtle();

        t1.position = new Vector2(300, 100);
        t1.pencolor = Color.Red;
        t1.Direction = 60f;
        t1.Forward(300);

        t1.pencolor = Color.Blue;
        t1.Direction = 180f;
        t1.Forward(300);

        t1.pencolor = Color.Green;
        t1.Direction = -60f;
        t1.Forward(300);
    }
}