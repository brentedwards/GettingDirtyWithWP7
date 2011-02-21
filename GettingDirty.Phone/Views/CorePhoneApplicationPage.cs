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
using Microsoft.Phone.Controls;
using System.ComponentModel;
using GalaSoft.MvvmLight.Messaging;

namespace GettingDirty.Phone.Views
{
	public class CorePhoneApplicationPage : PhoneApplicationPage
	{
		public CorePhoneApplicationPage()
		{
			Loaded += new RoutedEventHandler(CorePhoneApplicationPage_Loaded);
		}

		private void CorePhoneApplicationPage_Loaded(object sender, RoutedEventArgs e)
		{
			if (!DesignerProperties.IsInDesignTool)
			{
				Messenger.Default.Register<Uri>(this, "NavigationRequest", (uri) => NavigationService.Navigate(uri));
			}
		}
	}
}
