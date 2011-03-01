using System.Collections.ObjectModel;
using GettingDirty.Core.Models;

namespace GettingDirty.Core.ViewModels
{
	public interface IMainViewModel
	{
		string ApplicationTitle { get; }

		string PageName { get; }

		string NewTaskTitle { get; set; }

		Priority NewTaskPriority { get; set; }

		Priority[] Priorities { get; }

		ObservableCollection<TaskItem> Tasks { get; }

		void SaveTasks();
		void LoadTasks();
	}
}
