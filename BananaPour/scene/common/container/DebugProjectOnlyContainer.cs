using Godot;
using BananaPour.Project;

namespace BananaPour;

[GlobalClass]
[Icon("res://asset/material/debug/debug.svg")]
public partial class DebugProjectOnlyContainer : VBoxContainer
{
	public override void _EnterTree()
	{
		if (!ProjectManager.IsProjectDebug())
			QueueFree();
	}
}
