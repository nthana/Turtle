using System.Diagnostics;

namespace TurtleTest
{
    internal static class Program
    {
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
            Form1? form = null;
            var thread = new Thread(() => {
                //Thread.CurrentThread.IsBackground = false;
                var form1 = new Form1();
                form = form1;
                Application.Run(form1);
            });
            thread.Start();

            while (form == null)
                Thread.Sleep(100);

            form!.WaitForStart();

            //Application.Run(new Form1());
            DrawLine();
        }

        static void DrawLine()
        {

        }
    }
}