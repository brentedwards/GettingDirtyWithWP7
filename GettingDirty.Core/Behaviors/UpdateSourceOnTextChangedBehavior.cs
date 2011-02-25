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
using System.Windows.Interactivity;
using System.Windows.Data;

namespace GettingDirty.Core.Behaviors
{
	public class UpdateSourceOnTextChangedBehavior : Behavior<TextBox>
	{
		protected override void OnAttached()
		{
			base.OnAttached();

			AssociatedObject.TextChanged += OnTextChanged;
		}

		protected override void OnDetaching()
		{
			base.OnDetaching();

			AssociatedObject.TextChanged -= OnTextChanged;
		}

		private void OnTextChanged(object sender, TextChangedEventArgs e)
		{
			BindingExpression bindingExpression = AssociatedObject.GetBindingExpression(TextBox.TextProperty);
			bindingExpression.UpdateSource(); 
		}
	}
}
