using GettingDirty.Core.Container;
using System.ComponentModel;
using GettingDirty.Core.ViewModels.Design;
namespace GettingDirty.Core.ViewModels
{
	public class ViewModelLocator
	{
		private bool IsInDesignMode
		{
			get { return DesignerProperties.IsInDesignTool; }
		}
	}
}