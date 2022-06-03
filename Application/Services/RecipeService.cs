using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Dto;
using Infrastructure.Repositories;

namespace Application.Services
{
    internal class RecipeService : IRecipeService
    {
        private readonly IRecipeRepository _recipeRepository;

        public RecipeService( IRecipeRepository recipeRepository )
        {
            _recipeRepository = recipeRepository;
        }

        public RecipeDto createRecipe(RecipeDto recipe) {
            return new RecipeDto();
        }

        // слой бизнес логики, если id == 0  создается новый рецепт, если id != 0 обновляется
        // тут хранить метод toDto() Для удаления из обьекто полученных в базе данных, которые не нужны на фронте
    }
}
