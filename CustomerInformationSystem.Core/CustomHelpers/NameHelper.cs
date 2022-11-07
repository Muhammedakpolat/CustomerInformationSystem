using System.Collections.Generic;
using System.Linq;

namespace CustomerInformationSystem.Core.CustomHelpers
{
    public static class NameHelper
    {
        private static readonly char[] _vowels = { 'a', 'e', 'ı', 'i', 'o', 'ö', 'u', 'ü' };

        public static bool IsExtraordinaryName(string name)
        {
            List<char> nameChars = name.ToLower().ToList();

            foreach (char character in name.ToLower())
                foreach (char vowel in _vowels)
                    if (character == vowel)
                    {
                        var count = nameChars.CountTimes(character);
                        if (count >= 3)
                            return true;
                    }

            return false;
        }

        private static int CountTimes<T>(this List<T> list, T item)
        {
            return ((from t in list where t.Equals(item) select t).Count());
        }
    }
}
