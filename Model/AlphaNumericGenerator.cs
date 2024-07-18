using System;
using System.Security.Cryptography;

namespace Model
{
    // Nova ID:   f2h   1,594,323 Permutations
    // Password:  
    public enum GeneratorOptions
    {
        Alpha = 1,
        Numeric = 2,
        AlphaNumeric = Alpha + Numeric,
        AlphaNumericSpecial = 4
    }

    /// <remarks>Copied from http://eyeung003.blogspot.com/2010/09/c-random-password-generator.html </remarks>
    public class AlphaNumericGenerator
    {
        
        private static int DEFAULT_PASSWORD_LENGTH = 3;


        private static string PASSWORD_CHARS_Alpha =
            "fhpqrw";

        private static string PASSWORD_CHARS_NUMERIC = "2456789";
        private static string PASSWORD_CHARS_SPECIAL = "*$-+?_&=!%{}/";

        #region Overloads

        public static string Generate()
        {
            return Generate(DEFAULT_PASSWORD_LENGTH,
                            GeneratorOptions.Numeric);
        }

      
        public static string Generate(GeneratorOptions option)
        {
            return Generate(DEFAULT_PASSWORD_LENGTH, option);
        }

    
        public static string Generate(int passwordLength)
        {
            return Generate(DEFAULT_PASSWORD_LENGTH,
                            GeneratorOptions.Numeric);
        }

       
        public static string Generate(int passwordLength,
                                      GeneratorOptions option)
        {
            return GeneratePassword(passwordLength, option);
        }

        #endregion

        
        private static string GeneratePassword(int passwordLength,
                                               GeneratorOptions option)
        {
            if (passwordLength < 0) return null;

            var passwordChars = GetCharacters(option);

            if (string.IsNullOrEmpty(passwordChars)) return null;

            var password = new char[passwordLength];

            var random = GetRandom();

            for (int i = 0; i < passwordLength; i++)
            {
                var index = random.Next(passwordChars.Length);
                var passwordChar = passwordChars[index];

                password[i] = passwordChar;
            }

            return new string(password);
        }


       
        private static string GetCharacters(GeneratorOptions option)
        {
            switch (option)
            {
                case GeneratorOptions.Alpha:
                    return PASSWORD_CHARS_Alpha;
                case GeneratorOptions.Numeric:
                    return PASSWORD_CHARS_NUMERIC;
                case GeneratorOptions.AlphaNumeric:
                    return PASSWORD_CHARS_Alpha + PASSWORD_CHARS_NUMERIC;
                case GeneratorOptions.AlphaNumericSpecial:
                    return PASSWORD_CHARS_Alpha + PASSWORD_CHARS_NUMERIC +
                           PASSWORD_CHARS_SPECIAL;
                default:
                    break;
            }
            return string.Empty;
        }
        private static Random GetRandom()
        {
            
            var randomBytes = new byte[4];

          
            var rng = new RNGCryptoServiceProvider();
            rng.GetBytes(randomBytes);

          
            int seed = (randomBytes[0] & 0x7f) << 24 |
                       randomBytes[1] << 16 |
                       randomBytes[2] << 8 |
                       randomBytes[3];

            return new Random(seed);
        }
    }
}