using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GalaSoft.MvvmLight.Command;
using System.Collections.ObjectModel;
using GettingDirty.Core.Models;

namespace GettingDirty.Core.ViewModels
{
	public interface IMainViewModel
	{
		RelayCommand AddTaskCommand { get; }
		string ApplicationTitle { get; }

		string PageName { get; }

		string NewTaskTitle { get; set; }

		Priority NewTaskPriority { get; set; }

		Priority[] Priorities { get; }

		ObservableCollection<TaskItem> Tasks { get; }
	}
}
