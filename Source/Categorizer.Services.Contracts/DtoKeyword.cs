namespace Categorizer.Services.Contracts
{
    using System;
    using System.Runtime.Serialization;

    [DataContract]
    public class DtoKeyword
    {
        [DataMember]
        public Guid Id { get; set; }
        [DataMember]
        public string Value { get; set; }
    }
}