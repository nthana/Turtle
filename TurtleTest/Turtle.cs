using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace TurtleTest;

public class Turtle
{
    public Vector2 position { get; set; }
    public float direction { get; set; }    // todo: change unit to degree
    public float speed { get; set; } = 100f; // ห้าม <= 0; ถ้าเป็น 9999 ขึ้นไป ถือเป็น infinity
    public Color pencolor { get; set; } = Color.Black;

    private Form1 form;
    public Turtle(Form1 form)
    {
        this.form = form;
    }

    public Turtle()
    {
        form = CreateUI();
    }
    private static Form1 CreateUI()
    {
        Form1? form = null;
        var thread = new Thread(() => {
            //Thread.CurrentThread.IsBackground = false;
            var form1 = new Form1();
            form = form1;
            Application.Run(form1);
        });
        thread.Start();

        while (form == null)
            Thread.Sleep(50);

        form!.WaitForStart();
        return form;
    }

    public void fd(float distant)
    {
        form.QueueAndWait(new Forward(this, distant));
    }
}
