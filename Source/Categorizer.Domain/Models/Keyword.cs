namespace Categorizer.Domain.Models
{
    using System;
    using System.Collections.Generic;

    public class Keyword
    {
        public Guid Id { get; set; }
        public string Value { get; set; }
        public ICollection<Category> Categories { get; set; }
    }
}