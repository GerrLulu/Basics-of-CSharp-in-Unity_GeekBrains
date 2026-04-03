using System;

namespace Helper
{
    public static class Extensions
    {
        public static int SymbolsCounting(this string self)
        {
            int count = 0;

            foreach (var symbol in self)
                count++;

            return count;
        }

        public static bool TryBool(this string self)
        {
            return Boolean.TryParse(self, out var res) && res;
        }
    }
}