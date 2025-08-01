
/// <summary>
///  The main entry point for the application.
/// </summary>
//[STAThread]
//static void Main()
//{
// To customize application configuration such as set high DPI settings or default font,
// see https://aka.ms/applicationconfiguration.
//	ApplicationConfiguration.Initialize();

//Console.ReadLine();
//Debug.WriteLine(Thread.CurrentThread.ManagedThreadId);

// https://stackoverflow.com/questions/363377/how-do-i-run-a-simple-bit-of-code-in-a-new-thread 
// is background คือจะถูก kill ถ้า thread อื่นจบการทำงานหมด

//Thread.CurrentThread.IsBackground = true;

/*var t1 = new Turtle();
t1.direction = 0.5f;
t1.fd(300);
t1.direction = 1f;
t1.fd(400);*/

/*
    private void Form1_Load(object sender, EventArgs e)
    {
        //Debug.WriteLine(Thread.CurrentThread.ManagedThreadId);
    }

 */

//        if (distant < 0)
//            throw new Exception("Turtle cannot walk with negative distance.");

//var pen = new Pen(Color.Blue, 15);
//buffer.Graphics.DrawEllipse(pen, this.DisplayRectangle);


/*        public GraphicsPath GetPath()
        {
            var oldPath = path;
            //Reset(LineColor, LineSize);
            return oldPath;
        }*/

/*     * จุดที่ต่างจาก fill ใน pencilcode
     * - fill จะกินพื้นที่ไปครึ่งหนึ่งของความกว้างของเส้น -> เพื่อความสะดวกในการเขียน   
     *    OK: - a) และเป็นเพราะ GDI+ คำสั่ง DrawPath มี bug ทำให้หัวเส้นไม่ round ในบางกรณี
     *    OK: - b) การวาดเส้นด้วย drawpath พบว่าเส้นที่ auto close path จะถูกวาดติดไปด้วย
     *    ถ้าจะแก้ปัญหานี้ ทำโดยเราต้องเก็บทั้ง line และ arc ทั้งหมด แล้วสั่งวาดทั้งหมดใน turn 
     *    - จะแก้ได้ทั้ง bug (a) และทั้งปัญหาเส้นเกิน เวลามีหลาย loop (b)
     
     * ยังไม่ทำ //- การ reset fill จะเกิดขึ้นเมื่อยกปากกาด้วย
     *   // - เพื่อให้ path object ไม่ใหญ่เกินไป ?
*/

//float sweep = turtle.Direction - direction;
//myBuffer.Graphics.DrawArc(pen, rect, turtle.Direction + 90 - sweep, sweep);


/*
internal static partial class ApplicationConfiguration
{
    /// <summary>
    ///  Bootstrap the application as follows:
    ///  <code>
    ///  global::System.Windows.Forms.Application.EnableVisualStyles();
    ///  global::System.Windows.Forms.Application.SetCompatibleTextRenderingDefault(false);
    ///  global::System.Windows.Forms.Application.SetHighDpiMode(HighDpiMode.SystemAware);
    /// </code>
    /// </summary>
    public static void Initialize()
    {
        global::System.Windows.Forms.Application.EnableVisualStyles();
        global::System.Windows.Forms.Application.SetCompatibleTextRenderingDefault(false);
        global::System.Windows.Forms.Application.SetHighDpiMode(HighDpiMode.SystemAware);
    }
}

 */