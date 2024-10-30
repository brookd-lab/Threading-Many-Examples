using System.ComponentModel.DataAnnotations;

namespace BlazorRecipeServer.Models
{
    public class Recipe
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
