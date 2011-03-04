using System;
using System.Collections.ObjectModel;
using GettingDirty.Core.Models;
using GettingDirty.Core.Repositories;
using MvvmFabric.Messaging;
using MvvmFabric.Xaml;

namespace GettingDirty.Core.ViewModels
{
	public class MainViewModel : CoreViewModelBase, IMainViewModel
	{
		private ITaskRepository TaskRepository { get; set; }

		public string PageName
		{
			get { return "Tasks"; }
		}

		private ObservableCollection<TaskItem> _tasks;
		public ObservableCollection<TaskItem> Tasks
		{
			get
			{
				if (_tasks == null)
				{
					// TODO: 2. LoadTasks
					Tasks = new ObservableCollection<TaskItem>();
				}

				return _tasks;
			}
			protected set { _tasks = value; }
		}

		private string _newTaskTitle;
		public string NewTaskTitle
		{
			get { return _newTaskTitle; }
			set
			{
				_newTaskTitle = value;
				NotifyPropertyChanged("NewTaskTitle");
			}
		}

		private Priority _newTaskPriority;
		public Priority NewTaskPriority
		{
			get { return _newTaskPriority; }
			set
			{
				_newTaskPriority = value;
				NotifyPropertyChanged("NewTaskPriority");
			}
		}


		public MainViewModel(IMessageBus messageBus, ITaskRepository taskRepository)
			: base(messageBus)
		{
			TaskRepository = taskRepository;

			ResetNewTask();
		}

		// TODO: 1. AddTask

		// TODO: 3. EditTask

		// TODO: 4. DeleteTask

		public void LoadTasks()
		{
			// Just signal to the UI to load the tasks.
			_tasks = null;
			NotifyPropertyChanged("Tasks");
		}

		public void SaveTasks()
		{
			TaskRepository.SaveTasks(Tasks);
		}

		private void ResetNewTask()
		{	
			NewTaskTitle = String.Empty;
			NewTaskPriority = Priority.Medium;
		}
	}
}