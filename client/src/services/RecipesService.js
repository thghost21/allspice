import { logger } from "@/utils/Logger.js"
import { api } from "./AxiosService.js"
import { Recipe } from "@/models/Recipe.js"
import { AppState } from "@/AppState.js"

class RecipesService {
  async createRecipe(recipeData) {
    const response = await api.post('api/recipes', recipeData)
    logger.log("created recipe", response.data)
    const recipe = new Recipe(response.data)
    AppState.activeRecipe = recipe
    AppState.recipes.push(recipe)
    return recipe
  }
  getRecipeById() {
    throw new Error('Method not implemented.')
  }
  async getAllRecipes() {
    const response = await api.get('api/recipes')
    logger.log('getting recipes', response.data)
    const recipes = response.data.map(pojo => new Recipe(pojo))
    AppState.recipes = recipes
  }

}

export const recipeService = new RecipesService()