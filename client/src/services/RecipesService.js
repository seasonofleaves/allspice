import { logger } from "@/utils/Logger.js"
import { api } from "./AxiosService.js"
import { Recipe } from "@/models/Recipe.js"
import { AppState } from "@/AppState.js"

class RecipesService{
  async getAllRecipes() {
    const response = await api.get('api/recipes')
    logger.log('got all recipes', response.data)
    const recipes = response.data.map(recipeData => new Recipe(recipeData))
    AppState.recipes = recipes
  }

}

export const recipesService = new RecipesService()