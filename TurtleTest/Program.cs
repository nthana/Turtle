using System.Diagnostics;
using System.Numerics;
using ThanaNita.Turtles;
using static ThanaNita.Turtles.Prime;


namespace TurtleTest;

internal static class Program
{
    [STAThread]
    static void Main()
    {
        // To customize application configuration such as set high DPI settings or default font,
        // see https://aka.ms/applicationconfiguration.
        ApplicationConfiguration.Initialize();

        // ��� thread ˹��������ͧ��� ����� ������͹���е�� ��������ѹ
        // ��� �ͧ thread ��� screen ��Ҩе�ͧ���ͧ queue ��� thread
        // �������ҵ�����ǡѹ ��Ҩ��ջѭ��

        //NewOne();
        UseOne();
    }

    static void NewOne()
    {
        var t1 = new Turtle();

        t1.Speed = 1000;

        t1.Position = new Vector2(300, 100);
        t1.PenColor = Color.Red;
        t1.Direction = 60f;
        t1.Forward(300);

        t1.PenColor = Color.Blue;
        t1.Direction = 180f;
        t1.Forward(300);

        t1.PenColor = Color.Green;
        t1.Direction = -60f;
        t1.Forward(300);
    }

    static void UseOne()
    {
        Speed = 200;

        Position = new Vector2(300, 100);
        PenColor = Color.Red;
        Direction = 60f;
        Forward(300);

        PenColor = Color.Blue;
        Direction = 180f;
        Forward(300);

        //PenColor = Color.Green;
        //Direction = -60f;
        //Forward(300);
    }
}