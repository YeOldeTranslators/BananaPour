using Godot;

using Nindot.LMS.Msbt.TagLib;
using Nindot.LMS.Msbt.TagLib.Smo;

namespace BananaPour.Scene.EditorMsbt;

public partial class TextAlignment : TagEditScene
{
	private MsbtTagElementTextAlign Tag = null;

	public override void SetupScene(MsbtTagElement tag)
	{
		base.SetupScene(tag);

		Tag = tag as MsbtTagElementTextAlign;

		var option = GetNode<OptionButton>("%Option_TagName");
		option.Selected = (int)Tag.TextAlignment;
	}

	private void SetTagName(int id)
	{
		Tag.TextAlignment = (TagNameTextAlign)id;
	}
}
