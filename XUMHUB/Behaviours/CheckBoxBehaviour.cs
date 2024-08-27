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
    public static class CheckBoxBehaviour
    {
        public static readonly DependencyProperty CheckChangedCommandProperty =
            DependencyProperty.RegisterAttached("CheckChangedCommand", typeof(ICommand), typeof(CheckBoxBehaviour), new PropertyMetadata(null, OnCheckChangedCommandChanged));

        public static ICommand GetCheckChangedCommand(DependencyObject obj)
        {
            return (ICommand)obj.GetValue(CheckChangedCommandProperty);
        }

        public static void SetCheckChangedCommand(DependencyObject obj, ICommand value)
        {
            obj.SetValue(CheckChangedCommandProperty, value);
        }

        private static void OnCheckChangedCommandChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            if (d is CheckBox checkBox)
            {
                checkBox.Checked -= CheckBoxChecked;
                checkBox.Unchecked -= CheckBoxUnchecked;

                if (e.NewValue != null)
                {
                    checkBox.Checked += CheckBoxChecked;
                    checkBox.Unchecked += CheckBoxUnchecked;
                }
            }
        }

        private static void CheckBoxChecked(object sender, RoutedEventArgs e)
        {
            if (sender is CheckBox checkBox)
            {
                var command = GetCheckChangedCommand(checkBox);
                command?.Execute(true);
            }
        }

        private static void CheckBoxUnchecked(object sender, RoutedEventArgs e)
        {
            if (sender is CheckBox checkBox)
            {
                var command = GetCheckChangedCommand(checkBox);
                command?.Execute(false);
            }
        }
    }
}
