using System.Windows;
using System.Windows.Controls.Primitives;
using System.Windows.Interop;
using System.Windows.Media;

namespace AreaDesignWpfControls
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void ToggleButton_Checked(object sender, RoutedEventArgs e)
        {
            var btn = (ToggleButton)sender;
            if (btn.IsChecked == true)
            {
                SwitchToDarkTheme();
                btn.Content = "切换浅色";
            }
            else
            {
                SwitchToLightTheme();
                btn.Content = "切换深色";
            }
        }

        private void SwitchToDarkTheme()
        {
            AnimationHelper.ResBrushBeginAnimation("BackgroundBrush", (Color)ColorConverter.ConvertFromString("#FF1C1C1C"));
            AnimationHelper.ResBrushBeginAnimation("PrimaryTextBrush", Colors.White);
            NativeMethods.SetWindowFrameTheme(new WindowInteropHelper(this).Handle, true);
        }

        private void SwitchToLightTheme()
        {
            AnimationHelper.ResBrushBeginAnimation("BackgroundBrush", Colors.White);
            AnimationHelper.ResBrushBeginAnimation("PrimaryTextBrush", Colors.Black);
            NativeMethods.SetWindowFrameTheme(new WindowInteropHelper(this).Handle, false);
        }

    }
}