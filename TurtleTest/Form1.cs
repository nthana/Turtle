using System.Diagnostics;

namespace TurtleTest
{
    public partial class Form1 : Form
    {
        private System.Windows.Forms.Timer timer = new System.Windows.Forms.Timer();
        private Stopwatch watch = new Stopwatch();

        private PointF position = new PointF(100, 100);
        private PointF v = new PointF(80, 30);

        private ManualResetEvent startedEvent = new ManualResetEvent(false);
        private BufferedGraphics myBuffer;
        public void WaitForStart()
        {
            startedEvent.WaitOne();
        }
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

            PointF pos2 = position + (SizeF)((System.Numerics.Vector2)v * (float)watch.Elapsed.TotalSeconds);
            watch.Restart();

            var pen = new Pen(Color.Red, 5);
            myBuffer.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
            myBuffer.Graphics.DrawLine(pen, position, pos2);

            position = pos2;

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

            buffer.Graphics.Clear(Color.LightGray);
            var pen = new Pen(Color.Blue, 15);
            buffer.Graphics.DrawEllipse(pen, this.DisplayRectangle);
            return buffer;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Debug.WriteLine(Thread.CurrentThread.ManagedThreadId);
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
}
