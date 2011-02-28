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
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Messaging;
using GettingDirty.Core.Models;
using System.ComponentModel;

namespace GettingDirty.Core.ViewModels
{
	public class ViewModelBase : ModelBase
	{
		public string ApplicationTitle
		{
			get { return "Getting Dirty with WP7"; }
		}

		public Priority[] Priorities
		{
			get
			{
				return new Priority[] { Priority.High, Priority.Medium, Priority.Low };
			}
		}

		protected bool IsInDesignMode
		{
			get { return DesignerProperties.IsInDesignTool; }
		}

		protected void SendNavigationRequestMessage(Uri uri)
		{
			Messenger.Default.Send<Uri>(uri, "NavigationRequest");
		}
	}
}
