using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace AESWPF
{
    public class WStyle
    {
        public static readonly DependencyProperty EmptyPromptProperty =
                DependencyProperty.RegisterAttached("EmptyPrompt", typeof(string), typeof(WStyle), new UIPropertyMetadata(null));

        public static readonly DependencyProperty FocusOverlayProperty =
                DependencyProperty.RegisterAttached("FocusOverlay", typeof(bool), typeof(WStyle), new UIPropertyMetadata(true));

        public static string GetEmptyPrompt(DependencyObject obj)
            => (string)obj.GetValue(EmptyPromptProperty);

        public static void SetEmptyPrompt(DependencyObject obj, string value)
            =>
                obj.SetValue(EmptyPromptProperty, value);
        public static bool GetFocusOverlay(DependencyObject obj)
        =>
            (bool)obj.GetValue(FocusOverlayProperty);
        

        public static void SetFocusOverlay(DependencyObject obj, bool value)
        =>
            obj.SetValue(FocusOverlayProperty, value);
        
    }
}
