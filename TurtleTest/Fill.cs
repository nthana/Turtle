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
    GraphicsPath path;
    Color lineColor;
    float lineSize;
    Color fillColor;
    bool finished = false;
    public Fill(PathBuilder pathBuilder, Color color)
    {
        path = pathBuilder.GetPathAndReset();
        //path.CloseFigure();
        lineColor = pathBuilder.LineColor;
        lineSize = pathBuilder.LineSize;
        fillColor = color;
    }
    public bool Act(float deltaTime, BufferedGraphics myBuffer)
    {
        SolidBrush brush = new SolidBrush(fillColor);
        myBuffer.Graphics.FillPath(brush, path);

        //Pen pen = PenCache.Get(lineColor, lineSize);
        //myBuffer.Graphics.DrawPath(pen, path);

        finished = true;
        return IsFinished();
    }

    public bool IsFinished()
    {
        return finished;
    }
}
