using System;

namespace Nova.Framework.InversionOfControl
{
    public interface IContainer : IRegister, IResolve, IDisposable { }
}
