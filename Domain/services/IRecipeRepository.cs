﻿using Domain;

namespace Domain.Services
{
    public interface IRecipeRepository
    {
        List<Recipe> GetRecipes();
        Recipe GetRecipe( int id );
        int CreateRecipe( Recipe recipe );
        void DeleteRecipe( int id );
        int UpdateRecipe( Recipe recipe );

        // описывает методы для работы с domain(хранилище рецептов)
    }
}