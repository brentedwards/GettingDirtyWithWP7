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
using GettingDirty.Phone.Views;
using GettingDirty.Core.ViewModels;

namespace GettingDirty.Phone
{
	public partial class MainPage : CorePhoneApplicationPage
	{
		private const string KEY_TITLE = "NewTaskTitle";
		private const string KEY_PRIORITY = "NewTaskPriority";

		private IMainViewModel ViewModel { get; set; }

		// Constructor
		public MainPage()
		{
			InitializeComponent();

			ViewModel = DataContext as IMainViewModel;
		}

		protected override void OnNavigatedFrom(System.Windows.Navigation.NavigationEventArgs e)
		{
			// Save state
			State[KEY_TITLE] = NewTaskTitle.Text;
			State[KEY_PRIORITY] = NewTaskPriority.SelectedItem;

			// Save tasks
			ViewModel.SaveTasks();

			base.OnNavigatedFrom(e);
		}

		protected override void OnNavigatedTo(System.Windows.Navigation.NavigationEventArgs e)
		{
			base.OnNavigatedTo(e);

			// Restore state, if it exists
			object value;
			if (State.TryGetValue(KEY_TITLE, out value))
			{
				NewTaskTitle.Text = value.ToString();
			}

			if (State.TryGetValue(KEY_PRIORITY, out value))
			{
				NewTaskPriority.SelectedItem = value;
			}

			ViewModel.LoadTasks();
		}

		private void NewTask_Click(object sender, EventArgs e)
		{
			NavigationService.Navigate(new Uri("/Views/DetailsView.xaml", UriKind.Relative));
		}
	}
}