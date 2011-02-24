using System;
using GalaSoft.MvvmLight.Command;
using System.Windows;
using GettingDirty.Core.Models;
using System.Collections.ObjectModel;
using GettingDirty.Core.Repositories;

namespace GettingDirty.Core.ViewModels
{
	public sealed class MainViewModel : ViewModelBase, IMainViewModel
	{
		private ITaskRepository TaskRepository { get; set; }

		public RelayCommand AddTaskCommand { get; private set; }
		public RelayCommand<TaskItem> EditTaskCommand { get; private set; }

		public string ApplicationTitle
		{
			get { return "Getting Dirty with WP7"; }
		}

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
					_tasks = TaskRepository.LoadTasks();
				}

				return _tasks;
			}
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

		public Priority[] Priorities
		{
			get
			{
				return new Priority[] { Priority.High, Priority.Medium, Priority.Low };
			}
		}


		public MainViewModel(ITaskRepository taskRepository)
		{
			TaskRepository = taskRepository;

			AddTaskCommand = new RelayCommand(AddTask);
			EditTaskCommand = new RelayCommand<TaskItem>(EditTask);

			ResetNewTask();
		}

		public void AddTask()
		{
			Tasks.Add(new TaskItem() { TaskId = Guid.NewGuid(), Title = NewTaskTitle, Priority = NewTaskPriority });

			ResetNewTask();
		}

		public void EditTask(TaskItem taskItem)
		{
			SendNavigationRequestMessage(new Uri(string.Format("/Views/DetailsView.xaml?taskId={0}", taskItem.TaskId), UriKind.Relative));
		}

		private void ResetNewTask()
		{
			NewTaskTitle = String.Empty;
			NewTaskPriority = Priority.Medium;
		}
	}
}