namespace Categorizer.Services.Contracts
{
    using System.Collections.Generic;
    using System.ServiceModel;
    using System.Threading.Tasks;
    using System.ServiceModel.Web;
    
    [ServiceContract(Namespace = "")]
    public interface ICategorizerService
    {
        [OperationContract]
        [WebGet(UriTemplate = "/categories", ResponseFormat = WebMessageFormat.Json)]
        Task<IEnumerable<DtoCategory>> GetCategories();

        [OperationContract]
        [WebGet(UriTemplate = "/categories/{id}", ResponseFormat = WebMessageFormat.Json)]
        Task<DtoCategory> GetCategory(string id);

        [OperationContract]
        [WebInvoke(Method = "DELETE", UriTemplate = "/categories/{id}", ResponseFormat = WebMessageFormat.Json)]
        Task DeleteCategory(string id);

        [OperationContract]
        [WebInvoke(Method = "PUT", UriTemplate = "/categories", ResponseFormat = WebMessageFormat.Json)]
        Task UpdateCategory(DtoCategory category);

        [OperationContract]
        [WebInvoke(Method = "POST", UriTemplate = "/categories", ResponseFormat = WebMessageFormat.Json)]
        Task CreateCategory(DtoCategory category);

        [OperationContract]
        [WebInvoke(Method = "POST", UriTemplate = "/fragments", ResponseFormat = WebMessageFormat.Json)]
        Task<DtoFragment> UploadFragment(DtoFragment fragment);

        [OperationContract]
        [WebGet(UriTemplate = "/fragments?latest={latest}", ResponseFormat = WebMessageFormat.Json)]
        Task<IEnumerable<DtoFragment>> GetLatestFragments(int latest);

        [OperationContract]
        [WebGet(UriTemplate = "/fragments", ResponseFormat = WebMessageFormat.Json)]
        Task<IEnumerable<DtoFragment>> GetFragments();
    }
}
