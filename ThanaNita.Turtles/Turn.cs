using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;

namespace ThanaNita.Turtles;

internal class Turn : Command
{
    private float startPosition;
    private float displacement;
    private float endTime;
    private float accumTime = 0;

    private Turtle turtle;

    public Turn(Turtle turtle, float angleDegree)
    {

        this.turtle = turtle;

        float speedCoefficient = 1f;
        endTime = MathF.Abs(angleDegree) / (turtle.Speed * speedCoefficient);
        startPosition = turtle.Direction;
        var radian = turtle.DirectionRadian;
        displacement = angleDegree;
    }

    public bool Act(float deltaTime, BufferedGraphics myBuffer)
    {
        accumTime += deltaTime;
        if(accumTime > endTime)
            accumTime = endTime;

        float interpolation = endTime != 0 ? (accumTime / endTime) : 1;
        float direction = startPosition + displacement * interpolation;

        turtle.Direction = direction;

        return IsFinished();
    }

    public bool IsFinished()
    {
        return accumTime >= endTime;
    }
}
