namespace Categorizer.Services.Contracts
{
    using System;
    using System.Collections.Generic;
    using System.Runtime.Serialization;

    [DataContract]
    public class DtoCategory
    {
        [DataMember]
        public Guid Id { get; set; }
        [DataMember]
        public string Name { get; set; }
        [DataMember]
        public IEnumerable<DtoKeyword> Keywords { get; set; }

    }
}