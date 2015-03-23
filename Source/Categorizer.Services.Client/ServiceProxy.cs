namespace Categorizer.Services.Client
{
    public class ServiceProxy
    {
        public static IClientProxy<TService> For<TService>() where TService : class
        {
            return new ClientProxy<TService>();
        }
    }
}
