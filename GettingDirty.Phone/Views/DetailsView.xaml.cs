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
using GettingDirty.Core.Models;

namespace GettingDirty.Phone.Views
{
	public partial class DetailsView : CorePhoneApplicationPage
	{
		private const string KEY_TITLE = "Title";
		private const string KEY_PRIORITY = "Priority";
		private const string KEY_DUE_DATE = "DueDate";
		private const string KEY_IS_COMPLETED = "IsCompleted";
		private const string KEY_DESCRIPTION = "Description";

		private DetailsViewModel ViewModel { get; set; }

		public DetailsView()
		{
			InitializeComponent();

			ViewModel = DataContext as DetailsViewModel;
		}

		// TODO: State

		protected override void OnBackKeyPress(System.ComponentModel.CancelEventArgs e)
		{
			base.OnBackKeyPress(e);

			var result = MessageBox.Show("You will lose your changes.", "Are you sure?", MessageBoxButton.OKCancel);
			switch (result)
			{
				case MessageBoxResult.OK:
					NavigationService.GoBack();
					break;

				case MessageBoxResult.Cancel:
					e.Cancel = true;
					break;
			}
		}

		private void Done_Click(object sender, EventArgs e)
		{
			ViewModel.Save();

			NavigationService.GoBack();
		}

		private void Cancel_Click(object sender, EventArgs e)
		{
			NavigationService.GoBack();
		}
	}
}