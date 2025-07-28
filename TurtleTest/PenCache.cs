using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThanaNita.Turtles;

public class PenCache
{
    private static Dictionary<PenProperties, Pen> dict = new ();

    public static Pen Get(Color color, float size)
    {
        var key = new PenProperties(color, size);
        if(dict.TryGetValue(key, out var value))
            return value;

        var pen = new Pen(color, size);
        pen.StartCap = System.Drawing.Drawing2D.LineCap.Round;
        pen.EndCap = System.Drawing.Drawing2D.LineCap.Round;
        dict.Add(key, pen);
        return pen;
    }
}

public record struct PenProperties(Color Color, float Size);