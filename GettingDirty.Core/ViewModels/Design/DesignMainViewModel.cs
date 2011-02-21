using System;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using GettingDirty.Core.ViewModels;
using GalaSoft.MvvmLight.Command;
using System.Collections.ObjectModel;
using GettingDirty.Core.Models;

namespace GettingDirty.Core.ViewModels.Design
{
	public class DesignMainViewModel : IMainViewModel
	{
		public RelayCommand ExecutionModelCommand
		{
			get { return null; }
		}

		public string ApplicationTitle
		{
			get { return "Getting Dirty with WP7"; }
		}

		public string PageName
		{
			get { return "Tasks"; }
		}

		public ObservableCollection<TaskItem> Tasks { get; private set; }

		public DesignMainViewModel()
		{
			var tasks = new ObservableCollection<TaskItem>();
			tasks.Add(
				new TaskItem()
				{
					CreatedDate = DateTime.Now.AddDays(-1),
					DueDate = DateTime.Now.AddDays(1),
					Title = "Low Priority Task",
					Priority = Priority.Low,
					Description = "Low Priority Task"
				});
			
			tasks.Add(
				new TaskItem()
				{
					CreatedDate = DateTime.Now.AddDays(-1),
					DueDate = DateTime.Now.AddDays(1),
					Title = "Medium Priority Task",
					Priority = Priority.Medium,
					Description = "Medium Priority Task"
				});

			tasks.Add(
				new TaskItem()
				{
					CreatedDate = DateTime.Now.AddDays(-1),
					DueDate = DateTime.Now.AddDays(1),
					Title = "High Priority Task",
					Priority = Priority.High,
					Description = "High Priority Task"
				});

			tasks.Add(
				new TaskItem()
				{
					CreatedDate = DateTime.Now.AddDays(-1),
					DueDate = DateTime.Now.AddDays(1),
					Title = "Completed Task",
					Priority = Priority.Low,
					Description = "Completed Task",
					IsCompleted = true
				});

			tasks.Add(
				new TaskItem()
				{
					CreatedDate = DateTime.Now.AddDays(-3),
					DueDate = DateTime.Now.AddDays(-1),
					Title = "Overdue Task with a really long name that should wrap to the next line if I've done things correctly",
					Priority = Priority.Low,
					Description = "Overdue Task"
				});

			Tasks = tasks;
		}
	}
}
