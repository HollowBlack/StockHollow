using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Interop;
using WPF.Extension.Library.Animation;
using WPF.Extension.Library.Animation.Effect;

namespace WPF.Extension.Library.Controls
{
    public enum WindowCloseEffect
    {
        None,
        Slideup,
        Fadeout
    }

    public class MaskWindow: DpiAwareWindow
    {
        static MaskWindow()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(MaskWindow), new FrameworkPropertyMetadata(typeof(MaskWindow)));
        }

        public MaskWindow()
        {
             DefaultStyleKey = typeof(MaskWindow);
             CommandBindings.Add(new CommandBinding(SystemCommands.CloseWindowCommand, OnCloseWindow));
             CommandBindings.Add(new CommandBinding(SystemCommands.MaximizeWindowCommand, OnMaximizeWindow, OnCanResizeWindow));
             CommandBindings.Add(new CommandBinding(SystemCommands.MinimizeWindowCommand, OnMinimizeWindow, OnCanMinimizeWindow));
             CommandBindings.Add(new CommandBinding(SystemCommands.RestoreWindowCommand, OnRestoreWindow, OnCanResizeWindow));

        }

        #region  Dependent Property
        /// <summary>
        /// Identifies the Icon dependency property.
        /// </summary>
        public static readonly DependencyProperty LogoProperty = DependencyProperty.Register("Logo", typeof(object), typeof(MaskWindow));

        /// <summary>
        /// Gets or sets the Icon content of this window instance.
        /// </summary>
        public object Logo
        {
            get { return GetValue(LogoProperty); }
            set { SetValue(LogoProperty, value); }
        }

        /// <summary>
        /// Identifies the BackgroundContent dependency property.
        /// </summary>
        public static readonly DependencyProperty BackgroundContentProperty = DependencyProperty.Register("BackgroundContent", typeof(object), typeof(MaskWindow));

        /// <summary>
        /// Gets or sets the background content of this window instance.
        /// </summary>
        public object BackgroundContent
        {
            get { return GetValue(BackgroundContentProperty); }
            set { SetValue(BackgroundContentProperty, value); }
        }

        /// <summary>
        /// Identifies the CustomTitleItem dependency property.
        /// </summary>
        public static readonly DependencyProperty CustomTitleItemProperty = DependencyProperty.Register("CustomTitleItem", typeof(object), typeof(MaskWindow));

        /// <summary>
        /// Gets or sets the CustomTitleItem of this window instance.
        /// </summary>
        public object CustomTitleItem
        {
            get { return GetValue(CustomTitleItemProperty); }
            set { SetValue(CustomTitleItemProperty, value); }
        }
        #endregion


        private void OnCanResizeWindow(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = ResizeMode == ResizeMode.CanResize || this.ResizeMode == ResizeMode.CanResizeWithGrip;
        }

        private void OnCanMinimizeWindow(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = ResizeMode != ResizeMode.NoResize;
        }

        private void OnCloseWindow(object target, ExecutedRoutedEventArgs e)
        {
            CloseX(CloseEffect);
        }

        public void CloseX(WindowCloseEffect effect)
        {
            IsEnabled = false;
            Func<Task> animation = null;
            switch (effect)
            {
                case WindowCloseEffect.Fadeout:
                    animation = async () => await new EfFade().FadeOut(this, 1000);
                    break;
                case WindowCloseEffect.Slideup:
                    animation = async () => await new EfWipe().WideUp(this, 1000);
                    break;
            }

            if (animation != null)
            {
                Task.Run(async () => await animation()).
                    GetAwaiter().
                    OnCompleted(() => SystemCommands.CloseWindow(this));
            }
            else
            {
                SystemCommands.CloseWindow(this);
            }
        }

        private void OnMaximizeWindow(object target, ExecutedRoutedEventArgs e)
        {
            SystemCommands.MaximizeWindow(this);
        }

        private void OnMinimizeWindow(object target, ExecutedRoutedEventArgs e)
        {
            SystemCommands.MinimizeWindow(this);
        }

        private void OnRestoreWindow(object target, ExecutedRoutedEventArgs e)
        {
            SystemCommands.RestoreWindow(this);
        }

        public WindowCloseEffect CloseEffect { get; set; }
    }
}
