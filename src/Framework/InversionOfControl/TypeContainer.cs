using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;

namespace Nova.Framework.InversionOfControl
{
    public static class TypeContainer
    {
        private static IContainer _container;

        static TypeContainer()
        {
            _container = CreateContainer();
        }

        public static void RegisterTypesForApplication(IEnumerable<string> assemblyPaths)
        {
            IList<string> assembliesToRegister = new List<string>();

            foreach (string assemblyPath in assemblyPaths)
            {
                try
                {
                    RegisterTypesInAssembly(Assembly.LoadFrom(assemblyPath));
                }
                catch (Exception)
                {
                    // todo: log the error
                    throw;
                }
            }
        }

        public static T GetInstance<T>()
        {
            return _container.Resolve<T>();   
        }

        public static T GetInstance<T>(string name)
        {
            return _container.Resolve<T>(name);   
        }

        private static void RegisterTypesInAssembly(Assembly assembly)
        {
            IList<Type> types = new List<Type>(assembly.GetTypes());

            foreach (Type type in types)
            {
                if (typeof(IInstaller).IsAssignableFrom(type) && !type.IsAbstract)
                {
                    IInstaller installer = (IInstaller)Activator.CreateInstance(type);
                    
                    // register all the types listed in the installer 
                    installer.Install(_container);
                }
            }
        }

        private static IContainer CreateContainer()
        {
            // todo: assembly is hard-coded for now. 
            string dir = Path.GetDirectoryName(Assembly.GetExecutingAssembly().CodeBase).Replace("file:\\", string.Empty);
            var assemblyPath = Path.Combine(dir, "Nova.Application.IoCContainer.Windsor.dll");

            Assembly assembly = Assembly.LoadFrom(assemblyPath);
            var containerType = assembly.GetTypes().Single(t => typeof(IContainer).IsAssignableFrom(t));

            return (IContainer)Activator.CreateInstance(containerType);
        }
    }
}
