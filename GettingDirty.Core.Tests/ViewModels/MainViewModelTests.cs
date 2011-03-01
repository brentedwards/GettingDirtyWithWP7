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
using MvvmFabric.Messaging;
using GettingDirty.Core.Tests.Mocks;
using MvvmFabric.Xaml;

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

		private MockMessageBus MessageBus { get; set; }
		private MockTaskRepository TaskRepository { get; set; }

		private MainViewModel ViewModel { get; set;}

		[TestInitialize]
		public void Init()
		{
			MessageBus = new MockMessageBus();
			TaskRepository = new MockTaskRepository();

			ViewModel = new MainViewModel(MessageBus, TaskRepository);
		}

		[TestMethod]
		public void Tasks()
		{
			var expectedTasks = new ObservableCollection<TaskItem>();

			TaskRepository.Tasks = expectedTasks;

			var actualTasks = ViewModel.Tasks;

			Assert.AreSame(expectedTasks, actualTasks);
		}

		[TestMethod]
		public void NewTaskTitle()
		{
			PropertiesChanged = new List<string>();

			var expectedTaskTitle = Guid.NewGuid().ToString();

			ViewModel.PropertyChanged += OnPropertyChanged;
			ViewModel.NewTaskTitle = expectedTaskTitle;
			ViewModel.PropertyChanged -= OnPropertyChanged;

			Assert.AreEqual(expectedTaskTitle, ViewModel.NewTaskTitle);
		}

		[TestMethod]
		public void NewTaskPriority()
		{
			PropertiesChanged = new List<string>();

			var expectedTaskPriority = Priority.High;

			ViewModel.PropertyChanged += OnPropertyChanged;
			ViewModel.NewTaskPriority = expectedTaskPriority;
			ViewModel.PropertyChanged -= OnPropertyChanged;

			Assert.AreEqual(expectedTaskPriority, ViewModel.NewTaskPriority);
		}

		[TestMethod]
		public void AddTask()
		{
			var expectedTasks = new ObservableCollection<TaskItem>();

			TaskRepository.Tasks = expectedTasks;

			var expectedTaskTitle = Guid.NewGuid().ToString();
			ViewModel.NewTaskTitle = expectedTaskTitle;
			ViewModel.NewTaskPriority = Priority.High;

			ViewModel.AddTask();

			var actualTasks = ViewModel.Tasks;

			Assert.AreEqual(expectedTaskTitle, actualTasks[0].Title, "Title");
			Assert.AreEqual(Priority.High, actualTasks[0].Priority, "Priority");

			// Make sure the inputs were reset too.
			Assert.AreEqual(String.Empty, ViewModel.NewTaskTitle, "NewTaskTitle");
			Assert.AreEqual(Priority.Medium, ViewModel.NewTaskPriority, "NewTaskPriority");
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

			TaskRepository.Tasks = expectedTasks;

			var args = new ExecuteEventArgs() { MethodParameter = taskItem };
			ViewModel.DeleteTask(null, args);

			var actualTasks = ViewModel.Tasks;

			Assert.IsFalse(actualTasks.Contains(taskItem));
		}

		[TestMethod]
		public void LoadTasks()
		{
			PropertiesChanged = new List<string>();

			ViewModel.PropertyChanged += OnPropertyChanged;
			ViewModel.LoadTasks();
			ViewModel.PropertyChanged -= OnPropertyChanged;

			Assert.IsTrue(PropertiesChanged.Contains("Tasks"));
		}

		[TestMethod]
		public void SaveTasks()
		{
			var expectedTasks = new ObservableCollection<TaskItem>();

			TaskRepository.Tasks = expectedTasks;

			// Have the view model load the tasks.
			var tasks = ViewModel.Tasks;

			// Set the mock repository to null between the load and the save
			// so that we can test that the save was correct.
			TaskRepository.Tasks = null;

			ViewModel.SaveTasks();

			Assert.AreSame(expectedTasks, TaskRepository.Tasks);
		}
	}
}
