using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPF.Extension.Shell.Utility
{
    /// <summary>
    /// Singleton pattern with lazy initialization.
    /// </summary>
    public static class Singleton<T>
        where T : new()
    {
        /// <summary>
        /// Gets the instance.
        /// </summary>
        /// <value>The instance.</value>
        [SuppressMessage("Microsoft.Design", "CA1000: Do not declare static members on generic types")]
        public static T Instance
        {
            get
            {
                return Nested.NestedInstance;
            }
        }

        /// <summary>
        /// static singleton instance
        /// </summary>
        internal static class Nested
        {
            // Explicit static constructor to tell C# compiler
            // not to mark type as beforefieldinit
            static Nested()
            {
            }

            // ReSharper disable StaticFieldInGenericType
            internal static readonly T NestedInstance = new T();
            // ReSharper restore StaticFieldInGenericType
        }
    }
}
