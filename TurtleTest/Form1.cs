using System.Diagnostics;
using ThanaNita.Turtles;
namespace TurtleTest;

public partial class Form1 : Form
{
    private System.Windows.Forms.Timer timer = new System.Windows.Forms.Timer();
    private Stopwatch watch = new Stopwatch();

    private ManualResetEvent startedEvent = new ManualResetEvent(false);
    private AutoResetEvent finishCommandEvent = new AutoResetEvent(false);
    private Command? command = null;
    private BufferedGraphics myBuffer;
    public void WaitForStart()
    {
        startedEvent.WaitOne();
    }

    // called from other thread
    public void QueueAndWait(Command command)
    {
        if (this.command != null)
            throw new Exception("reassign command while not finished old command.");
        this.command = command;
        finishCommandEvent.WaitOne();
    }

    // called from this thread (UI Thread)
    private void FinishedCommand()
    {
        this.command = null; // reference assignment is atomic in C#
        finishCommandEvent.Set();
    }
    /*private Command? CheckCommand()
    {
        return command;
    }*/
    public Form1()
    {
        InitializeComponent();

        Debug.WriteLine(DoubleBuffered);
        this.DoubleBuffered = true;

        timer.Interval = 1000/60;
        timer.Tick += Timer_Tick;
        timer.Enabled = true;
        watch.Start();

        myBuffer = CreateBuf();

        startedEvent.Set();
    }

    private void Timer_Tick(object? sender, EventArgs e)
    {
        Debug.WriteLine(watch.ElapsedMilliseconds);

        float deltaTime = (float)watch.Elapsed.TotalSeconds;
        watch.Restart();

        if (command != null)
        {
            command.Act(deltaTime, myBuffer);
            if (command.IsFinished())
                FinishedCommand();
        }

        Refresh();
    }
    private BufferedGraphics CreateBuf()
    {
        BufferedGraphics buffer;
        BufferedGraphicsContext currentContext;
        // Gets a reference to the current BufferedGraphicsContext
        currentContext = BufferedGraphicsManager.Current;
        // Creates a BufferedGraphics instance associated with Form1, and with
        // dimensions the same size as the drawing surface of Form1.
        buffer = currentContext.Allocate(this.CreateGraphics(),
           this.DisplayRectangle);

        buffer.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;

        buffer.Graphics.Clear(Color.LightGray);
        //var pen = new Pen(Color.Blue, 15);
        //buffer.Graphics.DrawEllipse(pen, this.DisplayRectangle);

        return buffer;
    }

    private void Form1_KeyDown(object sender, KeyEventArgs e)
    {
        if (e.KeyCode == Keys.Escape)
        {
            this.Close();
        }
    }

    private void Form1_Paint(object sender, PaintEventArgs e)
    {
        Graphics g = e.Graphics;
        myBuffer.Render(g);
    }
}
