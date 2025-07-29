using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TurtleTest;

namespace ThanaNita.Turtles;

public class Fill : Command
{
    Turtle turtle;
    PathBuilder pathBuilder;
    //GraphicsPath path;
    Color lineColor;
    float lineSize;
    Color fillColor;
    bool finished = false;
    public Fill(Turtle turtle, PathBuilder pathBuilder, Color color)
    {
        this.turtle = turtle;
        this.pathBuilder = pathBuilder;
        //path = pathBuilder.GetPath();
        //path.CloseFigure();
        lineColor = pathBuilder.LineColor;
        lineSize = pathBuilder.LineSize;
        fillColor = color;
    }
    public bool Act(float deltaTime, BufferedGraphics myBuffer)
    {
        SolidBrush brush = new SolidBrush(fillColor);
        pathBuilder.GraphicsFillPath(myBuffer.Graphics, brush);

        Pen pen = PenCache.Get(lineColor, lineSize);
        pathBuilder.GraphicsDrawPath(myBuffer.Graphics, pen);

        pathBuilder.Reset(turtle.PenColor, turtle.PenSize);

        finished = true;
        return IsFinished();
    }

    public bool IsFinished()
    {
        return finished;
    }
}
