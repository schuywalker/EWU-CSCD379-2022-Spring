<template>
  <v-container fluid fill-height justify-center>
    <v-card>
      <v-card-title class="display-3 text-center text-break">
        Leader Board
      </v-card-title>
      <v-card-text class="text-center">
        {{ title }}
      </v-card-text>
      <v-card-text>
        <v-row>
          <v-col cols="3" md="2" sm="2">Name</v-col>
          <v-col cols="3" style="text-align: center"># Games</v-col>
          <v-col cols="3" style="text-align: center">Avg. Attempts</v-col>
          <v-col cols="3" style="text-align: center">Avg. Seconds</v-col>
        </v-row>
        <v-row v-for="(player, playerId) in players" :key="playerId">
          <v-col cols="3" md="2" sm="2">{{ player.name }}</v-col>
          <v-col cols="3" style="text-align: center">{{
            player.gameCount
          }}</v-col>
          <v-col cols="3" style="text-align: center">{{
            player.averageAttempts.toFixed(2)
          }}</v-col>
          <v-col cols="3" style="text-align: center">{{
            player.averageSecondsPerGame
          }}</v-col>
        </v-row>
      </v-card-text>

      <v-card-actions>
        <v-btn class="ma-1" color="primary" @click="getAllPlayers">
          Get All Players
        </v-btn>
        <v-spacer />
        <!--        <v-btn color="primary" @click="getTop10Players">-->
        <!--          Get Top 10 Players-->
        <!--        </v-btn>-->
        <v-btn class="ma-1" color="primary" nuxt to="/dailyLeaderboard">
          Go To Daily Leaderboard
        </v-btn>
      </v-card-actions>
    </v-card>
  </v-container>
</template>

<script lang="ts">
import { Component, Vue } from 'vue-property-decorator'

@Component({})
export default class leaderboard extends Vue {
  players: any = []
  title: string = ''

  created() {
    this.getAllPlayers()
  }

  getAllPlayers() {
    this.title = 'All Players'
    this.$axios.get('/api/Players').then((response) => {
      this.players = response.data
    })
  }

  //
  // getTop10Players() {
  //   this.title = 'Top 10 Players'
  //   this.$axios.get('/api/Players/GetTop10').then((response) => {
  //     this.players = response.data
  //   })
  // }
}
</script>
