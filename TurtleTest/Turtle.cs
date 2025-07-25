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
    public Vector2 position { get; set; }
    public float Direction { get; set; }    // todo: change unit to degree
    public float speed { get; set; } = 100f; // ห้าม <= 0; ถ้าเป็น 9999 ขึ้นไป ถือเป็น infinity
    public Color pencolor { get; set; } = Color.Black;

    private Display form;
    public Turtle(Display form)
    {
        this.form = form;
    }

    public Turtle()
    {
        form = CreateUI();
    }
    private static Display CreateUI()
    {
        Display? form = null;
        var thread = new Thread(() => {
            //Thread.CurrentThread.IsBackground = false;
            var form1 = new Display();
            form = form1;
            Application.Run(form1);
        });
        thread.Start();

        while (form == null)
            Thread.Sleep(50);

        form!.WaitForStart();
        return form;
    }

    public void Forward(float distant)
    {
        form.QueueAndWait(new Forward(this, distant));
    }
}
