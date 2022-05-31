<template>
  <v-container>
    <v-row justify="center" class="ma-3">
      <v-card class="pa-4" max-width="85%">
        <h2>Thank you for playing our 'Definitely Not Wordle' game!</h2>
        <br />
        <h5>
          Click the play button to start a new game of !Wordle. If you haven't
          created a username, you can click the 'Guest' button to save your
          results under a desired username (it will display your username if
          you're logged in). You can also choose between playing practice mode,
          playing the 'word of the day', or playing previous 'words of the day'.
          <br />
          When you're ready to play, select try to guess the 5 letter word by
          clicking on the keyboard buttons and then clicking the guess button.
          You can check the 'candidate display' button at the bottom of the
          screen if you get stuck, and a '?' will count as a wildcard. This may
          give away the answer, so be sure you don't want to guess one more time
          before checking for a hint.
          <br />
          Once you've completed a game, you can check the leaderboards in the
          menu on the upper right hand to see if you've made it onto the
          leaderboard! Daily and practice games are categorized separately.
          <br />
          For questions, please contact sasplin@ewu.edu or trose8@ewu.edu.
          Thanks so much for playing our version of !wordle.
        </h5>
      </v-card></v-row
    >
  </v-container>
</template>

<script lang="ts">
import Vue from 'vue'

export default class instructions extends Vue {}
</script>
