using BlazorRecipeServer.Data;
using BlazorRecipeServer.Models;

namespace BlazorRecipeServer.Services
{
    public class RecipeService
    {
        private readonly ApplicationDbContext _context;

        public RecipeService(ApplicationDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Recipe> GetAllRecipes()
        {
            return _context.Recipes.ToList();
        }

        public Recipe GetRecipe(int id) {
            var recipe = _context.Recipes.Find(id);
            return recipe;
        }

        public void AddRecipe(Recipe recipe)
        {
            _context.Recipes.Add(recipe);
            _context.SaveChanges();
        }

        public void UpdateRecipe(Recipe updatedRecipe)
        {
            Recipe recipe = GetRecipe(updatedRecipe.Id);
            if (recipe != null)
            {
                recipe.Name = updatedRecipe.Name;
                recipe.Description = updatedRecipe.Description;
            }
            _context.Recipes.Update(recipe);
            _context.SaveChanges();
        }

        public void DeleteRecipe(int id)
        {
            Recipe recipe = GetRecipe(id);
            _context.Recipes.Remove(recipe);
            _context.SaveChanges();
        }
    }
}
