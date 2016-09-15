﻿namespace Gu.Wpf.Media.Demo.UiTestWindows
{
    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.Globalization;
    using System.Linq;
    using System.Reflection;
    using System.Windows;
    using System.Windows.Data;

    public class MediaElementToPropertyListConverter : IValueConverter
    {
        public static readonly MediaElementToPropertyListConverter Default = new MediaElementToPropertyListConverter();

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var wrapper = (MediaElementWrapper)value;
            return GetPropertyItems(wrapper);
        }

        object IValueConverter.ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }

        public static ReadOnlyObservableCollection<PropertyItem> GetPropertyItems(MediaElementWrapper wrapper)
        {
            var dps = typeof(MediaElementWrapper).GetFields(BindingFlags.Static | BindingFlags.Public)
                                                 .Where(f => f.FieldType == typeof(DependencyProperty))
                                                 .Select(f => f.GetValue(null))
                                                 .OfType<DependencyProperty>()
                                                 .OrderBy(x => x.Name)
                                                 .ToArray();
            var props = dps.Select(dp => new PropertyItem(wrapper, dp))
                      .ToArray();
            return new ReadOnlyObservableCollection<PropertyItem>(new ObservableCollection<PropertyItem>(props));
        }
    }
}
