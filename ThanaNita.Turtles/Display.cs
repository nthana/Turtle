using System;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Numerics;
using System.Security.Policy;

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
    Vector2 center;

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

        if (!DisplayCreationOptions.CaptionVisible)
            FormBorderStyle = FormBorderStyle.None;
        Size = DisplayCreationOptions.WindowSize;
        center = new Vector2(ClientSize.Width / 2, ClientSize.Height / 2);

        this.DoubleBuffered = true;

        timer.Interval = 1000 / 60;
        timer.Tick += Timer_Tick;
        timer.Enabled = true;
        watch.Start();

        myBuffer = CreateBuf();

        startedEvent.Set();

        turtleImage = ThanaNita.Turtles.Properties.Resources.TurtleImage; 
                    //Image.FromFile("turtle.png");

        //Debug.WriteLine(ClientSize);
        //Debug.WriteLine(DisplayRectangle);
        //Debug.WriteLine(Screen.PrimaryScreen?.Bounds.Size.Width);
    }

    private void SetWindowPosition()
    {
        if (Screen.PrimaryScreen == null)
            return;

        if (DisplayCreationOptions.RightHandSizeCentered)
        {
            int halfWidth = Screen.PrimaryScreen.Bounds.Size.Width / 2;

            this.Location = new Point(
                halfWidth + (halfWidth - this.Size.Width) / 2,
                (Screen.PrimaryScreen.Bounds.Size.Height - this.Size.Height) / 2
                );
        }
        else
        {
            this.Location = new Point(
                (Screen.PrimaryScreen.Bounds.Size.Width - this.Size.Width) / 2,
                (Screen.PrimaryScreen.Bounds.Size.Height - this.Size.Height) / 2
                );
        }
    }

    private void Timer_Tick(object? sender, EventArgs e)
    {
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

        buffer.Graphics.SmoothingMode = SmoothingMode.AntiAlias;

        buffer.Graphics.Clear(DisplayCreationOptions.ClearColor);

        if(DisplayCreationOptions.GridVisible)
            DrawGrid(buffer.Graphics, center);
        TransformToCenter(buffer.Graphics, center);

        return buffer;
    }

    private void TransformToCenter(Graphics g, Vector2 center)
    {
        g.ScaleTransform(1, -1, MatrixOrder.Append);
        g.TranslateTransform(center.X, center.Y, MatrixOrder.Append);
    }

    // draw before transform
    private void DrawGrid(Graphics g, Vector2 center)
    {
        var grid = 25;
        var size = ClientSize;

        //int grayValue = 200; // 211
        //Color gray = Color.FromArgb(grayValue, grayValue, grayValue);

        var lightGreen = Color.FromArgb(190, 207, 197);//(227, 245, 234);
        var pen = new Pen(lightGreen, 1);

        var veryLightGreen = Color.FromArgb(227, 245, 234);
        var penVeryLight = new Pen(veryLightGreen, 1);

        for (int x = (int)center.X % grid; x < size.Width; x += grid)
            g.DrawLine(pen, x, 0, x, size.Height);

        for (int y = (int)center.Y % grid; y < size.Height; y += grid)
            g.DrawLine(pen,0, y, size.Width, y);

        int bigGrid = 100;
        int delta = 3;
        var brush = new SolidBrush(lightGreen);
        for (int x = (int)center.X % bigGrid; x < size.Width; x += bigGrid)
            for (int y = (int)center.Y % bigGrid; y < size.Height; y += bigGrid)
                g.FillEllipse(brush, new Rectangle(x - delta, y - delta, delta * 2, delta * 2));
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
        if (!turtle.Visible)
            return;

        GraphicsState state = g.Save();

        var size = turtleImage.Size;
        float centerX = turtle.Position.X - size.Width / 2;
        g.TranslateTransform(-size.Width/2, -size.Height/2);
        g.RotateTransform(turtle.Direction + 90, MatrixOrder.Append);
        g.TranslateTransform(turtle.Position.X, turtle.Position.Y, MatrixOrder.Append);
        TransformToCenter(g, center);

        g.DrawImage(turtleImage, 0, 0, turtleImage.Width, turtleImage.Height);

        //g.DrawImage(turtleImage, turtle.Position.X - size.Width / 2, turtle.Position.Y - size.Height / 2);

        g.Restore(state);
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
        SetWindowPosition();
    }
}
