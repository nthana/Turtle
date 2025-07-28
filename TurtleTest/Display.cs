using System.Diagnostics;

namespace ThanaNita.Turtles;

public partial class Display : Form
{
    private System.Windows.Forms.Timer timer = new System.Windows.Forms.Timer();
    private Stopwatch watch = new Stopwatch();

    private ManualResetEvent startedEvent = new ManualResetEvent(false);
    private AutoResetEvent finishCommandEvent = new AutoResetEvent(false);
    private Command? command = null;
    private BufferedGraphics myBuffer;
    private Image turtleImage;

    private List<Turtle> Turtles = new();
    public void AddTurtle(Turtle turtle)
    {
        Turtles.Add(turtle);
    }
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
    public Display()
    {
        InitializeComponent();

        Debug.WriteLine(DoubleBuffered);
        this.DoubleBuffered = true;

        timer.Interval = 1000 / 60;
        timer.Tick += Timer_Tick;
        timer.Enabled = true;
        watch.Start();

        myBuffer = CreateBuf();

        startedEvent.Set();

        turtleImage = Image.FromFile("turtle.png");
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

        DrawTurtles(g);
    }
    private void DrawTurtles(Graphics g)
    {
        for (int i = 0; i < Turtles.Count; i++)
            DrawTurtle(g, Turtles[i]);
    }
    private void DrawTurtle(Graphics g, Turtle turtle)
    {
//        float centerX = 
//        g.TranslateTransform

        var size = turtleImage.Size;
        g.DrawImage(turtleImage, turtle.Position.X - size.Width / 2, turtle.Position.Y - size.Height / 2);
    }

    private void Display_FormClosed(object sender, FormClosedEventArgs e)
    {
        Environment.Exit(0);
    }

    public static Display CreateUIThread()
    {
        Display? form = null;
        var thread = new Thread(() =>
        {
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

    private void Display_Load(object sender, EventArgs e)
    {
    }
}
