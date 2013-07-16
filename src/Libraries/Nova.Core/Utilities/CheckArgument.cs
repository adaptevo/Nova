using System;

namespace Nova.Core.Utilities
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
    }
}
