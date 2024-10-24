<script setup>
import { Recipe } from '@/models/Recipe.js';


defineProps({
  recipe: {type: Recipe, required: true}
})

</script>


<template>
  <div class="card bg-card shadow my-4 justify-content-end" :style="{backgroundImage: 'url('+recipe.imgUrl+')'}">
    <div class="container-fluid ">
      <section class="row d-flex">
        <div class="col-12 text-center">
          <div class="card title-card mb-2">
            <p class="m-0">
              {{ recipe.title }}
            </p>
          </div>
        </div>
      </section>
    </div>
  </div>
</template>


<style lang="scss" scoped>
img{
  width: 100%;
  height: 100%;
  object-fit: cover;
  object-position: center;
}

.bg-card{
  aspect-ratio: 1/1;
  background-size: cover;
  background-position: center;
  border: none;
}

.title-card{
  background-color: rgba(79, 79, 79, 0.542);
  color: white;
  border: none;
  padding: 10px;
  font-weight: bold;
  backdrop-filter: blur(10px);
}
</style>