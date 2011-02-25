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

namespace GettingDirty.Core.Models
{
	public enum Priority
	{
		High,
		Medium,
		Low
	}

	public class TaskItem : ModelBase
	{
		public Guid TaskId { get; set; }

		private String _title;
		public String Title
		{
			get { return _title; }
			set
			{
				_title = value;
				NotifyPropertyChanged("Title");
			}
		}

		private String _description;
		public String Description
		{
			get { return _description; }
			set
			{
				_description = value;
				NotifyPropertyChanged("Description");
			}
		}

		private DateTime _createdDate;
		public DateTime CreatedDate
		{
			get { return _createdDate; }
			set
			{
				_createdDate = value;
				NotifyPropertyChanged("CreatedDate");
			}
		}

		private DateTime? _dueDate;
		public DateTime? DueDate
		{
			get { return _dueDate; }
			set
			{
				_dueDate = value;
				NotifyPropertyChanged("DueDate");
			}
		}

		private Priority _priority = Priority.Medium;
		public Priority Priority
		{
			get { return _priority; }
			set
			{
				_priority = value;
				NotifyPropertyChanged("Priority");
			}
		}

		private bool _isCompleted;
		public bool IsCompleted
		{
			get { return _isCompleted; }
			set
			{
				_isCompleted = value;
				NotifyPropertyChanged("IsCompleted");
			}
		}
	}
}
