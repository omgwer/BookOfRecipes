export interface Ingredient
{
    title: string,
    description: string
}

export interface Step
{
    title: string,
    description: string
}

export interface Recipe
{
    authorId?: number,
    recipeId?: number,
    recipeName?: string,
    recipeDescription?: string,
    tagsList?: string[],
    timeForCook?: number,
    numberOfServings?: number,
    ingredients?: Ingredient[],
    steps?: Step[],
    imageUrl?: string
}
