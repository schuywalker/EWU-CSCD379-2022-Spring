<template>
  <v-card class="ma-5 py-1" max-width="600px" flat>
    <v-container>
      <v-card-title>Day stats for {{ date }}</v-card-title>
      Hello World
      <v-card-text>
        <v-row>
          <v-col> Plays</v-col>
          <v-col> Avg. Attempts</v-col>
          <v-col> Avg. Time</v-col>
        </v-row>
        <v-row v-if="dateStats==null">
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
import {Component, Prop, Vue} from 'vue-property-decorator'

@Component({components: {}})
export default class DayStats extends Vue {
  @Prop({required: true})
  dateStats = null

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
