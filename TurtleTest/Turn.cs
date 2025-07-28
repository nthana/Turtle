using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;

namespace ThanaNita.Turtles;

public class Turn : Command
{
    private float startPosition;
    private float displacement;
    private float endTime;
    private float accumTime = 0;

    private Turtle turtle;
    private bool forward;

    public Turn(Turtle turtle, float angleDegree, bool forward = true)
    {
        if (angleDegree < 0)
            throw new Exception("Turtle cannot turn with negative angle.");

        this.forward = forward;
        this.turtle = turtle;

        float speedCoefficient = 1f;
        endTime = angleDegree / (turtle.Speed * speedCoefficient);
        startPosition = turtle.Direction;
        var radian = turtle.DirectionRadian;
        displacement = angleDegree * DirectionValue();
    }

    private int DirectionValue()
    {
        return forward ? 1 : -1;
    }

    public bool Act(float deltaTime, BufferedGraphics myBuffer)
    {
        accumTime += deltaTime;
        if(accumTime > endTime)
            accumTime = endTime;

        var direction = startPosition + displacement * (accumTime/endTime);

        turtle.Direction = direction;

        return IsFinished();
    }

    public bool IsFinished()
    {
        return accumTime >= endTime;
    }
}
