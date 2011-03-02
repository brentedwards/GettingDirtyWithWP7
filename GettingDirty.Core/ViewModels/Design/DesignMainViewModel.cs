using System;
using System.Collections.ObjectModel;
using GettingDirty.Core.Models;

namespace GettingDirty.Core.ViewModels.Design
{
	public class DesignMainViewModel : MainViewModel
	{
		public DesignMainViewModel()
			: base(null, null)
		{
			NewTaskPriority = Priority.Medium;

			// TODO: Tasks
		}
	}
}
