using System.Diagnostics;
using System.Numerics;
using static ThanaNita.Turtles.TurtleOne;


namespace TurtleTest;

internal static class Program
{
    [STAThread]
    static void Main()
    {
        // To customize application configuration such as set high DPI settings or default font,
        // see https://aka.ms/applicationconfiguration.
        ApplicationConfiguration.Initialize();



        t1.position = new Vector2(300, 100);
        t1.pencolor = Color.Red;
        direction = 60f;
        fd(300);

        t1.pencolor = Color.Blue;
        direction = 180f;
        fd(300);

        t1.pencolor = Color.Green;
        direction = -60f;
        fd(300);
    }
}