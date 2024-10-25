<script setup>
import { Recipe } from '@/models/Recipe.js';

defineProps({
  activeRecipe: {type: Recipe, required: true}
})

</script>

<template>
  <div class="container">
    <section class="row">
      <div class="col-6">
        <img class="img-fluid" :src="activeRecipe.imgUrl" :alt="activeRecipe.title">
      </div>
      <div class="col-6">
        <h1>{{ activeRecipe.title }}</h1>
      </div>
    </section>
  </div>
</template>


<style lang="scss" scoped>

</style>