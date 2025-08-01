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
        //ApplicationConfiguration.Initialize();

        // ถ้า thread หนึ่งมีเต่าสองตัว ก็ทำได้ จะเคลื่อนทีละตัว ไม่พร้อมกัน
        // ถ้า สอง thread ตัว screen น่าจะต้องมีสอง queue ตาม thread
        // ถ้าใช้เต่าตัวเดียวกัน น่าจะมีปัญหา

        //GDIDrawPathBug();
        Empty();
        //NewOne();
        //Loops();
        //UseOne();
        //TwoTurtle();
        //TestArc();
        //TestFill();
    }

    // สรุปว่าจริงๆ ไม่มี bug แล้ว bug เกิดจากเราที่ add line ใน path ซ้ำๆ มากเกินไป
    static void GDIDrawPathBug()
    {
        PenSize = 10;
        PenColor = Color.Blue;
        TurnRight(30);
        Forward(300);
        TurnLeft(120);
        Forward(300);
        TurnLeft(120);
        Forward(300);
        Fill(Color.Green);
    }

    static void Empty()
    {
        //TurnRight(0);
        //Forward(0);
        //ArcRight(100, 0);
    }

    static void NewOne()
    {
        var t1 = new Turtle();

        t1.PenSize = 20;
        t1.PenColor = Color.Blue;
        t1.TurnRight(30);
        t1.Forward(300);
        //t1.Dot(Color.Red);
        //Debug.WriteLine(t1.Position);

        //t1.PenColor = Color.Blue;
        t1.TurnLeft(120);
        t1.Forward(300);
        //Debug.WriteLine(t1.Position);

        //t1.PenColor = Color.Green;
        t1.TurnLeft(120);
        t1.Forward(300);
        //Debug.WriteLine(t1.Position);
        //t1.Fill(Color.Green);

        //t1.PenColor = Color.Blue;
        //t1.TurnRight(0.001f);
        t1.Forward(300);
        t1.TurnLeft(120);
        t1.Forward(300);
        t1.TurnLeft(120);
        t1.Forward(300);
        t1.Fill(Color.Green);
    }

    static void Loops()
    {
        //Visible = false;
        Speed = 400;
        PenColor = Color.Green;
        for (int i = 0; i < 40; ++i)
        {
            Forward(200);
            TurnRight(88);
        }
        Fill(Color.Yellow);

        Debug.WriteLine(Direction);
    }

    static void UseOne()
    {
        Visible = false;

        PenOn = false;
        PenColor = Color.Red;
        Direction = 60f;
        Forward(300);

        //Console.ReadLine();
        PenOn = true;
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

    static void TestArc()
    {
        //Speed = 9999;
        Position = new Vector2(0, 0);
        Direction = 90;
        PenColor = Color.Blue;
        //TurnRight(30);
        Forward(100);
        ArcLeft(100, 90+30+180); // radius and angle
        Fill(Color.Yellow);

        Position = new Vector2(0, 0);
        Direction = 90;
        PenColor = Color.Red;
        TurnRight(30);
        Forward(100);
        ArcRight(100, 90 + 30 + 180); // radius and angle
        Forward(200);
        TurnRight(30);
        Backward(400);

        Fill(Color.Green);
    }
    static void TestFill()
    {
        PenColor = Color.Blue;
        TurnRight(30);
        Forward(100);
        //ArcLeft(100, 90 + 30 + 180); // radius and angle

        TurnRight(120);
        Forward(100);
        TurnLeft(120);
        //ArcRight(100, 90 + 30 + 180); // radius and angle
        Forward(100);
        //Backward(400);

        PenOn = false;
        Forward(30);
        PenOn = true;
        Forward(100);
        TurnRight(120);
        Forward(100);
        TurnRight(120);

        Position = new Vector2(-100, -100);
        Direction = -90;
        Forward(100);
        ArcLeft(100, 90);
        Forward(30);

        Fill(Color.Yellow);
    }
}