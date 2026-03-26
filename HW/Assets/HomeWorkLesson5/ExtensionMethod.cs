namespace HomeWorkLesson5
{
    public static class ExtensionMethod
    {
        public static int SymbolsCounting(this string self)
        {
            int count = 0;

            foreach (var symbol in self)
                count++;

            return count;
        }
    }
}