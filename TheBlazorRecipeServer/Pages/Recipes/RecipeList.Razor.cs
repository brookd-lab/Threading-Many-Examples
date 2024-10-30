using Microsoft.AspNetCore.Components;
using BlazorRecipeServer.Models;
using BlazorRecipeServer.Services;

namespace BlazorRecipeServer
{
    public class MyRecipeList : ComponentBase
    {
        public List<Recipe> recipes = new();

        [Inject]
        public IRecipeService _service { get; init; }


        protected override async Task OnInitializedAsync()
        {
            recipes = await _service.GetAllRecipes();
        }
    }
}