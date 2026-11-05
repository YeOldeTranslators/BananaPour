using Godot;
using Nindot.LMS.Msbt.TagLib;

namespace BananaPour.Scene.EditorMsbt;

public partial class TagWheelTagResult(MsbtTagElement tag) : RefCounted
{
    public readonly MsbtTagElement Tag = tag;
}