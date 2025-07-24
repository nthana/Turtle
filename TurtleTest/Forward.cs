using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;

namespace TurtleTest;

public class Forward : Command
{
    private Vector2 startPosition;
    private Vector2 displacement;
    private float endTime;
    private float accumTime = 0;

    private Turtle turtle;

    public Forward(Turtle turtle, float distant)
    {
        this.turtle = turtle;

        endTime = distant / turtle.speed;
        startPosition = turtle.position;
        var radian = ToRadian(turtle.direction);
        displacement = new Vector2(MathF.Cos(radian), MathF.Sin(radian)) * distant;
    }

    private float ToRadian(float direction)
    {
        return direction * MathF.PI / 180;
    }

    public bool Act(float deltaTime, BufferedGraphics myBuffer)
    {
        accumTime += deltaTime;
        if(accumTime > endTime)
            accumTime = endTime;

        // todo: recheck rounding error
        var position = startPosition + displacement * (accumTime/endTime);
        var pen = new Pen(turtle.pencolor, 5);
        myBuffer.Graphics.DrawLine(pen, (PointF)turtle.position, (PointF)position);

        turtle.position = position;

        return IsFinished();
    }

    public bool IsFinished()
    {
        return accumTime >= endTime;
    }
}
