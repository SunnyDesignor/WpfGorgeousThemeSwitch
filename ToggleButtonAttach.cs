using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows;
using System.Windows.Controls.Primitives;

namespace AreaDesignWpfControls
{
    public static class ToggleButtonAttach
    {
        #region IsAutoFold
        [AttachedPropertyBrowsableForType(typeof(ToggleButton))]
        public static bool GetIsAutoFold(ToggleButton control)
        {
            return (bool)control.GetValue(IsAutoFoldProperty);
        }

        public static void SetIsAutoFold(ToggleButton control, bool value)
        {
            control.SetValue(IsAutoFoldProperty, value);
        }

        /// <summary>
        /// 为具有 ToggleButtonGorgeousThemeSwitchStyle 样式的 <see cref="ToggleButton"/> 设置是否启用自动折叠
        /// </summary>
        public static readonly DependencyProperty IsAutoFoldProperty =
            DependencyProperty.RegisterAttached("IsAutoFold", typeof(bool), typeof(ToggleButtonAttach),
                new PropertyMetadata(false, ToggleButtonChanged));

        private static void ToggleButtonChanged(DependencyObject o, DependencyPropertyChangedEventArgs e)
        {
            if (o is not ToggleButton control)
                return;
            if ((bool)e.NewValue)
            {
                control.MouseLeave += Control_MouseLeave;
                control.Checked += Control_Checked;
                control.Unchecked += Control_Checked;
                if (!control.IsMouseOver)
                    VisualStateManager.GoToState(control, control.IsChecked == true ? "MouseLeaveChecked" : "MouseLeaveUnChecked", false);
            }
            else
            {
                control.MouseLeave -= Control_MouseLeave;
                control.Checked -= Control_Checked;
                control.Unchecked -= Control_Checked;
                VisualStateManager.GoToState(control, "MouseOver", false);
            }
        }

        private static void Control_Checked(object sender, RoutedEventArgs e)
        {
            var control = (ToggleButton)sender;
            if(control.IsMouseOver)
                return;
            VisualStateManager.GoToState(control, control.IsChecked == true ? "MouseLeaveChecked" : "MouseLeaveUnChecked", false);
        }

        private static void Control_MouseLeave(object sender, System.Windows.Input.MouseEventArgs e)
        {
            var control = (ToggleButton)sender;
            VisualStateManager.GoToState(control, control.IsChecked == true ? "MouseLeaveChecked" : "MouseLeaveUnChecked", false);
        }
        #endregion

    }
}
