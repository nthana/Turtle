using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThanaNita.Turtles;

public static class DisplayCreationOptions
{
        // option settings used when create a display
    public static bool GridVisible { get; set; } = true;
    public static Size WindowSize { get; set; } = new Size(850, 1000);
    public static bool RightHandSizeCentered { get; set; } = true;
    public static bool CaptionVisible { get; set; } = true;
    public static Color ClearColor { get; set; } = Color.White;
}
