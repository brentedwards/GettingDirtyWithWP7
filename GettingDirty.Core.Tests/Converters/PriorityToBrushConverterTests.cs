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
using Microsoft.Silverlight.Testing;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using GettingDirty.Core.Converters;
using GettingDirty.Core.Models;

namespace GettingDirty.Core.Tests.Converters
{
	[TestClass]
	public class PriorityToBrushConverterTests : SilverlightTest
	{
		[TestMethod]
		public void Convert_Low()
		{
			var expectedBrush = new SolidColorBrush();

			var converter = new PriorityToBrushConverter()
			{
				LowBrush = expectedBrush
			};

			var actualBrush = converter.Convert(Priority.Low, null, null, null);

			Assert.AreSame(expectedBrush, actualBrush);
		}

		[TestMethod]
		public void Convert_Medium()
		{
			var expectedBrush = new SolidColorBrush();

			var converter = new PriorityToBrushConverter()
			{
				MediumBrush = expectedBrush
			};

			var actualBrush = converter.Convert(Priority.Medium, null, null, null);

			Assert.AreSame(expectedBrush, actualBrush);
		}

		[TestMethod]
		public void Convert_High()
		{
			var expectedBrush = new SolidColorBrush();

			var converter = new PriorityToBrushConverter()
			{
				HighBrush = expectedBrush
			};

			var actualBrush = converter.Convert(Priority.High, null, null, null);

			Assert.AreSame(expectedBrush, actualBrush);
		}

		[TestMethod]
		public void Convert_NotPriority()
		{
			var expectedBrush = new SolidColorBrush();

			var converter = new PriorityToBrushConverter()
			{
				MediumBrush = expectedBrush
			};

			var actualBrush = converter.Convert(new object(), null, null, null);

			Assert.AreSame(expectedBrush, actualBrush);
		}
	}
}
