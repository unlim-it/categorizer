namespace Categorizer.Services
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.ServiceModel;
    using System.ServiceModel.Activation;
    using System.Threading.Tasks;

    using Categorizer.Domain;
    using Categorizer.Domain.Exceptions;
    using Categorizer.Domain.Interfaces;
    using Categorizer.Services.Contracts;
    using Categorizer.Services.Tools;

    [AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Allowed)]
    public class CategorizerService : ICategorizerService
    {
        private readonly AutoCategorizer categorizer;

        public CategorizerService(IDataSource dataSource, ITextAnalizer textAnalizer)
        {
            this.categorizer = new AutoCategorizer(dataSource, textAnalizer);
        }

        public async Task<IEnumerable<DtoCategory>> GetCategories()
        {
            var categories = await this.categorizer.GetCategories();
            return categories.Select(CategorizerConverter.ToDto).ToList();
        }

        public async Task<DtoCategory> GetCategory(string id)
        {
            var category = await this.categorizer.GetCategory(Guid.Parse(id));
            return CategorizerConverter.ToDto(category);
        }

        public async Task DeleteCategory(string categoryId)
        {
            try
            {
                await this.categorizer.DeleteCategory(Guid.Parse(categoryId));
            }
            catch (CategorizerExceptionBase ex)
            {
                throw new FaultException<CategorizerFaultBase>(
                    new CategorizerFaultBase { Message = ex.Message });
            }
        }

        public async Task UpdateCategory(DtoCategory category)
        {
            try
            {
                await this.categorizer.UpdateCategory(CategorizerConverter.ToDomain(category));
            }
            catch (CategorizerExceptionBase ex)
            {
                throw new FaultException<CategorizerFaultBase>(
                    new CategorizerFaultBase { Message = ex.Message });
            }
        }

        public async Task CreateCategory(DtoCategory category)
        {
            try
            {
                await this.categorizer.AddCategory(CategorizerConverter.ToDomain(category));
            }
            catch (CategorizerExceptionBase ex)
            {
                throw new FaultException<CategorizerFaultBase>(
                    new CategorizerFaultBase { Message = ex.Message });
            }
        }

        public async Task<DtoFragment> UploadFragment(DtoFragment newFragment)
        {
            try
            {
                var fragment = await this.categorizer.AddText(newFragment.Text);
                var dtoFragment = CategorizerConverter.ToDto(fragment);

                return dtoFragment;
            }
            catch (FragmentDoNotBelongToAnyCategoryException)
            {
                return null;
            }
            catch (CategorizerExceptionBase ex)
            {
                throw new FaultException<CategorizerFaultBase>(new CategorizerFaultBase { Message = ex.Message });
            }
        }

        public async Task<IEnumerable<DtoFragment>> GetLatestFragments(int latest)
        {
            var fragments = await this.categorizer.GetLatestFragments(latest);
            return fragments.Select(CategorizerConverter.ToDto).ToList();
        }

        public async Task<IEnumerable<DtoFragment>> GetFragments()
        {
            var fragments = await this.categorizer.GetFragments();
            return fragments.Select(CategorizerConverter.ToDto).ToList();
        }
    }
}