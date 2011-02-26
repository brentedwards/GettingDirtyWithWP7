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
	public class BoolToFontStyleConverterTests : SilverlightTest
	{
		[TestMethod]
		public void Convert_True()
		{
			var expectedStyle = FontStyles.Italic;

			var converter = new BoolToFontStyleConverter();
			converter.CompletedStyle = expectedStyle;

			var actualStyle = converter.Convert(true, null, null, null);

			Assert.AreEqual(expectedStyle, actualStyle);
		}

		[TestMethod]
		public void Convert_False()
		{
			var expectedStyle = FontStyles.Normal;

			var converter = new BoolToFontStyleConverter();

			var actualStyle = converter.Convert(false, null, null, null);

			Assert.AreEqual(expectedStyle, actualStyle);
		}

		[TestMethod]
		public void Convert_NotBoolean()
		{
			var expectedStyle = FontStyles.Normal;

			var converter = new BoolToFontStyleConverter();

			var actualStyle = converter.Convert(new object(), null, null, null);

			Assert.AreEqual(expectedStyle, actualStyle);
		}
	}
}
