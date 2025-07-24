using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TurtleTest;

public class Turtle
{
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

    public void fd()
    {
        form.QueueAndWait(new Forward(new PointF(200, 300)));
    }
}

public static class MainTurtle
{
    private static void CheckInit()
    {

    }

    public static void fd()
    {

    }
}
