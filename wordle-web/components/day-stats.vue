<template>
  <v-row class="mt-3">
    <v-card-title
      >Day stats for: {{ new Date(dateStats.day).toDateString() }}</v-card-title
    >
    <v-card-text>
      <v-row>
        <v-col cols="3">
          {{ dateStats.plays }}
        </v-col>
        <v-col cols="3">
          {{ dateStats.averageGuesses }}
        </v-col>
        <v-col cols="3">
          {{ formattedTime }}
        </v-col>
        <v-col cols="3">
          {{ dateStats.winRate }}
        </v-col>
      </v-row>
    </v-card-text>
  </v-row>
</template>

<script lang="ts">
import { Component, Prop, Vue } from 'vue-property-decorator'

@Component({ components: {} })
export default class DayStats extends Vue {
  @Prop({ required: true })
  dateStats: any

  mounted() {
    console.log(this.dateStats)
  }

  get formattedTime() {
    // Fun time formatting things
    return (
      (this.dateStats.averageTime / 60 / 60 > 1
        ? Math.floor(this.dateStats.averageTime / 60 / 60) + ':'
        : '') + // Hours or nothing
      (Math.floor(this.dateStats.averageTime / 60) % 60) + // Minutes
      ':' + // minute divider
      (Math.floor(this.dateStats.averageTime % 60) < 10
        ? '0' + Math.floor(this.dateStats.averageTime % 60)
        : Math.floor(this.dateStats.averageTime % 60))
    ) // Seconds
  }

  // playerStatsDisplay: any = {
  //   day: Date,
  //   averageGuesses: Number,
  //   averageTime: Number,
  //   winRate: Number,
  //   wonDay: Boolean,
  //   plays: Number,

  // thisDaysGameWon() {
  // if (this.practiceMode === false && this.wasPlayed === true) {
}
</script>
