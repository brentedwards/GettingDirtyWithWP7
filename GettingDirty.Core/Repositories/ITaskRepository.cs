using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GettingDirty.Core.Models;
using System.Collections.ObjectModel;

namespace GettingDirty.Core.Repositories
{
	public interface ITaskRepository
	{
		ObservableCollection<TaskItem> LoadTasks();
		void SaveTasks(ObservableCollection<TaskItem> tasks);
	}
}
