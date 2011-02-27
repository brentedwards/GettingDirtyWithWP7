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

namespace GettingDirty.Core.Tests.Converters
{
	[TestClass]
	public class TaskToBrushConverterTests : SilverlightTest
	{
		[TestMethod]
		public void Convert_Normal()
		{
			var expectedBrush = new SolidColorBrush();

			var converter = new TaskToBrushConverter()
			{
				NormalBrush = expectedBrush
			};

			var actualBrush = converter.Convert(null, null, null, null);

			Assert.AreSame(expectedBrush, actualBrush);
		}

		[TestMethod]
		public void Convert_Overdue()
		{
			var expectedBrush = new SolidColorBrush();

			var converter = new TaskToBrushConverter()
			{
				OverdueBrush = expectedBrush
			};

			var actualBrush = converter.Convert(new object[] { false, DateTime.Now.AddDays(-1) }, null, null, null);

			Assert.AreSame(expectedBrush, actualBrush);
		}

		[TestMethod]
		public void Convert_Completed()
		{
			var expectedBrush = new SolidColorBrush();

			var converter = new TaskToBrushConverter()
			{
				CompletedBrush = expectedBrush
			};

			var actualBrush = converter.Convert(new object[] { true, DateTime.Now.AddDays(1) }, null, null, null);

			Assert.AreSame(expectedBrush, actualBrush);
		}

		[TestMethod]
		public void Convert_CompletedAndOverdue()
		{
			var expectedBrush = new SolidColorBrush();

			var converter = new TaskToBrushConverter()
			{
				CompletedBrush = expectedBrush,
				OverdueBrush = new SolidColorBrush()
			};

			var actualBrush = converter.Convert(new object[] { true, DateTime.Now.AddDays(-1) }, null, null, null);

			Assert.AreSame(expectedBrush, actualBrush);
		}
	}
}
