using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows;
using System.Windows.Controls;

namespace XUMHUB.Behaviours
{
    public static class EnterKeyBehavior
    {
        public static readonly DependencyProperty CommandProperty =
            DependencyProperty.RegisterAttached(
                "Command",
                typeof(ICommand),
                typeof(EnterKeyBehavior),
                new PropertyMetadata(OnCommandChanged));

        public static ICommand GetCommand(DependencyObject obj)
        {
            return (ICommand)obj.GetValue(CommandProperty);
        }

        public static void SetCommand(DependencyObject obj, ICommand value)
        {
            obj.SetValue(CommandProperty, value);
        }

        private static void OnCommandChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            if (d is UIElement element)
            {
                if (e.NewValue is ICommand)
                {
                    element.KeyDown += OnKeyDown;
                }
                else
                {
                    element.KeyDown -= OnKeyDown;
                }
            }
        }

        private static void OnKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                if (sender is ComboBox comboBox && comboBox.SelectedItem != null)
                {
                    var element = (UIElement)sender;
                    var command = GetCommand(element);
                    if (command != null && command.CanExecute(null))
                    {
                        command.Execute(null);
                    }
                }
            }
        }
    }
}
