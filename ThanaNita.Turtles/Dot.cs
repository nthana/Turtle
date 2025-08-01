using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;

namespace ThanaNita.Turtles;

internal class Dot : Command
{
    private Turtle turtle;
    Color color;
    float diameter;
    bool finished = false;

    public Dot(Turtle turtle, Color color, float diameter)
    {
        this.turtle = turtle;
        this.color = color;
        this.diameter = diameter;
    }

    public bool Act(float deltaTime, BufferedGraphics myBuffer)
    {
        SolidBrush brush = new SolidBrush(color);
        myBuffer.Graphics.FillEllipse(brush, 
            new RectangleF(turtle.Position.X - diameter / 2, turtle.Position.Y - diameter / 2, 
                            diameter, diameter));

        finished = true;
        return IsFinished();
    }

    public bool IsFinished()
    {
        return finished;
    }
}
