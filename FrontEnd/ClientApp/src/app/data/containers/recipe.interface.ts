import { Ingredient } from "./ingedient.interface"
import { Step } from "./step.interface"

export interface Recipe
{
    recipeId?: number,
    authorId?: number,
    name?: string,
    description?: string,
    tagsList?: string,  
    timeForCook?: number,
    numberOfServings?: number,
    ingredients: Ingredient[],
    steps: Step[],
    imageUrl?: string,
}