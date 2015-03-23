namespace Categorizer.Web.Controllers
{
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Threading.Tasks;
    using System.Web.Mvc;

    using Categorizer.Services.Client;
    using Categorizer.Services.Contracts;
    using Categorizer.Web.Models;

    public class DashboardController : Controller
    {
        public async Task<ActionResult> Index()
        {
            TempData["Fragments"] = await this.GetLatestFragments();
            return this.View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Index(UploadTextModel model)
        {
            var textes = new List<string>();

            if (!string.IsNullOrWhiteSpace(model.Text))
            {
                textes.Add(model.Text);
            }

            if (model.FileInput1 != null)
            {
                using (var reader = new StreamReader(model.FileInput1.InputStream))
                {
                    var file1Text = await reader.ReadToEndAsync();
                    textes.Add(file1Text);
                }
            }

            if (model.FileInput2 != null)
            {
                using (var reader = new StreamReader(model.FileInput2.InputStream))
                {
                    var file2Text = await reader.ReadToEndAsync();
                    textes.Add(file2Text);
                }
            }

            if (!textes.Any())
            {
                return this.RedirectToAction("Index");
            }

            using (var proxy = ServiceProxy.For<ICategorizerService>())
            {
                var tasks = textes
                    .Select(text => proxy.Invoker(it => it.UploadFragment(new DtoFragment { Text = text })))
                    .ToList();

                var fragmentResults = await Task.WhenAll(tasks);

                var isAllSuccess = fragmentResults.All(it => it != null);
                this.ViewBag.IsUploadSuccess = isAllSuccess;

                this.ViewBag.Message = isAllSuccess
                    ? string.Format(LocalizationStrings.SuccessTextSuccessfullyAdded, 
                        string.Join(", ", fragmentResults.Where(it => it != null).Select(it => it.Category.Name)))
                    : LocalizationStrings.ErrorUploadingTextIsNotCategorized;

                this.ModelState.Clear();

                TempData["Fragments"] = await this.GetLatestFragments();

                return this.View();
            }
        }

        private async Task<IEnumerable<DtoFragment>> GetLatestFragments()
        {
            using (var proxy = ServiceProxy.For<ICategorizerService>())
            {
                var fragments = await proxy.Invoker(it => it.GetLatestFragments(5));
                return fragments;
            }
        }
    }
}