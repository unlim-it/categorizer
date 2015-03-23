namespace Categorizer.Web.Controllers
{
    using System.Threading.Tasks;
    using System.Web.Mvc;

    using Categorizer.Services.Client;
    using Categorizer.Services.Contracts;

    public class TextLogController : Controller
    {
        public async Task<ActionResult> Index()
        {
            using (var proxy = ServiceProxy.For<ICategorizerService>())
            {
                var fragments = await proxy.Invoker(it => it.GetFragments());
                return this.View(fragments);
            }
        }
    }
}