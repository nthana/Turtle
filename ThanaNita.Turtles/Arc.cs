using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using TurtleTest;

namespace ThanaNita.Turtles;

public class Arc : Command
{
    private float startAngle; // ทิศของเต่าตอนเริ่มต้น
    private float displacement; // ค่าติดลบ เมื่อเลี้ยวขวา
    private float endTime;
    private float accumTime = 0;
    private RectangleF rect;
    Vector2 center;
    bool turnLeft;
    float radius;

    PathBuilder path;
    private bool neverAct = true;

    private Turtle turtle;

    public Arc(Turtle turtle, float radius, float angleDegree, bool turnLeft, PathBuilder path)
    {

        this.turtle = turtle;
        this.turnLeft = turnLeft;
        this.radius = radius;
        this.path = path;

        float angleRadian = angleDegree * (MathF.PI / 180);
        endTime = angleRadian * radius / turtle.Speed;
        startAngle = turtle.Direction;

        center = CalcCenter(radius, turtle.DirectionRadian);

        rect = new RectangleF(
                        (PointF)(center - new Vector2(radius, radius)),
                        new SizeF(radius * 2, radius * 2)
            );

        displacement = angleDegree * Sign();
    }

    private int Sign() => turnLeft ? 1 : -1; // if turn right, return -1

    Vector2 CalcCenter(float radius, float angleRadian)
    {
        return turtle.Position + 
                radius 
                * new Vector2(-MathF.Sin(angleRadian), MathF.Cos(angleRadian))
                * Sign();
    }

    public bool Act(float deltaTime, BufferedGraphics myBuffer)
    {
        accumTime += deltaTime;
        Debug.WriteLine(accumTime);

        float direction;
        if (accumTime > endTime)
            accumTime = endTime;

        direction = startAngle + displacement * (accumTime / endTime);

        if (turtle.PenOn)
        {
            var pen = PenCache.Get(turtle.PenColor, turtle.PenSize);
            myBuffer.Graphics.DrawArc(pen, rect, turtle.Direction - 90 * Sign(), direction - turtle.Direction);

            if (neverAct)
            {
                path.AddArc(rect, startAngle - 90 * Sign(), displacement); // left -90, right +90
                neverAct = false;
            }
        }

        turtle.Direction = direction;

        //set turtle position
        var turtleAsRadian = (turtle.Direction) * MathF.PI / 180;
        turtle.InternalPosition = 
            center - radius * Sign() * new Vector2(-MathF.Sin(turtleAsRadian), MathF.Cos(turtleAsRadian));

        return IsFinished();
    }

    public bool IsFinished()
    {
        return accumTime >= endTime;
    }
}
