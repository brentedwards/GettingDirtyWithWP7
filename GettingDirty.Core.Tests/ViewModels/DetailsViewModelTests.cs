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
using GettingDirty.Core.Tests.Mocks;

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

		private MockMessageBus MessageBus { get; set; }
		private MockTaskRepository TaskRepository { get; set; }

		private DetailsViewModel ViewModel { get; set; }

		[TestInitialize]
		public void Init()
		{
			MessageBus = new MockMessageBus();
			TaskRepository = new MockTaskRepository();

			ViewModel = new DetailsViewModel(MessageBus, TaskRepository);
		}

		[TestMethod]
		public void TaskItem()
		{
			PropertiesChanged = new List<string>();

			var taskItem = new TaskItem();

			ViewModel.PropertyChanged += OnPropertyChanged;
			ViewModel.TaskItem = taskItem;
			ViewModel.PropertyChanged -= OnPropertyChanged;

			Assert.AreSame(taskItem, ViewModel.TaskItem, "TaskItem");
			Assert.IsTrue(PropertiesChanged.Contains("TaskItem"), "TaskItem Property Changed.");
		}

		[TestMethod]
		public void Priorities()
		{
			var priorities = ViewModel.Priorities;

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

			TaskRepository.Tasks = expectedTasks;

			ViewModel.Load(taskId);

			var actualTask = ViewModel.TaskItem;

			Assert.AreEqual(taskId, actualTask.TaskId);
		}

		[TestMethod]
		public void NewTask()
		{
			var expectedTasks = new ObservableCollection<TaskItem>();

			TaskRepository.Tasks = expectedTasks;

			ViewModel.NewTask();

			var actualTask = ViewModel.TaskItem;

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

			TaskRepository.Tasks = expectedTasks;

			// Load the tasks first, then save them.
			ViewModel.Load(taskId);

			// Set the mock repository to null between the load and the save
			// so that we can test that the save was correct.
			TaskRepository.Tasks = null;

			ViewModel.Save();

			Assert.AreEqual(expectedTasks, TaskRepository.Tasks);
		}
	}
}
