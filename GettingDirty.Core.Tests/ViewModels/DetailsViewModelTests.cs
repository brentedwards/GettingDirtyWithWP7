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
using GettingDirty.Core.Models;
using GettingDirty.Core.ViewModels;
using GettingDirty.Core.Repositories;
using System.Collections.Generic;
using System.ComponentModel;
using System.Collections.ObjectModel;

namespace GettingDirty.Core.Tests.ViewModels
{
	[TestClass]
	public class DetailsViewModelTests : SilverlightTest
	{
		private List<string> PropertiesChanged { get; set; }
		private void OnPropertyChanged(object sender, PropertyChangedEventArgs args)
		{
			PropertiesChanged.Add(args.PropertyName);
		}

		[TestMethod]
		public void TaskItem()
		{
			PropertiesChanged = new List<string>();

			var taskItem = new TaskItem();

			var repository = new MockTaskRepository();
			var viewModel = new DetailsViewModel(repository);

			viewModel.PropertyChanged += OnPropertyChanged;
			viewModel.TaskItem = taskItem;
			viewModel.PropertyChanged -= OnPropertyChanged;

			Assert.AreSame(taskItem, viewModel.TaskItem, "TaskItem");
			Assert.IsTrue(PropertiesChanged.Contains("TaskItem"), "TaskItem Property Changed.");
		}

		[TestMethod]
		public void Priorities()
		{
			var repository = new MockTaskRepository();
			var viewModel = new DetailsViewModel(repository);

			var priorities = viewModel.Priorities;

			// Make sure that all the priority options are returned.
			Assert.AreEqual(3, priorities.Length, "Length");
			Assert.AreEqual(Priority.High, priorities[0], "High");
			Assert.AreEqual(Priority.Medium, priorities[1], "Medium");
			Assert.AreEqual(Priority.Low, priorities[2], "Low");
		}

		[TestMethod]
		public void Load()
		{
			var taskId = Guid.NewGuid();
			var expectedTasks = new ObservableCollection<TaskItem>();
			expectedTasks.Add(new TaskItem { TaskId = taskId });

			var repository = new MockTaskRepository()
			{
				Tasks = expectedTasks
			};
			var viewModel = new DetailsViewModel(repository);

			viewModel.Load(taskId);

			var actualTask = viewModel.TaskItem;

			Assert.AreEqual(taskId, actualTask.TaskId);
		}

		[TestMethod]
		public void NewTask()
		{
			var expectedTasks = new ObservableCollection<TaskItem>();

			var repository = new MockTaskRepository()
			{
				Tasks = expectedTasks
			};
			var viewModel = new DetailsViewModel(repository);

			viewModel.NewTask();

			var actualTask = viewModel.TaskItem;

			// Make sure the time stamp is only a few seconds old so we
			// don't have random fails from checking exact equality when
			// the milliseconds have ticked between creation and the check.
			Assert.IsTrue(actualTask.CreatedDate > DateTime.Now.AddSeconds(-5));
		}

		[TestMethod]
		public void Save()
		{
			var taskId = Guid.NewGuid();
			var expectedTasks = new ObservableCollection<TaskItem>();
			expectedTasks.Add(new TaskItem { TaskId = taskId });

			var repository = new MockTaskRepository()
			{
				Tasks = expectedTasks
			};
			var viewModel = new DetailsViewModel(repository);

			// Load the tasks first, then save them.
			viewModel.Load(taskId);

			// Set the mock repository to null between the load and the save
			// so that we can test that the save was correct.
			repository.Tasks = null;

			viewModel.Save();

			Assert.AreEqual(expectedTasks, repository.Tasks);
		}
	}
}
