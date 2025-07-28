using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;

namespace ThanaNita.Turtles;

public class Arc : Command
{
    private float startAngle;
    private float displacement;
    private float endTime;
    private float accumTime = 0;
    private RectangleF rect;
    bool turnRight;

    private Turtle turtle;

    public Arc(Turtle turtle, float radius, float angleDegree, bool turnRight = true)
    {

        this.turtle = turtle;
        this.turnRight = turnRight;

        float speedCoefficient = 1f;
        endTime = MathF.Abs(angleDegree) / (turtle.Speed * speedCoefficient);
        startAngle = turtle.Direction;
        var angleRadian = turtle.DirectionRadian;

        var center = CalcCenter(radius, angleRadian, turnRight);

        rect = new RectangleF(
                        (PointF)(center - new Vector2(radius, radius)),
                        new SizeF(radius * 2, radius * 2)
            );

        displacement = angleDegree * (!turnRight ? 1: -1);
    }

    Vector2 CalcCenter(float radius, float angleRadian, bool turnRight)
    {
        Vector2 center;
        if (!turnRight)
        {
            center = turtle.Position + radius * new Vector2(
                -MathF.Sin(angleRadian), MathF.Cos(angleRadian));
        }
        else
        {
            center = turtle.Position + radius * new Vector2(
                MathF.Sin(angleRadian), -MathF.Cos(angleRadian));
        }
        return center;
    }

    public bool Act(float deltaTime, BufferedGraphics myBuffer)
    {
        accumTime += deltaTime;
        if(accumTime > endTime)
            accumTime = endTime;

        var partialDisplacement = displacement * (accumTime / endTime);
        var direction = startAngle + partialDisplacement;

        if (turtle.PenOn)
        {
            var pen = PenCache.Get(turtle.PenColor, turtle.PenSize);

            if( !turnRight)
                myBuffer.Graphics.DrawArc(pen, rect, startAngle-90, partialDisplacement);
            else
                myBuffer.Graphics.DrawArc(pen, rect, startAngle + 90, partialDisplacement);
        }

        turtle.Direction = direction;


        return IsFinished();
    }

    public bool IsFinished()
    {
        return accumTime >= endTime;
    }
}
