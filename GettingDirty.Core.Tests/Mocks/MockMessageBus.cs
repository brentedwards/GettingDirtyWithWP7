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
using MvvmFabric.Messaging;

namespace GettingDirty.Core.Tests.Mocks
{
	public class MockMessageBus : IMessageBus
	{
		public void Subscribe<TMessage>(Action<TMessage> handler)
		{
		}

		public void Unsubscribe<TMessage>(Action<TMessage> handler)
		{
		}

		public object PublishedMessage { get; set; }
		public void Publish<TMessage>(TMessage message)
		{
			PublishedMessage = message;
		}
	}
}
