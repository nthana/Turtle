using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;

namespace ThanaNita.Turtles;

public class Dot : Command
{
    private Turtle turtle;
    Color color;
    float size;
    bool finished = false;

    public Dot(Turtle turtle, Color color, float size)
    {
        this.turtle = turtle;
        this.color = color;
        this.size = size;
    }

    public bool Act(float deltaTime, BufferedGraphics myBuffer)
    {
        SolidBrush brush = new SolidBrush(color);
        myBuffer.Graphics.FillEllipse(brush, 
            new RectangleF(turtle.Position.X - size / 2, turtle.Position.Y - size / 2, 
                            size, size));

        finished = true;
        return IsFinished();
    }

    public bool IsFinished()
    {
        return finished;
    }
}
