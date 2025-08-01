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
