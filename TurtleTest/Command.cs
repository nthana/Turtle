using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThanaNita.Turtles;

public interface Command
{
    bool Act(float deltaTime, BufferedGraphics myBuffer);
    bool IsFinished();
}
