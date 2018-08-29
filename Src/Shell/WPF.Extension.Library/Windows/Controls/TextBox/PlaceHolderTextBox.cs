using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace WPF.Extension.Library.Controls
{
    [TemplatePart(Name = TextInputControlName, Type = typeof(TextBox))]
    public class PlaceHolderTextBox: Control
    {
        internal const string TextInputControlName = "TextInputControl";

        private TextBox inputTextBox;
        private TextBox InputTextBox
        {
            get
            {
                if (inputTextBox == null)
                {
                    inputTextBox = GetTemplateChild(TextInputControlName) as TextBox;
                }
                return inputTextBox;
            }
        }

        public static readonly DependencyProperty PlaceHolderProperty = DependencyProperty.Register(
            "PlaceHolder", 
            typeof(string), 
            typeof(PlaceHolderTextBox));

        public string PlaceHolder
        {
            get { return (string)GetValue(PlaceHolderProperty); }
            set { SetValue(PlaceHolderProperty, value); }
        }

        public static readonly DependencyProperty InputTextProperty = DependencyProperty.Register(
            "InputText", 
            typeof(string), 
            typeof(PlaceHolderTextBox));

        public string InputText
        {
            get { return (string)GetValue(InputTextProperty); }
            set { SetValue(InputTextProperty, value); }
        }

        public override void OnApplyTemplate()
        {
            base.OnApplyTemplate();
            if (InputTextBox != null)
            {
                InputTextBox.KeyUp += InputTextBox_KeyUp;
                InputTextBox.GotFocus += InputTextBox_GotFocus;
                InputTextBox.LostFocus += InputTextBox_LostFocus;
                InputTextBox.Text = PlaceHolder;
            }
        }

        private void InputTextBox_KeyUp(object sender, KeyEventArgs e)
        {
            InputText = InputTextBox.Text;
        }

        private void InputTextBox_LostFocus(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(InputText))
            {
                InputTextBox.Text = PlaceHolder;
            }
            else
            {
                InputTextBox.Text = InputText;
            }
        }

        private void InputTextBox_GotFocus(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(InputText))
            {
                InputTextBox.Text = "";
            }
            else
            {
                InputTextBox.Text = InputText;
            }
        }
    }
}
