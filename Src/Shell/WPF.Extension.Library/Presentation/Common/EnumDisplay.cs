using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPF.Extension.Library.Presentation
{
    public class EnumDisplayable<T>: NotifyPropertyChanged
    {
        public EnumDisplayable(T em)
        {
            EnumValue = em;
            DisplayName = Enum.GetName(typeof(T), em);
        }

        private T enumValue;
        public T EnumValue
        {
            get { return enumValue; }
            set
            {
                if (!enumValue.Equals(value))
                {
                    enumValue = value;
                    DisplayName = Enum.GetName(typeof(T), value);
                    OnPropertyChanged(nameof(EnumValue));
                }
            }
        }

        private string displayName;
        public string DisplayName
        {
            get { return displayName; }
            set
            {
                if (displayName != value)
                {
                    displayName = value;
                    OnPropertyChanged(nameof(DisplayName));
                }
            }
        }

        public static List<EnumDisplayable<T>> GetEnumDisplayItems()
        {
            var values = Enum.GetValues(typeof(T));
            var list = new List<EnumDisplayable<T>>();
            foreach (var v in values)
            {
                var item = new EnumDisplayable<T>((T)v);
                list.Add(item);
            }

            return list;
        }
    }
}
