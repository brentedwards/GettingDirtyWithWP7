﻿using System;
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

			var tasks = new ObservableCollection<TaskItem>();
			tasks.Add(
				new TaskItem()
				{
					CreatedDate = DateTime.Now.AddDays(-1),
					DueDate = DateTime.Now.AddDays(1),
					Title = "Low Priority Task",
					Priority = Priority.Low,
					Description = "Low Priority Task"
				});
			
			tasks.Add(
				new TaskItem()
				{
					CreatedDate = DateTime.Now.AddDays(-1),
					DueDate = DateTime.Now.AddDays(1),
					Title = "Medium Priority Task",
					Priority = Priority.Medium,
					Description = "Medium Priority Task"
				});

			tasks.Add(
				new TaskItem()
				{
					CreatedDate = DateTime.Now.AddDays(-1),
					DueDate = DateTime.Now.AddDays(1),
					Title = "High Priority Task",
					Priority = Priority.High,
					Description = "High Priority Task"
				});

			tasks.Add(
				new TaskItem()
				{
					CreatedDate = DateTime.Now.AddDays(-1),
					DueDate = DateTime.Now.AddDays(1),
					Title = "Completed Task",
					Priority = Priority.Low,
					Description = "Completed Task",
					IsCompleted = true
				});

			tasks.Add(
				new TaskItem()
				{
					CreatedDate = DateTime.Now.AddDays(-3),
					DueDate = DateTime.Now.AddDays(-1),
					Title = "Overdue Task",
					Priority = Priority.Low,
					Description = "Overdue Task"
				});

			Tasks = tasks;
		}
	}
}
