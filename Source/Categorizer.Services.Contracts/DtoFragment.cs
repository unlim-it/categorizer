namespace Categorizer.Services.Contracts
{
    using System;
    using System.Runtime.Serialization;

    [DataContract]
    public class DtoFragment
    {
        [DataMember]
        public Guid Id { get; set; }
        [DataMember]
        public string Text { get; set; }
        [DataMember]
        public Guid CategoryId { get; set; }
        [DataMember]
        public DtoCategory Category { get; set; }
        [DataMember]
        public DateTime CreateAt { get; set; }
    }
}