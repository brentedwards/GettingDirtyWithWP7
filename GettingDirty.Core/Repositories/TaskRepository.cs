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
using System.Collections.ObjectModel;
using GettingDirty.Core.Models;

namespace GettingDirty.Core.Repositories
{
	public class TaskRepository : ITaskRepository
	{
		public const String FILE_NAME = "Tasks.dat";

		private IIsolatedStorageRepository StorageRepository { get; set; }

		public TaskRepository(IIsolatedStorageRepository storageRepository)
		{
			StorageRepository = storageRepository;
		}

		public ObservableCollection<TaskItem> LoadTasks()
		{
			return StorageRepository.LoadData<ObservableCollection<TaskItem>>(FILE_NAME);
		}

		public void SaveTasks(ObservableCollection<TaskItem> tasks)
		{
			StorageRepository.SaveData<ObservableCollection<TaskItem>>(tasks, FILE_NAME);
		}
	}
}
