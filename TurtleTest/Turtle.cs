using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Numerics;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
using TurtleTest;

namespace ThanaNita.Turtles;

public class Turtle
{
    public Vector2 Position { get; set; }
    public float Direction { get; set; } = 90;
    public float Speed { get; set; } = 300f; // ห้าม <= 0; ถ้าเป็น 9999 ขึ้นไป ถือเป็น infinity
    public Color PenColor { get => penColor; set { if (penColor == value) return; penColor = value; ResetPath(); } }
    public float PenSize { get => penSize; set { if (penSize == value) return; penSize = value; ResetPath(); } }
    public bool PenOn { get; set; } = true;
    public bool Visible { get; set; } = true;

    private Color penColor = Color.Black;
    private float penSize = 3;

    private PathBuilder path;
    private void ResetPath()
    {
        path.Reset(penColor, penSize);
    }

    public float DirectionRadian
    {
        get { return Direction * MathF.PI / 180; }
        set { Direction = value * 180 / MathF.PI; }
    }

    private Display form;
    public Turtle(Display form)
    {
        this.form = form;
        this.form.AddTurtle(this);

        path = new PathBuilder(PenColor, PenSize);
    }

    public Turtle()
        : this(StaticDisplay.Value)
    {
    }

    public void Forward(float distant)
    {
        form.QueueAndWait(new Walk(this, distant, path));
    }
    public void Backward(float distant)
    {
        form.QueueAndWait(new Walk(this, -distant, path));
    }
    public void TurnLeft(float angle)
    {
        form.QueueAndWait(new Turn(this, angle));
    }
    public void TurnRight(float angle)
    {
        form.QueueAndWait(new Turn(this, -angle));
    }
    public void Dot(Color color, float size=10)
    {
        form.QueueAndWait(new Dot(this, color, size));
    }
    public void ArcLeft(float radius, float angle)
    {
        form.QueueAndWait(new Arc(this, radius, angle, true));
    }
    public void ArcRight(float radius, float angle)
    {
        form.QueueAndWait(new Arc(this, radius, angle, false));
    }

    /* จุดที่ต่างจาก fill ใน pencilcode
     * - fill จะกินพื้นที่ไปครึ่งหนึ่งของความกว้างของเส้น -> เพื่อความสะดวกในการเขียน   
     *    - และเป็นเพราะ GDI+ คำสั่ง DrawPath มี bug ทำให้หัวเส้นไม่ round ในบางกรณี
     */
    public void Fill(Color color)
    {
        form.QueueAndWait(new Fill(path, color));
    }
}
