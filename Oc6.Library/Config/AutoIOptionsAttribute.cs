using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Oc6.Library.Config
{
    [AttributeUsage(AttributeTargets.Class)]
    public class AutoIOptionsAttribute : Attribute
    {
        public string ConfigurationSectionName { get; }

        public AutoIOptionsAttribute(string configurationSectionName)
        {
            ConfigurationSectionName = configurationSectionName;
        }
    }
}
