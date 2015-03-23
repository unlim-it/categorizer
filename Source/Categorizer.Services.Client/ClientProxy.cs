namespace Categorizer.Services.Client
{
    using System;
    using System.ServiceModel;
    using System.Threading.Tasks;

    internal class ClientProxy<TService> : ClientBase<TService>, IClientProxy<TService>
        where TService : class
    {
        public async Task<TResult> Invoker<TResult>(Func<TService, Task<TResult>> service)
        {
            return await service.Invoke(this.Channel);
        }

        #region IDisposable Implementation
        
        protected virtual void Dispose(bool disposing)
        {
            try
            {
                if (this.State != CommunicationState.Closed)
                {
                    this.Close();
                }
            }
            catch (CommunicationException)
            {
                this.Abort();
            }
            catch (TimeoutException)
            {
                this.Abort();
            }
            catch
            {
                this.Abort();
                throw;
            }
        }

        public void Dispose()
        {
            this.Dispose(true);
            GC.SuppressFinalize(this);
        }

        #endregion
    }
}