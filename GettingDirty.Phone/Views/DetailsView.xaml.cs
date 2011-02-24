using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using Microsoft.Phone.Controls;
using GettingDirty.Core.ViewModels;

namespace GettingDirty.Phone.Views
{
	public partial class DetailsView : CorePhoneApplicationPage
	{
		public DetailsView()
		{
			InitializeComponent();
		}

		protected override void OnNavigatedTo(System.Windows.Navigation.NavigationEventArgs e)
		{
			base.OnNavigatedTo(e);

			if (NavigationContext.QueryString.ContainsKey("taskId"))
			{
				var taskId = new Guid(NavigationContext.QueryString["taskId"]);

				var viewModel = DataContext as IDetailsViewModel;
				if (viewModel != null)
				{
					viewModel.Load(taskId);
				}
			}
		}
	}
}