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

		private IDetailsViewModel _detailsViewModel;
		public IDetailsViewModel DetailsViewModel
		{
			get
			{
				if (_detailsViewModel == null)
				{
					if (IsInDesignMode)
					{
						_detailsViewModel = new DesignDetailsViewModel();
					}
					else
					{
						_detailsViewModel = Ioc.Container.Resolve<IDetailsViewModel>();
					}
				}
				return _detailsViewModel;
			}
		}

		private bool IsInDesignMode
		{
			get { return DesignerProperties.IsInDesignTool; }
		}
	}
}