
namespace ThanaNita.Turtles;

public interface Command
{
    bool Act(float deltaTime, BufferedGraphics myBuffer);
    bool IsFinished();
}
