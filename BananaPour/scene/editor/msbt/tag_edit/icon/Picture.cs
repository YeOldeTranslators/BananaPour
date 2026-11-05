using Nindot.LMS.Msbt;

using Nindot.LMS.Msbt.TagLib;

namespace BananaPour.Scene.EditorMsbt;

public partial class Picture : TagEditIconBase
{
	public override void SetupScene(MsbtTagElement tag, MsbtPage page)
	{
		base.SetupScene(tag, page);

		var menu = TagEditIconCommon.InitSubmenu<TagSubmenuPictureFont>(Tag);
		SetupSubmenu(menu);
	}
}
