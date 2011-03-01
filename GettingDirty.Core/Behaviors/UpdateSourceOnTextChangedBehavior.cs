using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Interactivity;

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
