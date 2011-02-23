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
using GettingDirty.Core.Converters.Multi;

namespace GettingDirty.Core.Converters
{
	public class TaskToBrushConverter : IMultiValueConverter
	{
		public Brush NormalBrush { get; set; }
		public Brush CompletedBrush { get; set; }
		public Brush OverdueBrush { get; set; }

		public object Convert(object[] values, Type targetType, object parameter, System.Globalization.CultureInfo culture)
		{
			var result = NormalBrush;

			if (values.Length == 2)
			{
				if (values[0] is bool)
				{
					var dueDate = values[1] as DateTime?;
					if (dueDate != null && dueDate.HasValue && dueDate.Value < DateTime.Now)
					{
						result = OverdueBrush;
					}

					if ((bool)values[0])
					{
						result = CompletedBrush;
					}
				}
			}

			return result;
		}

		public object[] ConvertBack(object value, Type[] targetTypes, object parameter, System.Globalization.CultureInfo culture)
		{
			throw new NotImplementedException();
		}
	}
}
