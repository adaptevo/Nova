using System;
using System.Collections.Generic;
using System.Reflection;

namespace Nova.Libraries.Ioc
{
    public static class IocContainer
    {
        public static void RegisterTypesForApplication(IList<string> assemblyPaths)
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
                    throw;
                }
            }
        }

        private static void RegisterTypesInAssembly(Assembly assembly)
        {
            IList<Type> types = new List<Type>(assembly.GetTypes());

            foreach (Type type in types)
            {
                if (typeof(IocModule).IsAssignableFrom(type) && !type.IsAbstract)
                {
                    IocModule iocModule = (IocModule)Activator.CreateInstance(type);
                    //iocModule.RegisterTypes();
                }
            }
        }
    }
}
