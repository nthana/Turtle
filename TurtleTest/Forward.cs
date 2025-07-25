using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;

namespace ThanaNita.Turtles;

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

        endTime = distant / turtle.Speed;
        startPosition = turtle.Position;
        var radian = ToRadian(turtle.Direction);
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
        var pen = new Pen(turtle.PenColor, 5);
        pen.StartCap = System.Drawing.Drawing2D.LineCap.Round;
        pen.EndCap = System.Drawing.Drawing2D.LineCap.Round;
        myBuffer.Graphics.DrawLine(pen, (PointF)turtle.Position, (PointF)position);

        turtle.Position = position;

        return IsFinished();
    }

    public bool IsFinished()
    {
        return accumTime >= endTime;
    }
}
