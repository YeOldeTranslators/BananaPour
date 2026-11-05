using Godot;

using BananaPour.Project.Database;

namespace BananaPour.Scene.EditorWorld;

public partial class OptionStageType : OptionButton
{
	public override void _Ready()
	{
		foreach (var option in StageInfo.CategoryNames)
		{
			if (option != "Unknown")
				AddItem(option);
		}
	}
}
