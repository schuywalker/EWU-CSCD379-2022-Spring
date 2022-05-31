<template>
  <v-card class="ma-5 py-1" max-width="600px" flat>
    <v-container>
      <v-card-title>Day stats for {{ date }}</v-card-title>
      Hello World
      <v-card-text>
        <v-row>
          <v-col> Plays </v-col>
          <v-col> Avg. Attempts </v-col>
          <v-col> Avg. Time </v-col>
        </v-row>
        <v-row>
          <v-col>
            {{ dateStats.dayPlays }}
          </v-col>
          <v-col>
            {{ dateStats.dayAttempts }}
          </v-col>
          <v-col>
            {{ dateStats.dayTime }}
          </v-col>
        </v-row>
      </v-card-text>
    </v-container>
  </v-card>
</template>

<script lang="ts">
import { Component, Prop, Vue } from 'vue-property-decorator'

@Component({ components: {} })
export default class DayStats extends Vue {
  @Prop({ required: true })
  dateStats = null

  playerGuid: string = ''
  // playerStatsDisplay: any = {
  //   day: Date,
  //   averageGuesses: Number,
  //   averageTime: Number,
  //   winRate: Number,
  //   wonDay: Boolean,
  //   plays: Number,

  // thisDaysGameWon() {
  // if (this.practiceMode === false && this.wasPlayed === true) {

  mounted() {
    const playerGUID = localStorage.getItem('playerGUID')
    if (playerGUID == null) {
      this.playerGuid = Guid.newGuid()
      localStorage.setItem('playerGUID', this.playerGuid)
    } else {
      this.playerGuid = playerGUID
    }
    this.$axios
      .post('/api/RecentStats', {
        playerGuid: this.playerGuid,
      })
      .then((response) => {
        this.dateStats = response.data
      })
  }
}
class Guid {
  static newGuid() {
    return 'xxxxxxxx-xxxx-4xxx-yxxx-xxxxxxxxxxxx'.replace(
      /[xy]/g,
      function (c) {
        const r = (Math.random() * 16) | 0
        const v = c === 'x' ? r : (r & 0x3) | 0x8
        return v.toString(16)
      }
    )
  }
}
</script>
