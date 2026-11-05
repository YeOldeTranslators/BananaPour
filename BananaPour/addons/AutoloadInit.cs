global using Godot.Extension;

using Godot;

namespace BananaPour;

public partial class AutoloadInit : Node
{
    public override void _Ready()
    {
        // Run all methods tagged with [StartupTask] attribute
        var startupRunner = new StartupRunner();
        AddChild(startupRunner);

        // Free self and all lower children
        QueueFree();
    }
}
