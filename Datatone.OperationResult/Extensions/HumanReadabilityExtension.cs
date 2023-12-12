using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datatone.OperationResult.Extensions
{
    internal static class HumanReadabilityExtension
    {
        public static string? ToHumanReadableString(this object? obj)
        {
            if(obj == null) return null;
            return obj is IEnumerable<object> collection ? string.Join(",\n", collection) : obj.ToString();
        }
    }
}
