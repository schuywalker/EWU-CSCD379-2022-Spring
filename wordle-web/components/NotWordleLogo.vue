<template class="ma-0 pa-0">
  <v-img class="notwordle-logo ma-0 pa-0" src="logo.jpeg" />
</template>

<style>
.notwordle-logo {
  transform: rotateY(720deg);
  animation: turn 2.5s ease-out forwards 0.5s;
}

@keyframes turn {
  100% {
    transform: rotateY(0deg);
  }
}
</style>
