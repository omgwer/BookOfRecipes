import { Ingredient } from "./ingedient.interface"
import { Step } from "./step.interface"
import { Tag } from "./tag.interface"

export interface Recipe
{
    recipeId?: number,
    authorId?: number,
    name?: string,
    description?: string,
    tagsList: Tag[],  
    timeForCook?: number,
    numberOfServings?: number,
    ingredients: Ingredient[],
    steps: Step[],
    imageUrl?: string,
}