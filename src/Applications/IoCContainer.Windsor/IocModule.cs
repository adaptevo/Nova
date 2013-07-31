using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nova.Libraries.Ioc
{
    public abstract class IocModule
    {
        public abstract void Register<TInterface, TClass>()
            where TInterface : class
            where TClass : TInterface;
    }
}
