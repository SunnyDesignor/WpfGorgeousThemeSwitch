using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

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
            ResBrushBeginAnimation("BackgroundBrush", (Color)ColorConverter.ConvertFromString("#FF1C1C1C"));
            ResBrushBeginAnimation("PrimaryTextBrush", Colors.White);
        }

        private void SwitchToLightTheme()
        {
            ResBrushBeginAnimation("BackgroundBrush", Colors.White);
            ResBrushBeginAnimation("PrimaryTextBrush", Colors.Black);
        }

        private void ResBrushBeginAnimation(string key, Color toColor, int durationMs = 600)
        {
            if (FindResource(key) is SolidColorBrush brush)
            {
                bool isNewBrush = false;
                if (brush.IsFrozen)
                {
                    brush = new SolidColorBrush(brush.Color);
                    isNewBrush = true;
                }
                ColorAnimation colorAnimation = new ColorAnimation
                {
                    From = brush.Color,
                    To = toColor,
                    Duration = TimeSpan.FromMilliseconds(durationMs),
                    EasingFunction = new PowerEase() { EasingMode = EasingMode.EaseInOut },
                };
                brush.BeginAnimation(SolidColorBrush.ColorProperty, colorAnimation);
                if (isNewBrush)
                    Resources[key] = brush;
            }
        }

    }
}