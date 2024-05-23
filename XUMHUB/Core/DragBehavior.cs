using System.Windows;
using System.Windows.Input;

namespace XUMHUB.Core
{
    public static class DragBehavior
    {
        public static readonly DependencyProperty EnableDragProperty =
            DependencyProperty.RegisterAttached(
                "EnableDrag",
                typeof(bool),
                typeof(DragBehavior),
                new PropertyMetadata(false, OnEnableDragChanged));

        public static bool GetEnableDrag(DependencyObject obj)
        {
            return (bool)obj.GetValue(EnableDragProperty);
        }

        public static void SetEnableDrag(DependencyObject obj, bool value)
        {
            obj.SetValue(EnableDragProperty, value);
        }

        private static void OnEnableDragChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var element = d as UIElement;
            if (element == null)
            {
                return;
            }

            if ((bool)e.NewValue)
            {
                element.MouseLeftButtonDown += Element_MouseLeftButtonDown;
            }
            else
            {
                element.MouseLeftButtonDown -= Element_MouseLeftButtonDown;
            }
        }

        private static void Element_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ClickCount == 1)
            {
                var window = Window.GetWindow(sender as UIElement);
                window?.DragMove();
            }
        }
    }
}
