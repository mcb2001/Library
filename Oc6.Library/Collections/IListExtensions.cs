using Oc6.Library.Resources;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Oc6.Library.Collections
{
    public static class IListExtensions
    {
        public static IList<T> Shuffle<T>(this IList<T> list)
        {
            for (int i = list.Count - 1; i > 0; --i)
            {
                int j = Random.Shared.Next(0, i + 1);
                (list[i], list[j]) = (list[j], list[i]);
            }

            return list;
        }

        public static T TakeAndRemoveLast<T>(this IList<T> list)
        {
            if(list.Count == 0)
            {
                throw new ArgumentOutOfRangeException(nameof(list), ErrorMessages.ListCannotBeEmpty);
            }

            T t = list[^1];
            list.RemoveAt(list.Count - 1);
            return t;
        }
    }
}
