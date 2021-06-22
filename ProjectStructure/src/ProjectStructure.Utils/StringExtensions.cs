using System;

namespace ProjectStructure.Utils
{
    public static class StringExtensions
    {
        public static bool IsNullOrEmpty(this string value)
        {
            if (value == null)
                return true;

            if (value.Trim().Equals(string.Empty))
                return true;

            return false;
        }

        public static string TrimIfNotNull(this string value)
        {
            return value?.Trim();
        }

        public static bool IsValidMaxLength(this string value, int length)
        {
            if (length < 0)
                throw new InvalidOperationException("length can't be negative");

            if (value == null)
                return true;

            return value.Trim().Length <= length;
        }

        public static bool HasMaxLength(this string value, int length)
        {
            if (length < 0)
                throw new InvalidOperationException("length can't be negative");

            if (value == null)
                return false;

            return value.Trim().Length > length;
        }
    }
}
