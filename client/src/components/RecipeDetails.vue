<script setup>
import { Recipe } from '@/models/Recipe.js';

defineProps({
  activeRecipe: {type: Recipe, required: true}
})

</script>

<template>
  <div class="container">
    <section class="row">
      <div class="col-6 p-0">
        <div class="img-style">
          <img class="" :src="activeRecipe.imgUrl" :alt="activeRecipe.title">
        </div>
      </div>
      <div class="col-6 p-3">
        <h4>{{ activeRecipe.title }}</h4>
        <p>by: {{ activeRecipe.creator.name }}</p>
        <p class="btn btn-primary">{{ activeRecipe.category }}</p>
        <h5>Ingredients</h5>
        
        <h5>Instructions</h5>
        <p>{{ activeRecipe.instructions }}</p>
      </div>
    </section>
  </div>
</template>


<style lang="scss" scoped>

img{
  width: 100%;
  height: 70vh;
  object-fit: cover;
  object-position: center;
}
</style>