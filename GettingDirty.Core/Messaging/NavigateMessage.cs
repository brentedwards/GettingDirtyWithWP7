﻿using System;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;

namespace GettingDirty.Core.Messaging
{
	public class NavigateMessage
	{
		public Uri Uri { get; private set; }

		public NavigateMessage(Uri uri)
		{
			Uri = uri;
		}
	}
}
