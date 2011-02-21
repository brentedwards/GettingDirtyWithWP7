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
using System.Windows.Data;
using GettingDirty.Core.Models;

namespace GettingDirty.Core.Converters
{
	public class TaskToBrushConverter : IValueConverter
	{
		public Brush NormalBrush { get; set; }
		public Brush CompletedBrush { get; set; }
		public Brush OverdueBrush { get; set; }

		public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
		{
			var result = NormalBrush;

			var taskItem = value as TaskItem;
			if (taskItem != null)
			{
				if (taskItem.DueDate < DateTime.Now)
				{
					result = OverdueBrush;
				}

				if (taskItem.IsCompleted)
				{
					result = CompletedBrush;
				}
			}

			return result;
		}

		public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
		{
			throw new NotImplementedException();
		}
	}
}
