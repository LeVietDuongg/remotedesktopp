using System;
using System.Linq;
using System.Text;

namespace Network.Extensions
{
    public static class StringExtensions
    {
        public enum UnformatOptions
        {
         
            DigitsOnly,

            LettersOnly,

          
            DigitsAndLettersOnly,
        }

        public static String FormatId(this String str)
        {
            int insertIndex = (str.Length / 2) - 1;
            return str.Insert(insertIndex, "-");
        }

        public static String Unformat(this String str, UnformatOptions options)
        {
            var stringBuilder = new StringBuilder();

            switch (options)
            {
                case UnformatOptions.DigitsOnly:
                    stringBuilder.Append(str.Where(e => Char.IsDigit(e)));
                    break;
                case UnformatOptions.LettersOnly:
                    stringBuilder.Append(str.Where(e => Char.IsLetter(e)));
                    break;
                case UnformatOptions.DigitsAndLettersOnly:
                    stringBuilder.Append(str.Where(e => Char.IsLetterOrDigit(e)));
                    break;
            }

            return stringBuilder.ToString();
        }
    }
}