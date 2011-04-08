using GettingDirty.Core.Container;
using System.ComponentModel;
using GettingDirty.Core.ViewModels.Design;
namespace GettingDirty.Core.ViewModels
{
	public class ViewModelLocator
	{
		private MainViewModel _mainViewModel;
		public MainViewModel MainViewModel
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

		public DetailsViewModel DetailsViewModel
		{
			get
			{
				DetailsViewModel detailsViewModel;
				if (IsInDesignMode)
				{
					detailsViewModel = new DesignDetailsViewModel();
				}
				else
				{
					detailsViewModel = Ioc.Container.Resolve<DetailsViewModel>();
				}
				return detailsViewModel;
			}
		}

		private bool IsInDesignMode
		{
			get { return DesignerProperties.IsInDesignTool; }
		}
	}
}