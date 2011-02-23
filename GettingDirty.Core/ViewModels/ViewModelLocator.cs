using GettingDirty.Core.Container;
using System.ComponentModel;
using GettingDirty.Core.ViewModels.Design;
namespace GettingDirty.Core.ViewModels
{
	public class ViewModelLocator
	{
		private IMainViewModel _mainViewModel;
		public IMainViewModel MainViewModel
		{
			get
			{
				if (_mainViewModel == null)
				{
					if (IsInDesignMode)
					{
						_mainViewModel = new DesignMainViewModel();
					}
					else
					{
						_mainViewModel = Ioc.Container.Resolve<MainViewModel>();
					}
				}
				return _mainViewModel;
			}
		}

		private bool IsInDesignMode
		{
			get { return DesignerProperties.IsInDesignTool; }
		}
	}
}