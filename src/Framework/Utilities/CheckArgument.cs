using System;

namespace Nova.Framework.Utilities
{
    public static class CheckArgument
    {
        public static T NotNull<T>(T value, string argument) where T : class
        {
            if (value == null)
            {
                throw new ArgumentNullException(argument);
            }

            return value;
        }

        public static string NotEmpty(string value, string argument)
        {
            NotNull(value, argument);

            if (string.IsNullOrWhiteSpace(value))
            {
                throw new ArgumentException(string.Format("Argument {0} must have a non-empty string value", argument));
            }

            return value;
        }

        public static T NotDefault<T>(T value, string argument) where T : struct
        {
            if (object.Equals(value, default(T)))
            {
                throw new ArgumentException(string.Format("Argument {0} must not be the default value of {1}", argument, value));
            }

            return value;
        }

        public static int GreaterThan<T>(int value, int boundary, string argument) where T : IComparable<T>
        {
            if (value.CompareTo(boundary) <= 0)
            {
                throw new ArgumentOutOfRangeException(string.Format("Argument {0} must be greater than {1}", argument, boundary));
            }

            return value;
        }

        public static int GreaterThanOrEqualTo<T>(int value, int boundary, string argument) where T : IComparable<T>
        {
            if (value.CompareTo(boundary) < 0)
            {
                throw new ArgumentOutOfRangeException(string.Format("Argument {0} must be greater than or equal to {1}", argument, boundary));
            }

            return value;
        }

        public static bool IsValid(bool condition, string value, string argument)
        {
            if (!condition)
            {
                throw new ArgumentException(string.Format("Argument {0} is not valid: {1}", argument, value));
            }

            return condition;
        }
    }
}
