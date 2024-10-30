using Microsoft.AspNetCore.Components;
using BlazorRecipeServer.Models;
using BlazorRecipeServer.Services;

namespace BlazorRecipeServer
{
    public class MyRecipeDetails : ComponentBase
    {
        [Parameter]
        public int id { get; set; }

        public Recipe recipe { get; set; }

        [Inject]
        public IRecipeService _service { get; init; }

        protected override async Task OnInitializedAsync()
        {
            recipe = await _service.GetRecipe(id);
        }
    }
}