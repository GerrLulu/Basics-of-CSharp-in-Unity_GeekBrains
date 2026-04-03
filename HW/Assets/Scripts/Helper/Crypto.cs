using System;

namespace Helper
{
    public static class Crypto
    {
        private const int KEY = 42;


        public static string CryptoXOR(string text)
        {
            var result = String.Empty;

            foreach (char symbol in text)
            {
                result += (char)(symbol ^ KEY);
            }
            
            return result;
        }
    }
}