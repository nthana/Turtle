
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
// is background ��ͨж١ kill ��� thread ��蹨���÷ӧҹ���

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

/*     * �ش����ҧ�ҡ fill � pencilcode
     * - fill �СԹ��鹷��令���˹�觢ͧ�������ҧ�ͧ��� -> ���ͤ����дǡ㹡����¹   
     *    OK: - a) ��������� GDI+ ����� DrawPath �� bug �������������� round 㹺ҧ�ó�
     *    OK: - b) ����Ҵ��鹴��� drawpath �������鹷�� auto close path �ж١�Ҵ�Դ仴���
     *    ��Ҩ���ѭ�ҹ�� ������ҵ�ͧ�纷�� line ��� arc ������ ��������Ҵ������� turn 
     *    - �������� bug (a) ��з�駻ѭ������Թ ���������� loop (b)
     
     * �ѧ���� //- ��� reset fill ���Դ��������¡�ҡ�Ҵ���
     *   // - ������� path object ����˭��Թ� ?
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