using System.Collections.Generic;
using System.Linq;

namespace Volvo.BFF.Utils
{
   public static class ObjectComparer<T>
    {
        public static bool IsDiff(T originalObj, T newObj)
        {
            var differences = false;
            var props = typeof(T).GetProperties();
            for (int i = 0; i < props.Count(); i++)
            {
                var originalVal = props[i].GetValue(originalObj, null);
                var newVal = props[i].GetValue(newObj, null);
                if (originalVal?.GetHashCode() != newVal?.GetHashCode())
                    differences = true;
            }
            return differences;
        }
    }
}