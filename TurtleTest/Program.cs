using System.Diagnostics;
using System.Numerics;
using ThanaNita.Turtles;
using static ThanaNita.Turtles.One;


namespace TurtleTest;

internal static class Program
{
    [STAThread]
    static void Main()
    {
        // To customize application configuration such as set high DPI settings or default font,
        // see https://aka.ms/applicationconfiguration.
        ApplicationConfiguration.Initialize();

        // ถ้า thread หนึ่งมีเต่าสองตัว ก็ทำได้ จะเคลื่อนทีละตัว ไม่พร้อมกัน
        // ถ้า สอง thread ตัว screen น่าจะต้องมีสอง queue ตาม thread
        // ถ้าใช้เต่าตัวเดียวกัน น่าจะมีปัญหา

        NewOne();
        //UseOne();
        //TwoTurtle();
    }

    static void NewOne()
    {
        var t1 = new Turtle();

        t1.Speed = 200;

        t1.Position = new Vector2(300, 100);
        t1.PenColor = Color.Red;
        t1.TurnRight(60);
        t1.Forward(300);

        t1.PenColor = Color.Blue;
        t1.TurnRight(120);
        t1.Forward(300);

        t1.PenColor = Color.Green;
        t1.TurnRight(120);
        t1.Forward(300);
    }

    static void UseOne()
    {
        Speed = 200;

        Position = new Vector2(300, 100);
        PenColor = Color.Red;
        Direction = 60f;
        Forward(300);

        //Console.ReadLine();

        PenColor = Color.Blue;
        TurnRight(120);
        Forward(300);
        Backward(600);

        //PenColor = Color.Green;
        //Direction = -60f;
        //Forward(300);
    }

    static void TwoTurtle()
    {
        Position = new Vector2(300, 100);
        PenColor = Color.Red;
        Direction = 60f;
        Forward(300);

        var t2 = new Turtle();
        t2.Position = new Vector2(300, 100);
        t2.PenColor = Color.Blue;
        t2.Direction = 180f;
        t2.Forward(300);
    }
}