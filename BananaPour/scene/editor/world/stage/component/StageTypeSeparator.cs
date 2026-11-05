using Godot;
using System;

namespace BananaPour.Scene.EditorWorld;

[SceneUid("uid://crlg0ndcpvyv5")]
public partial class StageTypeSeparator : HBoxContainer
{
    [Export]
    private Label LabelName;

    public StageTypeSeparator Init(string name)
    {
        LabelName.Text = name;
        return this;
    }
}
