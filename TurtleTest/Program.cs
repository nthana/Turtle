using System.Diagnostics;

namespace TurtleTest
{
    internal static class Program
    {
        static Form1 CreateUI()
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
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();

            //Console.ReadLine();
            //Debug.WriteLine(Thread.CurrentThread.ManagedThreadId);

            // https://stackoverflow.com/questions/363377/how-do-i-run-a-simple-bit-of-code-in-a-new-thread 
            // is background คือจะถูก kill ถ้า thread อื่นจบการทำงานหมด

/*            Form1 form = CreateUI();
            form.QueueAndWait(new Forward(new PointF(100, 100)));
            form.QueueAndWait(new Forward(new PointF(200, 200)));*/

            Thread.CurrentThread.IsBackground = true;

            var t1 = new Turtle();
            t1.direction = 0.5f;
            t1.fd(300);
            t1.direction = 1f;
            t1.fd(400);

            //TurtleOne.fd();
        }
    }
}