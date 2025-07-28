using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using TurtleTest;

namespace ThanaNita.Turtles;

public class Turtle
{
    public Vector2 Position { get; set; }
    public float Direction { get; set; }    // todo: change unit to degree
    public float Speed { get; set; } = 100f; // ห้าม <= 0; ถ้าเป็น 9999 ขึ้นไป ถือเป็น infinity
    public Color PenColor { get; set; } = Color.Black;
    public float PenSize { get; set; } = 10;

    private Display form;
    public Turtle(Display form)
    {
        this.form = form;
        this.form.AddTurtle(this);
    }

    public Turtle()
        : this(StaticDisplay.Value)
    {
    }

    public void Forward(float distant)
    {
        form.QueueAndWait(new Forward(this, distant));
    }
    public void Backward(float distant)
    {
        form.QueueAndWait(new Forward(this, distant, false));
    }
}
