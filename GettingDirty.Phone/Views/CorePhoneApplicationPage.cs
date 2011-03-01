using System.ComponentModel;
using System.Windows;
using GettingDirty.Core.Container;
using GettingDirty.Core.Messaging;
using Microsoft.Phone.Controls;
using MvvmFabric.Messaging;

namespace GettingDirty.Phone.Views
{
	public class CorePhoneApplicationPage : PhoneApplicationPage
	{
		protected override void OnNavigatedFrom(System.Windows.Navigation.NavigationEventArgs e)
		{
			base.OnNavigatedFrom(e);

			var messageBus = Ioc.Container.Resolve<IMessageBus>();
			messageBus.Unsubscribe<NavigateMessage>(HandleNavigateMessage);
		}

		protected override void OnNavigatedTo(System.Windows.Navigation.NavigationEventArgs e)
		{
			base.OnNavigatedTo(e);

			var messageBus = Ioc.Container.Resolve<IMessageBus>();
			messageBus.Subscribe<NavigateMessage>(HandleNavigateMessage);
		}

		private void HandleNavigateMessage(NavigateMessage message)
		{
			NavigationService.Navigate(message.Uri);
		}
	}
}
