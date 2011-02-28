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
using Microsoft.Silverlight.Testing;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.ObjectModel;
using GettingDirty.Core.Models;
using GettingDirty.Core.ViewModels;
using System.Collections.Generic;
using System.ComponentModel;

namespace GettingDirty.Core.Tests.ViewModels
{
	[TestClass]
	public class MainViewModelTests : SilverlightTest
	{
		private List<string> PropertiesChanged { get; set; }
		private void OnPropertyChanged(object sender, PropertyChangedEventArgs args)
		{
			PropertiesChanged.Add(args.PropertyName);
		}

		[TestMethod]
		public void Tasks()
		{
			var expectedTasks = new ObservableCollection<TaskItem>();

			var repository = new MockTaskRepository()
			{
				Tasks = expectedTasks
			};
			var viewModel = new MainViewModel(repository);

			var actualTasks = viewModel.Tasks;

			Assert.AreSame(expectedTasks, actualTasks);
		}

		[TestMethod]
		public void NewTaskTitle()
		{
			PropertiesChanged = new List<string>();

			var repository = new MockTaskRepository();
			var viewModel = new MainViewModel(repository);

			var expectedTaskTitle = Guid.NewGuid().ToString();

			viewModel.PropertyChanged += OnPropertyChanged;
			viewModel.NewTaskTitle = expectedTaskTitle;
			viewModel.PropertyChanged -= OnPropertyChanged;

			Assert.AreEqual(expectedTaskTitle, viewModel.NewTaskTitle);
		}

		[TestMethod]
		public void NewTaskPriority()
		{
			PropertiesChanged = new List<string>();

			var repository = new MockTaskRepository();
			var viewModel = new MainViewModel(repository);

			var expectedTaskPriority = Priority.High;

			viewModel.PropertyChanged += OnPropertyChanged;
			viewModel.NewTaskPriority = expectedTaskPriority;
			viewModel.PropertyChanged -= OnPropertyChanged;

			Assert.AreEqual(expectedTaskPriority, viewModel.NewTaskPriority);
		}

		[TestMethod]
		public void AddTask()
		{
			var expectedTasks = new ObservableCollection<TaskItem>();

			var repository = new MockTaskRepository()
			{
				Tasks = expectedTasks
			};
			var viewModel = new MainViewModel(repository);

			var expectedTaskTitle = Guid.NewGuid().ToString();
			viewModel.NewTaskTitle = expectedTaskTitle;
			viewModel.NewTaskPriority = Priority.High;

			viewModel.AddTask();

			var actualTasks = viewModel.Tasks;

			Assert.AreEqual(expectedTaskTitle, actualTasks[0].Title, "Title");
			Assert.AreEqual(Priority.High, actualTasks[0].Priority, "Priority");

			// Make sure the inputs were reset too.
			Assert.AreEqual(String.Empty, viewModel.NewTaskTitle, "NewTaskTitle");
			Assert.AreEqual(Priority.Medium, viewModel.NewTaskPriority, "NewTaskPriority");
		}

		[TestMethod]
		public void EditTask()
		{
			Assert.Fail("TODO");
		}

		[TestMethod]
		public void DeleteTask()
		{
			var taskItem = new TaskItem();
			var expectedTasks = new ObservableCollection<TaskItem>();
			expectedTasks.Add(taskItem);

			var repository = new MockTaskRepository()
			{
				Tasks = expectedTasks
			};
			var viewModel = new MainViewModel(repository);

			viewModel.DeleteTask(taskItem);

			var actualTasks = viewModel.Tasks;

			Assert.IsFalse(actualTasks.Contains(taskItem));
		}

		[TestMethod]
		public void LoadTasks()
		{
			PropertiesChanged = new List<string>();

			var repository = new MockTaskRepository();
			var viewModel = new MainViewModel(repository);

			viewModel.PropertyChanged += OnPropertyChanged;
			viewModel.LoadTasks();
			viewModel.PropertyChanged -= OnPropertyChanged;

			Assert.IsTrue(PropertiesChanged.Contains("Tasks"));
		}

		[TestMethod]
		public void SaveTasks()
		{
			var expectedTasks = new ObservableCollection<TaskItem>();

			var repository = new MockTaskRepository()
			{
				Tasks = expectedTasks
			};
			var viewModel = new MainViewModel(repository);

			// Have the view model load the tasks.
			var tasks = viewModel.Tasks;

			// Set the mock repository to null between the load and the save
			// so that we can test that the save was correct.
			repository.Tasks = null;

			viewModel.SaveTasks();

			Assert.AreSame(expectedTasks, repository.Tasks);
		}
	}
}
