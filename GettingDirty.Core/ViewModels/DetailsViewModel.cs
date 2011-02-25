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
using GettingDirty.Core.Models;
using GettingDirty.Core.Repositories;
using System.Collections.ObjectModel;
using System.Linq;

namespace GettingDirty.Core.ViewModels
{
	public class DetailsViewModel : ViewModelBase, IDetailsViewModel
	{
		private ITaskRepository TaskRepository { get; set; }

		public string ApplicationTitle
		{
			get { return "Getting Dirty with WP7"; }
		}

		private TaskItem _taskItem = new TaskItem();
		public TaskItem TaskItem
		{
			get { return _taskItem; }
			set
			{
				_taskItem = value;
				NotifyPropertyChanged("TaskItem");
			}
		}

		public Priority[] Priorities
		{
			get
			{
				return new Priority[] { Priority.High, Priority.Medium, Priority.Low };
			}
		}

		private ObservableCollection<TaskItem> _tasks;
		private ObservableCollection<TaskItem> Tasks
		{
			get
			{
				if (_tasks == null)
				{
					_tasks = TaskRepository.LoadTasks();
				}

				return _tasks;
			}
		}

		public DetailsViewModel(ITaskRepository taskRepository)
		{
			TaskRepository = taskRepository;
		}

		public void Load(Guid taskId)
		{
			TaskItem = Tasks.Where(t => t.TaskId == taskId).FirstOrDefault();
		}

		public void NewTask()
		{
			TaskItem = new TaskItem();
			Tasks.Add(TaskItem);
		}

		public void Save()
		{
			TaskRepository.SaveTasks(Tasks);
		}
	}
}
