using System;
using System.Collections.Generic;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace TurtleTest
{
    // Path can keep only 1 color and 1 line size
    public class PathBuilder
    {
        GraphicsPath path;
        public Color LineColor { get; private set; }
        public float LineSize { get; private set; }

        public PathBuilder(Color lineColor, float lineSize)
        {
            Reset(lineColor, lineSize);
        }

        public void Reset(Color lineColor, float lineSize)
        {
            path = new GraphicsPath();
            path.Reset();
            LineColor = lineColor;
            LineSize = lineSize;
        }

        public void CloseFigure()
        {
            path.CloseFigure();
        }

/*        public GraphicsPath GetPath()
        {
            var oldPath = path;
            //Reset(LineColor, LineSize);
            return oldPath;
        }*/

        public void GraphicsFillPath(Graphics g, Brush brush)
        {
            g.FillPath(brush, path);
        }
        public void GraphicsDrawPath(Graphics g, Pen pen)
        {
            g.DrawPath(pen, path);
        }

        public void AddLine(Vector2 point1, Vector2 point2)
        {
            path.AddLine(point1.X, point1.Y, point2.X, point2.Y);
        }

        public void AddArc(RectangleF rect, float startAngle, float sweep)
        {
            path.AddArc(rect, startAngle, sweep);
        }
    }
}
