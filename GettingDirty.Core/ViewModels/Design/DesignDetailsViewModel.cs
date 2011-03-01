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
using GettingDirty.Core.Models;

namespace GettingDirty.Core.ViewModels.Design
{
	public class DesignDetailsViewModel : DetailsViewModel
	{
		public DesignDetailsViewModel()
			: base(null, null)
		{
			TaskItem = new TaskItem()
			{
				Title = "Sample Task",
				Description = "Description of the Sample Task",
				CreatedDate = DateTime.Now,
				DueDate = DateTime.Now.AddDays(1),
				Priority = Priority.Medium
			};
		}
	}
}
