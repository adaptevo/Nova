using System;
using System.IO;
using System.Linq;
using System.Reflection;

namespace Nova.Framework.IoCContainer
{
    public class IoCFactory
    {
        private readonly string _containerAssemblyName;

        public IoCFactory(string containerAssemblyName)
        {
            _containerAssemblyName = containerAssemblyName;
        }

        public IContainer Create(IInstaller installer)
        {
            var assemblyWithLocation = GetAssemblyNameWithLocation();
            var assembly = Assembly.LoadFrom(assemblyWithLocation);

            var containerType =
                assembly.GetTypes().Single(x => x.GetInterface(typeof(IContainer).FullName) != null);
            var container = (IContainer)Activator.CreateInstance(containerType);
            installer.Install(container);
            return container;
        }

        private string GetAssemblyNameWithLocation()
        {
            var location = Path.GetDirectoryName(Assembly.GetExecutingAssembly().CodeBase);
            var assemblyNameWithLocation = Path.Combine(location, GetAssemblyName()).Replace("file:\\", "");

            if (!File.Exists(assemblyNameWithLocation))
                throw new FileNotFoundException("unable to find assembly");
            return assemblyNameWithLocation;
        }

        private string GetAssemblyName()
        {
            return string.Format("{0}.dll", _containerAssemblyName);
        }
    }
}
