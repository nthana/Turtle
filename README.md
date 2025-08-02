Can be installed from NuGet: **ThanaNita.Turtles**

Example:

<img width="418" height="423" alt="image" src="https://github.com/user-attachments/assets/d8f37009-47a5-4883-87db-17ddc2f6b6be" />

Example Code:
```
using static ThanaNita.Turtles.One;

namespace TurtleTest2;

internal static class Program
{
    static void Main()
    {
        Speed = 800;
        PenColor = Color.Blue;
        for (int i = 0; i < 20; ++i)
        {
            Forward(200);
            TurnRight(88);
        }
        Fill(Color.Yellow);
    }
}
```

Or, in short form:
```
using static ThanaNita.Turtles.One;

Speed = 800;
PenColor = Color.Blue;
for (int i = 0; i < 20; ++i)
{
    Forward(200);
    TurnRight(88);
}
Fill(Color.Yellow);
```

Classes:
One : static class contains a default turtle (using lazy creation).
Turtle : can be instantiated more than one turtle.
Display : a window form created when the first turtle was created.


All Turtle Commands:
- Forward / Backward(distance)   	// receive distance in pixel
- TurnLeft / TurnRight(angle)      	// receive angle in degree
- ArcLeft / ArcRight(radius, angle)	// radius in pixel, angle in degree
- Dot(color, diameter)
- Fill(color)
- PenUp() / PenDown()

- SetSpeed(speed)
- SetPenColor(color)
- SetPenSize(size)
- HideTurtle() / ShowTurtle()

All Turtle Properties:
- Position
- Direction
- PenOn
- Speed
- PenColor
- PenSize
- Visible