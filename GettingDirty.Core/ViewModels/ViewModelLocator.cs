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
						_mainViewModel = Ioc.Container.Resolve<IMainViewModel>();
					}
				}
				return _mainViewModel;
			}
		}

		public IDetailsViewModel DetailsViewModel
		{
			get
			{
				IDetailsViewModel detailsViewModel;
				if (IsInDesignMode)
				{
					detailsViewModel = new DesignDetailsViewModel();
				}
				else
				{
					detailsViewModel = Ioc.Container.Resolve<IDetailsViewModel>();
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