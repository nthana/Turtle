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
        var direction = turtle.direction;
        displacement = new Vector2(MathF.Cos(direction), MathF.Sin(direction)) * distant;
    }

    public bool Act(float deltaTime, BufferedGraphics myBuffer)
    {
        accumTime += deltaTime;
        if(accumTime > endTime)
            accumTime = endTime;

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
