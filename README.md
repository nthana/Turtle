NuGet: https://www.nuget.org/packages/ThanaNita.Turtles

# Example

<img width="418" height="423" alt="image" src="https://github.com/user-attachments/assets/d8f37009-47a5-4883-87db-17ddc2f6b6be" />

## Example Code:
Short form:
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

Long form:
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
# Documentation
## Classes
### One
A static class containing a default turtle (using lazy creation). Normally you will use the default turtle from this class.
### Turtle
The essential class. Can be used to instantiate more than one turtle.
Normally, will be called indirectly from the One class.
### Display
A window form created automatically when the first turtle was created.

## Usages
There are three different ways to use this package.
### A. Static using the One class
```
using static ThanaNita.Turtles.One;
Forward(200);
```
This usage method is short and easy to write.

### B. Explicitly specify the One class
```
using ThanaNita.Turtles;
One.Forward(200);
```
This is more explicit version of the first usage.

### Manually created a turtle
```
using ThanaNita.Turtles;
var t = new Turtle();
t.Forward(200);
```
This is when we want to create the turtle explicitly or create more than one turtle.

# Turtle Commands & Properties
## Turtle Commands:
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

Note: The turtle commands which have animations are: Forward, Backward, TurnLeft, TurnRight, ArcLeft, ArcRight.

## Turtle Properties:
- Position : Vector2    // (x, y) in pixel unit; use  normal geometric coordinate (x point to right, y point to up)
- Direction : float     // angle in degree, counter clockwise from X-Axis (right = 0, up = 90, left = 180, down = 270)
- PenOn : bool          // draw or not draw when the turtle moved
- Speed : float         // speed in pixels/second
- PenColor : Color
- PenSize : float       // pen diameter in pixels
- Visible : bool        // show or hide the turtle image

## A Note on the "Fill" command:
- A path was memorized while using Forward/Backward/ArcLeft/ArcRight.
- That memorized path will be used when the "Fill" command was called.
- The path lines will be auto redrawn again after the fill occur.
- The path will be auto-reset when:
    1. pen size was changed.
    2. pen color was changed.
(To make the behavior the same as PencilCode. And it's easier to implement.)

# Implementation Note
There are 2 threads, the program.cs thread and the UI thread.
- When the program call turtle command for the first time, the UI Thread will be created (in Display.cs).
- The turtle commands that have animations will block the program.cs thread until the UI Thread finished the animation.
  - The AutoResetEvent class is used for managing the blocking thread.