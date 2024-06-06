using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Animation;
using System.Windows.Media;
using System.Windows;

namespace AreaDesignWpfControls
{
    public class AnimationHelper
    {
        /// <summary>
        /// 开始一个颜色渐变动画应用于资源字典中指定 <see cref="SolidColorBrush"/>
        /// </summary>
        /// <param name="resourceDict">包含目标画刷的资源字典</param>
        /// <param name="key">资源字典中画刷的键</param>
        /// <param name="toColor">动画结束时的颜色</param>
        /// <param name="durationMs">动画持续时间（毫秒）</param>
        public static void ResBrushBeginAnimation(ResourceDictionary resourceDict, string key, Color toColor, int durationMs = 600)
        {
            if (resourceDict[key] is SolidColorBrush brush)
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
                    resourceDict[key] = brush;
            }
        }
        /// <summary>
        /// 开始一个颜色渐变动画应用于应用程序级别资源字典中指定 <see cref="SolidColorBrush"/>
        /// </summary>
        /// <param name="key">资源字典中画刷的键</param>
        /// <param name="toColor">动画结束时的颜色</param>
        /// <param name="durationMs">动画持续时间（毫秒）</param>
        public static void ResBrushBeginAnimation(string key, Color toColor, int durationMs = 600)
        {
            ResBrushBeginAnimation(Application.Current.Resources, key, toColor, durationMs);
        }

    }
}
