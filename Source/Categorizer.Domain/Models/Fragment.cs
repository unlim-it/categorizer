namespace Categorizer.Domain.Models
{
    using System;

    public class Fragment
    {
        public Guid Id { get; set; }
        public string Text { get; set; }
        public Guid CategoryId { get; set; }
        public Category Category { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}