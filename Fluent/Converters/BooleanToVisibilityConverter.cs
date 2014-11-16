namespace Fluent
{
	using System;
	using System.Globalization;
	using System.Windows;
	using System.Windows.Data;

    /// <summary>
    /// Used to invert numbers
    /// </summary>
    public class BooleanToVisibilityConverter : IValueConverter
    {
        #region Implementation of IValueConverter

		public BooleanToVisibilityConverter()
		{

		}

		public BooleanToVisibilityConverter(bool inverted, bool collapse)
		{
			Inverted = inverted;
			Collapse = collapse;
		}

		public bool Inverted { get; set; }
		public bool Collapse { get; set; }

        /// <summary>
        /// Converts a value. 
        /// </summary>
        /// <returns>
        /// A converted value. If the method returns null, the valid null value is used.
        /// </returns>
        /// <param name="value">The value produced by the binding source.</param><param name="targetType">The type of the binding target property.</param><param name="parameter">The converter parameter to use.</param><param name="culture">The culture to use in the converter.</param>
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
			bool? boolValue = value as bool?;
			if (!boolValue.HasValue)
				return Visibility.Visible;

			if (Inverted)
				boolValue = !boolValue.Value;

			if (boolValue.Value)
				return Visibility.Visible;

			if (Collapse)
				return Visibility.Collapsed;

			return Visibility.Hidden;
        }

        /// <summary>
        /// Converts a value. 
        /// </summary>
        /// <returns>
        /// A converted value. If the method returns null, the valid null value is used.
        /// </returns>
        /// <param name="value">The value that is produced by the binding target.</param><param name="targetType">The type to convert to.</param><param name="parameter">The converter parameter to use.</param><param name="culture">The culture to use in the converter.</param>
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return this.Convert(value, targetType, parameter, culture);
        }

        #endregion
    }
}