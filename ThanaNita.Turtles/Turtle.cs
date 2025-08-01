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
    // set โดยไม่กระทบต่อ path ( don't close figure)
    internal Vector2 InternalPosition { get => position; set => position = value; }
    public Vector2 Position {
        get => position;
        set { CloseFigure(); position = value; }
    }
    public float Direction { get; set; } = 90;
    public float Speed { get; set; } = 400f; // ห้าม <= 0; ถ้าเป็น 9999 ขึ้นไป ถือเป็น infinity
    public Color PenColor { get => penColor; set { if (penColor == value) return; penColor = value; ResetPath(); } }
    public float PenSize { get => penSize; set { if (penSize == value) return; penSize = value; ResetPath(); } }
    public bool PenOn { get => penOn; set { if (value == false) CloseFigure(); penOn = value; } }
    public bool Visible { get; set; } = true;

    private Vector2 position;
    private Color penColor = Color.Black;
    private float penSize = 3;
    private bool penOn = true;

    private PathBuilder path;

    private void CloseFigure()
    {
        path.CloseFigure();
    }
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
    private Turtle(Display form)
    {
        this.form = form;
        this.form.AddTurtle(this);

        path = new PathBuilder(PenColor, PenSize);
    }

    public Turtle()
        : this(StaticDisplay.Value)
    {
    }

    public void Forward(float distance)
    {
        form.QueueAndWait(new Walk(this, distance, path));
    }
    public void Backward(float distance)
    {
        form.QueueAndWait(new Walk(this, -distance, path));
    }
    public void TurnLeft(float angle)
    {
        form.QueueAndWait(new Turn(this, angle));
    }
    public void TurnRight(float angle)
    {
        form.QueueAndWait(new Turn(this, -angle));
    }
    public void ArcLeft(float radius, float angle)
    {
        form.QueueAndWait(new Arc(this, radius, angle, true, path));
    }
    public void ArcRight(float radius, float angle)
    {
        form.QueueAndWait(new Arc(this, radius, angle, false, path));
    }
    public void Dot(Color color, float diameter = 10)
    {
        form.QueueAndWait(new Dot(this, color, diameter));
    }
    /* 
     * path จะถูก reset() เมื่อ
     * -เรียก fill แต่ละครั้ง 
     * -เปลี่ยนสีปากกา หรือขนาดปากกา
     *
     * figure จะถูก close เมื่อ
     * -แก้ไขค่า Position
     * -ยกปากกา
     */
    public void Fill(Color color)
    {
        form.QueueAndWait(new Fill(this, path, color));
    }
    public void PenUp() { PenOn = false; }
    public void PenDown() { PenOn = true; }
    public void HideTurtle() { Visible = false; }
    public void ShowTurtle() { Visible = true; }
    public void SetPenSize(float size) { PenSize = size; }
    public void SetPenColor(Color color) { PenColor = color; }
    public void SetSpeed(float speed) { Speed = speed; }
}
