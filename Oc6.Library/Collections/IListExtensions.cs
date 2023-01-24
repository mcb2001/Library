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
        public static void Shuffle<T>(this IList<T> list)
        {
            if (list == null)
            {
                throw new ArgumentNullException(nameof(list), ErrorMessages.ListCannotBeNull);
            }

            for (int i = list.Count - 1; i > 0; --i)
            {
                int j = Random.Shared.Next(0, i + 1);
                (list[i], list[j]) = (list[j], list[i]);
            }
        }

        public static T TakeAndRemoveLast<T>(this IList<T> list)
        {
            if (list == null)
            {
                throw new ArgumentNullException(nameof(list), ErrorMessages.ListCannotBeNull);
            }

            T t = list[^1];
            list.RemoveAt(list.Count - 1);
            return t;
        }
    }
}
