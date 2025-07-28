using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;

namespace ThanaNita.Turtles;

public class Walk : Command
{
    private Vector2 startPosition;
    private Vector2 displacement;
    private float endTime;
    private float accumTime = 0;

    private Turtle turtle;

    public Walk(Turtle turtle, float distant)
    {
        this.turtle = turtle;

        endTime = MathF.Abs(distant) / turtle.Speed;
        startPosition = turtle.Position;
        var radian = turtle.DirectionRadian;
        displacement = new Vector2(MathF.Cos(radian), MathF.Sin(radian)) * distant;
    }

    public bool Act(float deltaTime, BufferedGraphics myBuffer)
    {
        accumTime += deltaTime;
        if(accumTime > endTime)
            accumTime = endTime;

        // todo: recheck rounding error
        var position = startPosition + displacement * (accumTime/endTime);

        if (turtle.PenOn)
        {
            var pen = PenCache.Get(turtle.PenColor, turtle.PenSize);
            myBuffer.Graphics.DrawLine(pen, (PointF)turtle.Position, (PointF)position);
        }

        turtle.Position = position;

        return IsFinished();
    }

    public bool IsFinished()
    {
        return accumTime >= endTime;
    }
}
