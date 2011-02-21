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
using System.Collections.Generic;
using GettingDirty.Core.Models;
using System.ComponentModel;

namespace GettingDirty.Core.Tests.Models
{
	[TestClass]
	public class TaskItemTests : SilverlightTest
	{
		private List<String> _propertiesChanged;
		private void OnPropertyChanged(object sender, PropertyChangedEventArgs args)
		{
			_propertiesChanged.Add(args.PropertyName);
		}

		[TestMethod]
		public void Title()
		{
			_propertiesChanged = new List<String>();
			var title = Guid.NewGuid().ToString();

			var taskItem = new TaskItem();

			taskItem.PropertyChanged += OnPropertyChanged;
			taskItem.Title = title;
			taskItem.PropertyChanged -= OnPropertyChanged;

			Assert.AreEqual(title, taskItem.Title, "Title");
			Assert.IsTrue(_propertiesChanged.Contains("Title"), "Title Property Changed");
		}

		[TestMethod]
		public void Description()
		{
			_propertiesChanged = new List<String>();
			var description = Guid.NewGuid().ToString();

			var taskItem = new TaskItem();

			taskItem.PropertyChanged += OnPropertyChanged;
			taskItem.Description = description;
			taskItem.PropertyChanged -= OnPropertyChanged;

			Assert.AreEqual(description, taskItem.Description, "Description");
			Assert.IsTrue(_propertiesChanged.Contains("Description"), "Description Property Changed");
		}

		[TestMethod]
		public void CreatedDate()
		{
			_propertiesChanged = new List<String>();
			var createdDate = DateTime.Now;

			var taskItem = new TaskItem();

			taskItem.PropertyChanged += OnPropertyChanged;
			taskItem.CreatedDate = createdDate;
			taskItem.PropertyChanged -= OnPropertyChanged;

			Assert.AreEqual(createdDate, taskItem.CreatedDate, "CreatedDate");
			Assert.IsTrue(_propertiesChanged.Contains("CreatedDate"), "CreatedDate Property Changed");
		}

		[TestMethod]
		public void DueDate()
		{
			_propertiesChanged = new List<String>();
			var dueDate = DateTime.Now;

			var taskItem = new TaskItem();

			taskItem.PropertyChanged += OnPropertyChanged;
			taskItem.DueDate = dueDate;
			taskItem.PropertyChanged -= OnPropertyChanged;

			Assert.AreEqual(dueDate, taskItem.DueDate, "DueDate");
			Assert.IsTrue(_propertiesChanged.Contains("DueDate"), "DueDate Property Changed");
		}

		[TestMethod]
		public void Priority()
		{
			_propertiesChanged = new List<String>();
			var priority = GettingDirty.Core.Models.Priority.High;

			var taskItem = new TaskItem();

			taskItem.PropertyChanged += OnPropertyChanged;
			taskItem.Priority = priority;
			taskItem.PropertyChanged -= OnPropertyChanged;

			Assert.AreEqual(priority, taskItem.Priority, "Priority");
			Assert.IsTrue(_propertiesChanged.Contains("Priority"), "Priority Property Changed");
		}

		[TestMethod]
		public void IsCompleted()
		{
			_propertiesChanged = new List<String>();
			var isCompleted = true;

			var taskItem = new TaskItem();

			taskItem.PropertyChanged += OnPropertyChanged;
			taskItem.IsCompleted = isCompleted;
			taskItem.PropertyChanged -= OnPropertyChanged;

			Assert.AreEqual(isCompleted, taskItem.IsCompleted, "IsCompleted");
			Assert.IsTrue(_propertiesChanged.Contains("IsCompleted"), "IsCompleted Property Changed");
		}
	}
}
