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
    public float Speed { get; set; } = 300f; // ห้าม <= 0; ถ้าเป็น 9999 ขึ้นไป ถือเป็น infinity
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
        form.QueueAndWait(new Arc(this, radius, angle, true, path));
    }
    public void ArcRight(float radius, float angle)
    {
        form.QueueAndWait(new Arc(this, radius, angle, false, path));
    }

    /* จุดที่ต่างจาก fill ใน pencilcode
     * - fill จะกินพื้นที่ไปครึ่งหนึ่งของความกว้างของเส้น -> เพื่อความสะดวกในการเขียน   
     *    OK: - a) และเป็นเพราะ GDI+ คำสั่ง DrawPath มี bug ทำให้หัวเส้นไม่ round ในบางกรณี
     *    - b) การวาดเส้นด้วย drawpath พบว่าเส้นที่ auto close path จะถูกวาดติดไปด้วย
     *    ถ้าจะแก้ปัญหานี้ ทำโดยเราต้องเก็บทั้ง line และ arc ทั้งหมด แล้วสั่งวาดทั้งหมดใน turn 
     *    - จะแก้ได้ทั้ง bug (a) และทั้งปัญหาเส้นเกิน เวลามีหลาย loop (b)
     
     * ยังไม่ทำ //- การ reset fill จะเกิดขึ้นเมื่อยกปากกาด้วย
     *   // - เพื่อให้ path object ไม่ใหญ่เกินไป ?
     *   
     * path object จะถูก reset() เมื่อ
     * -เรียก fill แต่ละครั้ง 
     *
     * figure จะถูก close เมื่อ
     * // -แก้ไขค่า position   -> ไม่ได้ เพราะจะทำให้ทุกอย่างที่ปรับตำแหน่งเต่าทีละนิด มีปัญหาหมด
     * -ยกปากกา
     */
    public void Fill(Color color)
    {
        form.QueueAndWait(new Fill(this, path, color));
    }
}
