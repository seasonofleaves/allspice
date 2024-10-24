import { logger } from "@/utils/Logger.js"
import { api } from "./AxiosService.js"

class RecipesService{
  async getAllRecipes() {
    const response = await api.get('api/recipes')
    logger.log('got all recipes', response.data)
  }

}

export const recipesService = new RecipesService()