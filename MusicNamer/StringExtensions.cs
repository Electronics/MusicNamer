using System;

namespace MusicNamer
{

    public static class StringExtensions
    {
        public static bool Contains(this string source, string toCheck, StringComparison comp)
        {
            if (source != null && toCheck != null)
            {
                return source.IndexOf(toCheck, comp) >= 0;
            }
            else return false;
        }
    }
}