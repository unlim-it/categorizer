namespace Categorizer.Domain.Models
{
    using System;
    using System.Collections.Generic;

    public class Category
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public ICollection<Keyword> Keywords { get; set; }
    }
}