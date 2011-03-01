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
using GettingDirty.Core.Repositories;
using GettingDirty.Core.Models;
using System.Collections.ObjectModel;

namespace GettingDirty.Core.Tests.Mocks
{
	public class MockTaskRepository : ITaskRepository
	{
		public ObservableCollection<TaskItem> Tasks { get; set; }

		public ObservableCollection<TaskItem> LoadTasks()
		{
			return Tasks;
		}

		public void SaveTasks(ObservableCollection<TaskItem> tasks)
		{
			Tasks = tasks;
		}
	}
}
