using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;
using TurtleTest;

namespace ThanaNita.Turtles;

public class Walk : Command
{
    private Vector2 startPosition;
    private Vector2 displacement;
    private float endTime;
    private float accumTime = 0;
    PathBuilder path;
    private bool neverAct = true;

    private Turtle turtle;

    public Walk(Turtle turtle, float distant, PathBuilder path)
    {
        this.turtle = turtle;
        this.path = path;

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
        float interpolation = endTime != 0 ? (accumTime / endTime) : 1;
        var position = startPosition + displacement * interpolation;

        if (turtle.PenOn)
        {
            var pen = PenCache.Get(turtle.PenColor, turtle.PenSize);
            myBuffer.Graphics.DrawLine(pen, (PointF)turtle.Position, (PointF)position);

            if (neverAct)
            {
                path.AddLine(startPosition, startPosition + displacement);
                neverAct = false;
            }
        }

        turtle.InternalPosition = position;

        return IsFinished();
    }

    public bool IsFinished()
    {
        return accumTime >= endTime;
    }
}
