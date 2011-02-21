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
	public class PriorityToBrushConverter : IValueConverter
	{
		public Brush LowBrush { get; set; }
		public Brush MediumBrush { get; set; }
		public Brush HighBrush { get; set; }

		public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
		{
			var result = MediumBrush;

			if (value is Priority)
			{
				switch ((Priority) value)
				{
					case Priority.Low:
						result = LowBrush;
						break;

					case Priority.Medium:
						result = MediumBrush;
						break;

					case Priority.High:
						result = HighBrush;
						break;
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
