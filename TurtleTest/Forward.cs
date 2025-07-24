using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TurtleTest;

public class Forward : Command
{
    private PointF position = new PointF(100, 100);
    private PointF v = new PointF(80, 30);

    public Forward(PointF pos)
    {
        this.position = pos;
    }

    public bool Act(float deltaTime, BufferedGraphics myBuffer)
    {
        PointF pos2 = position + (SizeF)((System.Numerics.Vector2)v * deltaTime);
        var pen = new Pen(Color.Red, 5);
        myBuffer.Graphics.DrawLine(pen, position, pos2);

        position = pos2;

        return IsFinished();
    }

    public bool IsFinished()
    {
        return position.X >= 400;
    }
}
