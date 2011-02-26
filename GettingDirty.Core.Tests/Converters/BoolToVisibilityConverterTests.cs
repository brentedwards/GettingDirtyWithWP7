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
	public class BoolToVisibilityConverterTests : SilverlightTest
	{
		[TestMethod]
		public void Convert_True()
		{
			var expectedVisibility = Visibility.Visible;

			var converter = new BoolToVisibilityConverter();

			var actualVisibility = converter.Convert(true, null, null, null);

			Assert.AreEqual(expectedVisibility, actualVisibility);
		}

		[TestMethod]
		public void Convert_False()
		{
			var expectedVisibility = Visibility.Collapsed;

			var converter = new BoolToVisibilityConverter();

			var actualVisibility = converter.Convert(false, null, null, null);

			Assert.AreEqual(expectedVisibility, actualVisibility);
		}

		[TestMethod]
		public void Convert_NotBool()
		{
			var expectedVisibility = Visibility.Visible;

			var converter = new BoolToVisibilityConverter();

			var actualVisibility = converter.Convert(new object(), null, null, null);

			Assert.AreEqual(expectedVisibility, actualVisibility);
		}
	}
}
