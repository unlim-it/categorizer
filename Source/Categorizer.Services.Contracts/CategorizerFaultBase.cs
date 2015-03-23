namespace Categorizer.Services.Contracts
{
    using System.Runtime.Serialization;

    [DataContract]
    public class CategorizerFaultBase
    {
        [DataMember]
        public string Message { get; set; }
    }
}