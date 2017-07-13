using System;
using System.Collections.Generic;
using System.Text;

namespace HurriyetHaberMobile.Core
{ 
    public static class TextExtensions
    {
        public static string TagSubstring(this string input)
        {
            if (string.IsNullOrEmpty(input)) return string.Empty;

            try
            {
                string[] array = input.Split('/');
                input = array[1];
                input = input.Replace("-", " ");
                input = input.Replace("/", string.Empty);
            }
            catch { }

            return input;
        }
        public static string StringListToString(this List<string> input)
        {
            StringBuilder sb = new StringBuilder();
            foreach (var item in input)
            {
                sb.Append($"{item}, ");
            }
            string value = sb.ToString();
            value.TrimEnd(' ').TrimEnd(',');

            return value;
        }

        public static DateTime ToDate(this string input)
        {
            DateTime value;
            DateTime.TryParse(input, out value);
            return value;
        }
    }
}