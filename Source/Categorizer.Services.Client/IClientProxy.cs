namespace Categorizer.Services.Client
{
    using System;
    using System.Threading.Tasks;

    public interface IClientProxy<out TService> : IDisposable
    {
        Task<TResult> Invoker<TResult>(Func<TService, Task<TResult>> service);
    }
}