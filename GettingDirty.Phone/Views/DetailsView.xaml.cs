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

		private IDetailsViewModel ViewModel { get; set; }

		public DetailsView()
		{
			InitializeComponent();

			ViewModel = DataContext as IDetailsViewModel;
		}

		protected override void OnNavigatedFrom(System.Windows.Navigation.NavigationEventArgs e)
		{
			State[KEY_TITLE] = ViewModel.TaskItem.Title;
			State[KEY_PRIORITY] = ViewModel.TaskItem.Priority;
			State[KEY_DUE_DATE] = ViewModel.TaskItem.DueDate;
			State[KEY_IS_COMPLETED] = ViewModel.TaskItem.IsCompleted;
			State[KEY_DESCRIPTION] = ViewModel.TaskItem.Description;
			
			base.OnNavigatedFrom(e);
		}

		protected override void OnNavigatedTo(System.Windows.Navigation.NavigationEventArgs e)
		{
			base.OnNavigatedTo(e);

			if (NavigationContext.QueryString.ContainsKey("taskId"))
			{
				var taskId = new Guid(NavigationContext.QueryString["taskId"]);

				ViewModel.Load(taskId);
			}
			else
			{
				if (ViewModel.TaskItem == null)
				{
					ViewModel.NewTask();
				}

				object value;
				if (State.TryGetValue(KEY_TITLE, out value))
				{
					ViewModel.TaskItem.Title = (string)value;
				}

				if (State.TryGetValue(KEY_PRIORITY, out value))
				{
					ViewModel.TaskItem.Priority = (Priority)value;
				}

				if (State.TryGetValue(KEY_DUE_DATE, out value))
				{
					ViewModel.TaskItem.DueDate = (DateTime?)value;
				}

				if (State.TryGetValue(KEY_IS_COMPLETED, out value))
				{
					ViewModel.TaskItem.IsCompleted = (bool)value;
				}

				if (State.TryGetValue(KEY_DESCRIPTION, out value))
				{
					ViewModel.TaskItem.Description = (string)value;
				}
			}
		}

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