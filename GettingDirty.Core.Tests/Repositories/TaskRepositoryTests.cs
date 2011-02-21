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
using GettingDirty.Core.Repositories;

namespace GettingDirty.Core.Tests.Repositories
{
	[TestClass]
	public class TaskRepositoryTests : SilverlightTest
	{
		private class MockIsolatedStorageRepository : IIsolatedStorageRepository
		{
			public object Data { get; set; }
			public String FileName { get; set; }

			public void SaveData<TData>(TData data, string fileName)
			{
				Data = data;
				FileName = fileName;
			}

			public T LoadData<T>(string fileName)
			{
				FileName = fileName;

				return (T) Data;
			}
		}

		[TestMethod]
		public void LoadTasks()
		{
			var expectedTasks = new ObservableCollection<TaskItem>();

			var storageRepository = new MockIsolatedStorageRepository();
			storageRepository.Data = expectedTasks;

			var taskRepository = new TaskRepository(storageRepository);

			var actualTasks = taskRepository.LoadTasks();

			Assert.AreSame(expectedTasks, actualTasks, "Tasks");
			Assert.AreEqual(TaskRepository.FILE_NAME, storageRepository.FileName, "FileName");
		}

		[TestMethod]
		public void SaveTasks()
		{
			var expectedTasks = new ObservableCollection<TaskItem>();

			var storageRepository = new MockIsolatedStorageRepository();
			storageRepository.Data = expectedTasks;

			var taskRepository = new TaskRepository(storageRepository);

			taskRepository.SaveTasks(expectedTasks);

			Assert.AreSame(expectedTasks, storageRepository.Data, "Tasks");
			Assert.AreEqual(TaskRepository.FILE_NAME, storageRepository.FileName, "FileName");
		}
	}
}
