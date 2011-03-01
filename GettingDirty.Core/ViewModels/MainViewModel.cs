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
					Tasks = TaskRepository.LoadTasks();
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

		public void AddTask()
		{
			Tasks.Add(new TaskItem() { TaskId = Guid.NewGuid(), Title = NewTaskTitle, Priority = NewTaskPriority });

			ResetNewTask();
		}

		public void EditTask(object sender, ExecuteEventArgs args)
		{
			var taskItem = args.MethodParameter as TaskItem;
			SendNavigationRequestMessage(new Uri(string.Format("/Views/DetailsView.xaml?taskId={0}", taskItem.TaskId), UriKind.Relative));
		}

		public void DeleteTask(object sender, ExecuteEventArgs args)
		{
			var taskItem = args.MethodParameter as TaskItem;
			Tasks.Remove(taskItem);
		}

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