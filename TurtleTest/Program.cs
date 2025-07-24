using System.Diagnostics;
using System.Numerics;
using static TurtleTest.TurtleOne;


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

            //Thread.CurrentThread.IsBackground = true;

            /*var t1 = new Turtle();
            t1.direction = 0.5f;
            t1.fd(300);
            t1.direction = 1f;
            t1.fd(400);*/

            t1.position = new Vector2(300, 100);
            t1.pencolor = Color.Red;
            direction = 60f;
            fd(300);

            t1.pencolor = Color.Blue;
            direction = 180f;
            fd(300);

            t1.pencolor = Color.Green;
            direction = -60f;
            fd(300);
        }
    }
}