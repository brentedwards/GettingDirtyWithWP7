using System;
using System.ComponentModel;
using GettingDirty.Core.Messaging;
using GettingDirty.Core.Models;
using MvvmFabric.Messaging;
using MvvmFabric;

namespace GettingDirty.Core.ViewModels
{
	public class CoreViewModelBase : ViewModelBase
	{
		private IMessageBus MessageBus { get; set; }

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

		public CoreViewModelBase(IMessageBus messageBus)
		{
			MessageBus = messageBus;
		}

		// TODO: SendNavigationRequestMessage
	}
}
