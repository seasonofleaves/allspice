<script setup>
import { AppState } from '@/AppState.js';
import RecipeCard from '@/components/RecipeCard.vue';
import { recipesService } from '@/services/RecipesService.js';
import { logger } from '@/utils/Logger.js';
import Pop from '@/utils/Pop.js';
import { computed, onMounted } from 'vue';

const recipes = computed(() => AppState.recipes)

onMounted(() =>{
  getAllRecipes()
})

async function getAllRecipes(){
  try {
    await recipesService.getAllRecipes()
  }
  catch (error){
    Pop.error(error)
    logger.log(error)
  }
}

</script>

<template>
  <div class="hero">
    <div class="container h-100">
      <section class="h-100 d-flex align-items-center justify-content-center">
        <div class="text-center">
          <h1>All-Spice</h1>
          <span>Cherish Your Family</span>
          <p>And Their Cooking</p>
        </div>
      </section>
    </div>
  </div>
    <div class="container-fluid">
      <section class="row m-2">
        <div v-for="recipe in recipes" :key="recipe.id" class="p-0 col-12 col-sm-6 col-md-4 col-md-3">
          <RecipeCard :recipe/>
        </div>
      </section>
    </div>
</template>

<style scoped lang="scss">
.hero{
  background-image: url(https://images.unsplash.com/photo-1452251889946-8ff5ea7b27ab?q=80&w=1999&auto=format&fit=crop&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D);
  height: 50dvh;
  background-size: cover;
  background-position: center;
  color: white;
  border-radius: 10px;
  margin: 15px;
  margin-bottom: 30px;
  box-shadow: 0 1px 10px rgb(67, 67, 67);
}

.cards-container{
  margin-right: 5px;
  margin-left: 5px;
}

</style>
