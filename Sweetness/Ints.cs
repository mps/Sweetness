using System.Collections.Generic;

namespace Sweetness
{
    public static class Ints
    {
        public static IEnumerable<int> To(this int from, int to)
        {
            if (to >= from)
            {
                for (var i = from; i <= to; i++)
                {
                    yield return i;
                }
            }
            else
            {
                for (var i = from; i >= to; i--)
                {
                    yield return i;
                }
            }
        }
    }
}