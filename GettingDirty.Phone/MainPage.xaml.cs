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

		// TODO: 2. OnNavigatedFrom

		// TODO: 3. OnNavigatedTo

		private void NewTask_Click(object sender, EventArgs e)
		{
			// TODO: 1. Navigate
		}
	}
}