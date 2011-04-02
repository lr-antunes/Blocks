using System;

namespace Rovidi.Blocks.Development
{
    public class Assert
    {

        #region static Methods

        public static void IsTrue(bool condition)
        {
            if (!condition)
                throw new ArgumentException("The condition is False.");
        }

        public static void IsFalse(bool condition)
        {
            if (condition)
                throw new ArgumentException("The condition is True.");
        }

        public static void IsNotNull(object obj)
        {
            if (obj == null)
            {
                throw new ArgumentNullException("The argument cannot be null.");
            }
        }

        public static void IsNull(object obj)
        {
            if (obj != null)
            {
                throw new ArgumentNullException("The argument is not null.");
            }
        }

        #endregion

    }
}
