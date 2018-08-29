using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace WPF.Extension.Library.Controls
{
    public class IconButton : Button
    {
        /// <summary>
        /// Identifies the RectangleDiameter property.
        /// </summary>
        public static readonly DependencyProperty RectangleDiameterProperty = DependencyProperty.Register("RectangleDiameter", typeof(double), typeof(IconButton), new PropertyMetadata(22D));
        /// <summary>
        /// Identifies the RectangleStrokeThickness property.
        /// </summary>
        public static readonly DependencyProperty RectangleStrokeThicknessProperty = DependencyProperty.Register("RectangleStrokeThickness", typeof(double), typeof(IconButton), new PropertyMetadata(1D));
        /// <summary>
        /// Identifies the IconData property.
        /// </summary>
        public static readonly DependencyProperty IconDataProperty = DependencyProperty.Register("IconData", typeof(Geometry), typeof(IconButton));
        /// <summary>
        /// Identifies the IconHeight property.
        /// </summary>
        public static readonly DependencyProperty IconHeightProperty = DependencyProperty.Register("IconHeight", typeof(double), typeof(IconButton), new PropertyMetadata(12D));
        /// <summary>
        /// Identifies the IconWidth property.
        /// </summary>
        public static readonly DependencyProperty IconWidthProperty = DependencyProperty.Register("IconWidth", typeof(double), typeof(IconButton), new PropertyMetadata(12D));

        /// <summary>
        /// Initializes a new instance of the <see cref="IconButton"/> class.
        /// </summary>
        public IconButton()
        {
            this.DefaultStyleKey = typeof(IconButton);
        }

        /// <summary>
        /// Gets or sets the Rectangle diameter.
        /// </summary>
        public double RectangleDiameter
        {
            get { return (double)GetValue(RectangleDiameterProperty); }
            set { SetValue(RectangleDiameterProperty, value); }
        }

        /// <summary>
        /// Gets or sets the Rectangle stroke thickness.
        /// </summary>
        public double RectangleStrokeThickness
        {
            get { return (double)GetValue(RectangleStrokeThicknessProperty); }
            set { SetValue(RectangleStrokeThicknessProperty, value); }
        }

        /// <summary>
        /// Gets or sets the icon path data.
        /// </summary>
        /// <value>
        /// The icon path data.
        /// </value>
        public Geometry IconData
        {
            get { return (Geometry)GetValue(IconDataProperty); }
            set { SetValue(IconDataProperty, value); }
        }

        /// <summary>
        /// Gets or sets the icon height.
        /// </summary>
        /// <value>
        /// The icon height.
        /// </value>
        public double IconHeight
        {
            get { return (double)GetValue(IconHeightProperty); }
            set { SetValue(IconHeightProperty, value); }
        }

        /// <summary>
        /// Gets or sets the icon width.
        /// </summary>
        /// <value>
        /// The icon width.
        /// </value>
        public double IconWidth
        {
            get { return (double)GetValue(IconWidthProperty); }
            set { SetValue(IconWidthProperty, value); }
        }
    }
}
