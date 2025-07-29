using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using TurtleTest;

namespace ThanaNita.Turtles;

public class Arc : Command
{
    private float startAngle;
    private float displacement;
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

        float speedCoefficient = 1f;
        endTime = MathF.Abs(angleDegree) / (turtle.Speed * speedCoefficient);
        startAngle = turtle.Direction;
        var angleRadian = turtle.DirectionRadian;

        center = CalcCenter(radius, angleRadian);

        rect = new RectangleF(
                        (PointF)(center - new Vector2(radius, radius)),
                        new SizeF(radius * 2, radius * 2)
            );

        displacement = angleDegree * (turnLeft ? 1: -1);
    }

    Vector2 CalcCenter(float radius, float angleRadian)
    {
        Vector2 center;
        if (turnLeft)
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

        var direction = startAngle + displacement * (accumTime / endTime);

        if (turtle.PenOn)
        {
            var pen = PenCache.Get(turtle.PenColor, turtle.PenSize);

            if (turnLeft)
                myBuffer.Graphics.DrawArc(pen, rect, turtle.Direction - 90, direction - turtle.Direction);
            else
            {
                float sweep = turtle.Direction - direction;
                myBuffer.Graphics.DrawArc(pen, rect, turtle.Direction + 90 - sweep, sweep);
            }

            if (neverAct)
            {
                if (turnLeft)
                    path.AddArc(rect, startAngle-90, displacement);
                else
                    path.AddArc(rect, direction+90, displacement);
                    neverAct = false;
            }
        }

        turtle.Direction = direction;

        //set turtle position
        if (turnLeft)
        {
            var directionAsRadian = (turtle.Direction) * MathF.PI / 180;
            turtle.InternalPosition = center - radius * new Vector2(
                        -MathF.Sin(directionAsRadian), MathF.Cos(directionAsRadian));
        }
        else
        {
            var directionAsRadian = (turtle.Direction) * MathF.PI / 180;
            turtle.InternalPosition = center - radius * new Vector2(
                        MathF.Sin(directionAsRadian), -MathF.Cos(directionAsRadian));

        }


        return IsFinished();
    }

    public bool IsFinished()
    {
        return accumTime >= endTime;
    }
}
