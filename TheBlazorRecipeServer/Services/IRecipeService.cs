using BlazorRecipeServer.Models;
using Microsoft.EntityFrameworkCore;

namespace BlazorRecipeServer.Services
{
    public interface IRecipeService
    {
        public Task<List<Recipe>> GetAllRecipes();
        public Task<Recipe> GetRecipe(int id);
        public Task AddRecipe(Recipe recipe);
        public Task UpdateRecipe(Recipe updatedRecipe);
        public Task DeleteRecipe(int id);
    }
}
