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
        List<GraphicsPath> path = new List<GraphicsPath>();
        public Color LineColor { get; private set; }
        public float LineSize { get; private set; }

        public PathBuilder(Color lineColor, float lineSize)
        {
            Reset(lineColor, lineSize);
        }

        public void Reset(Color lineColor, float lineSize)
        {
            path.Clear();
            path.Add(new GraphicsPath()); // จะมี 1 ตัวเตรียมไว้ก่อนเสมอ
            LineColor = lineColor;
            LineSize = lineSize;
        }

        private GraphicsPath ActivePath => path[path.Count - 1];

        public void CloseFigure() // จะต้องสร้าง path ใหม่
        {
            path.Add(new GraphicsPath());
        }

        public void GraphicsFillPath(Graphics g, Brush brush)
        {
            for(int i=0; i<path.Count; i++)
                g.FillPath(brush, path[i]);
        }
        public void GraphicsDrawPath(Graphics g, Pen pen)
        {
            for (int i = 0; i < path.Count; i++)
                g.DrawPath(pen, path[i]);
        }

        public void AddLine(Vector2 point1, Vector2 point2)
        {
            ActivePath.AddLine(point1.X, point1.Y, point2.X, point2.Y);
        }

        public void AddArc(RectangleF rect, float startAngle, float sweep)
        {
            ActivePath.AddArc(rect, startAngle, sweep);
        }
    }
}
