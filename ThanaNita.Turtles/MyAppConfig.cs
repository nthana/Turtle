using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThanaNita.Turtles
{
    internal class MyAppConfig
    {
        private static bool isInit = false;
        public static void Initialize()
        {
            if (isInit)
                return;

            global::System.Windows.Forms.Application.EnableVisualStyles();
            global::System.Windows.Forms.Application.SetCompatibleTextRenderingDefault(false);
            global::System.Windows.Forms.Application.SetHighDpiMode(HighDpiMode.SystemAware);
            isInit = true;
        }
    }
}
