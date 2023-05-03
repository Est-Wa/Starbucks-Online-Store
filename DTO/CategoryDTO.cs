using Entities;
using System.Text.Json.Serialization;

namespace DTO {
    public class CategoryDTO 
    {
        public int CategoryId { get; set; }

        public string? CategoryName { get; set; }

    }
}