using Godot;
using System;

using BananaPour.Async;
using BananaPour.Project;
using BananaPour.Project.Database;
using BananaPour.Scene.EditorMsbt;

namespace BananaPour.Scene.Home;

public partial class SubtabExtraTools : VBoxContainer
{
    private void OnGenerateDatabaseCheckpointFlag()
	{
		AsyncRunner.Run(GenerateDatabaseCheckpointFlag, AsyncDisplay.Type.GenerateCheckpointDb, "dbgen_checkpoint_flag");
	}
	private void GenerateDatabaseCheckpointFlag(AsyncDisplay display)
	{
		var db = ProjectManager.GetDB();
		CheckpointFlagDbGenerator.Generate(db, display.UpdateProgress);
	}
}
