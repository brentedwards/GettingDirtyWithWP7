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

		public RelayCommand ExecutionModelCommand { get; private set; }

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


		public MainViewModel(ITaskRepository taskRepository)
		{
			TaskRepository = taskRepository;

			ExecutionModelCommand = new RelayCommand(ShowExecutionModel);
		}

		public void ShowExecutionModel()
		{
			SendNavigationRequestMessage(new Uri("/Views/ExecutionModelView.xaml", UriKind.Relative));
		}
	}
}