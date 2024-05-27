using System.Configuration;
using System.Data;
using System.Windows;
using System.Windows.Media.Animation;

namespace AreaDesignWpfControls
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private void Application_Startup(object sender, StartupEventArgs e)
        {
            Timeline.DesiredFrameRateProperty.OverrideMetadata(
                typeof(Timeline),
                new FrameworkPropertyMetadata { DefaultValue = 180 }
                );
        }
    }

}
