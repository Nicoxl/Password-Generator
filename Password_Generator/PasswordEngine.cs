using System;              
using System.Text;         
using System.Linq;         

namespace Password_Generator
{
    public static class PasswordEngine
    {
        private const string LowercaseLetters = "abcdefghijklmnopqrstuvwxyz";
        private const string UppercaseLetters = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
        private const string Digits = "0123456789";
        private const string SpecialCharacters = "!@#$%^&*()-_=+[]{}|;:',.<>?/`~";
        private const string AmbiguousCharacters = "Il1O0";

        private static readonly Random _random = new();

        public static string GeneratePassword(int length, bool includeUppercase, bool includeDigits, bool includeSpecial, bool ambiguousCharacters)
        {
            if (length < 1) length = 12;

            StringBuilder pool = new();
            pool.Append(LowercaseLetters); // incluse di default

            // costruzione del pool di caratteri
            if (includeUppercase) pool.Append(UppercaseLetters);
            if (includeDigits) pool.Append(Digits);
            if (includeSpecial) pool.Append(SpecialCharacters);
            if (ambiguousCharacters) {
                // rimuove i caratteri ambigui dal pool
                string filteredPool = new([.. pool.ToString().Where(c => !AmbiguousCharacters.Contains(c))]);
                pool.Clear();
                pool.Append(filteredPool);
            }

            string finalPool = pool.ToString();

            // fallback se qualcosa va storto
            if (string.IsNullOrEmpty(finalPool)) finalPool = LowercaseLetters;

            StringBuilder password = new();

            // generazione della password
            for (int i = 0; i < length; i++)
            {
                int index = _random.Next(finalPool.Length);
                password.Append(finalPool[index]);
            }

            return password.ToString();
        }
    }
}
