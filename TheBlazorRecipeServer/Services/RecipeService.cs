using BlazorRecipeServer.Data;
using BlazorRecipeServer.Models;
using Microsoft.EntityFrameworkCore;
using BlazorRecipeServer.Services;

namespace BlazorRecipeServer.Services
{
    public class RecipeService : IRecipeService
    {
        private readonly ApplicationDbContext _context;

        public RecipeService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<Recipe>> GetAllRecipes()
        {
            var recipes = await _context.Recipes.ToListAsync();
            return recipes;
        }

        public async Task<Recipe> GetRecipe(int id) {
            Recipe? recipe = await _context.Recipes.FindAsync(id);
            return recipe!;
        }

        public async Task AddRecipe(Recipe recipe)
        {
            await _context.Recipes.AddAsync(recipe);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateRecipe(Recipe updatedRecipe)
        {
            Recipe? recipe = await GetRecipe(updatedRecipe.Id);
            if (recipe != null)
            {
                recipe.Name = updatedRecipe.Name;
                recipe.Description = updatedRecipe.Description;
            }
            _context.Recipes.Update(recipe);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteRecipe(int id)
        {
            Recipe? recipe = await GetRecipe(id);
            _context.Recipes.Remove(recipe);
            await _context.SaveChangesAsync();
        }
    }
}
