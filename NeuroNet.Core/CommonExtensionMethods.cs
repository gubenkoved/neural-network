using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;

namespace NeuroNet.Core
{
    public static class CommonExtensionMethods
    {
        public static void Times(this int numOfTimes, Action action)
        {
            for (int i = 0; i < numOfTimes; i++)
            {
                action.Invoke();
            }
        }

        public static void Times(this int numOfTimes, Action<int> action)
        {
            for (int i = 0; i < numOfTimes; i++)
            {
                action.Invoke(i);
            }
        }

        public static T As<T> (this object obj) where T: class
        {
            if (obj is T)
                return obj as T;
            else
                throw new Exception("Can't convert to " + typeof(T).Name);
        }

        public static IEnumerable<T> UnionArray<T>(this IEnumerable<T>[] array) where T : class
        {
            var union = new List<T>();

            foreach (var enumerable in array)
            {
                union.AddRange(enumerable);
            }

            return union;
        }

        public static string CreateString(this IEnumerable<char> chars)
        {
            return new string(chars.ToArray());
        }

        public static bool AnyPixel(this Bitmap bitmap, Func<Color, bool> predicate )
        {
            for (int i = 0; i < bitmap.Width; i++)
            {
                for (int j = 0; j < bitmap.Height; j++)
                {
                    if (predicate(bitmap.GetPixel(i, j)) == true)
                        return true;
                }
            }

            return false;
        }
    }
}