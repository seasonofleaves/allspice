<script setup>
import { recipesService } from '@/services/RecipesService.js';
import { logger } from '@/utils/Logger.js';
import Pop from '@/utils/Pop.js';
import { onMounted } from 'vue';

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
<div class="container-fluid">
  <section class="row hero">
    <div class="col-12 ">
      <h1>Allspice</h1>
    </div>
  </section>
</div>
</template>

<style scoped lang="scss">
.hero{
  background-image: url(https://images.unsplash.com/photo-1452251889946-8ff5ea7b27ab?q=80&w=1999&auto=format&fit=crop&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D);
  min-height: 50dvh;
  background-size: cover;
  background-position: center;
  color: white;
}
</style>
