using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Nova.Framework.IoCContainer
{
    public interface IResolve
    {
        T Resolve<T>();
        T Resolve<T>(string key);
        bool CanResolve<T>();
        bool CanResolve<T>(string key);
        void Release(object instance);
    }
}
