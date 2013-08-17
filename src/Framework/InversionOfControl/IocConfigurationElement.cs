using System.Configuration;

namespace Nova.Framework.InversionOfControl
{
    internal class IocConfigurationElement : ConfigurationElement
    {
        [ConfigurationProperty("container", IsRequired = true)]
        public string IocContainerName
        {
            get
            {
                return (string)base["container"];
            }
        }
    }
}
