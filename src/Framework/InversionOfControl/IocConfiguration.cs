using System.Configuration;

namespace Nova.Framework.InversionOfControl
{
    public class IocConfiguration : ConfigurationSection
    {
        private readonly string _configSectionName = "nova";
        
        /// <summary>
        ///  Reads the DI container name from the 'container' of 'ioc' tag within the 'nova' section in the web.config file.
        /// </summary>
        /// <returns>The name of the DI container to use.</returns>
        public string GetContainerName()
        {
            IocConfiguration configSection = ConfigurationManager.GetSection(_configSectionName) as IocConfiguration;
            return configSection.IocElement.IocContainerName;
        }

        [ConfigurationProperty("ioc", IsRequired = true)]
        internal IocConfigurationElement IocElement
        {
            get
            {
                return (IocConfigurationElement)base["ioc"];
            }
        }
    }
}
