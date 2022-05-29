export interface Ingredient
{
    id?: number,
    title?: string,
    description?: string
}

export interface Step
{
    order: number, // шаг приготовления рецетпа
    title: string,
    description: string
}

export interface Recipe
{
    authorId?: number,
    recipeId?: number,
    recipeName?: string,
    recipeDescription?: string,
    tagsList?: string[],  //вынести в обьект
    timeForCook?: number,
    numberOfServings?: number,
    ingredients: Ingredient[],
    steps?: Step[],
    imageUrl?: string
}
