using PozitronDev.Validations;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace PozitronDev.Utils.Extensions
{
    /// <summary>
    /// Container for string extensions.
    /// </summary>
    public static class StringExtensions
    {
        /// <summary>
        /// Compare the string value against several string inputs.
        /// </summary>
        /// <param name="data"></param>
        /// <param name="compareType"></param>
        /// <param name="compareValues"></param>
        /// <returns>True if any match is found.</returns>
        public static bool EqualsMultiple(this string data, StringComparison compareType, params string[] compareValues)
        {
            foreach (string s in compareValues)
            {
                if (data.Equals(s, compareType))
                {
                    return true;
                }
            }
            return false;
        }

        /// <summary>
        /// Check if the string value contains only alphanumeric characters.
        /// </summary>
        /// <param name="inputString"></param>
        /// <returns>True if all letters are alphanumeric. In case the string value is null, empty or white spaces only, it returns False</returns>
        public static bool IsAlphanumeric(this string inputString)
        {
            if (string.IsNullOrWhiteSpace(inputString)) return false;
            return inputString.All(x => char.IsLetterOrDigit(x));
        }

        /// <summary>
        /// Get filename safe version of the string value.
        /// Throws an <see cref="ArgumentNullException" /> if the string value is null.
        /// Throws an <see cref="ArgumentException" /> if the string value is an empty string or it containts only white spaces.
        /// </summary>
        /// <param name="inputString"></param>
        /// <returns>String where all invalid characters and spaces are replaced with underscore "_".</returns>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="ArgumentException"></exception>
        public static string GetFilenameSafe(this string inputString)
        {
            PozValidate.For.NullOrWhiteSpace(inputString, nameof(inputString));

            string temp = Path.GetInvalidFileNameChars().Aggregate(inputString, (current, c) => current.Replace(c.ToString(), "_"));
            return string.Join("_", temp.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries));
        }

        /// <summary>
        /// Split the string value using the non-alphanumeric characters it contains as delimiters.
        /// Throws an <see cref="ArgumentNullException" /> if the value is null.
        /// Throws an <see cref="ArgumentException" /> if the value is an empty or it containts only white spaces.
        /// </summary>
        /// <param name="inputString"></param>
        /// <returns>Array of string containing only alphanumeric substrings</returns>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="ArgumentException"></exception>
        public static string[] SplitStringAlphanumeric(this string inputString)
        {
            PozValidate.For.NullOrWhiteSpace(inputString, nameof(inputString));

            char[] s = inputString.Where(x => !char.IsLetterOrDigit(x)).ToArray();
            return inputString.Split(s, StringSplitOptions.RemoveEmptyEntries);
        }
    }
}
