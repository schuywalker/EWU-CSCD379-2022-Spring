<template>
  <v-row>
      <v-card-title>Day stats for: {{ new Date(dateStats.day).toDateString() }}</v-card-title>
      <v-card-text>
        <v-row>
          <v-col> Plays</v-col>
          <v-col> Avg. Attempts</v-col>
          <v-col> Avg. Time</v-col>
          <v-col> Win Rate</v-col>
        </v-row>
        <v-row>
          <v-col>
            {{ dateStats.plays }}
          </v-col>
          <v-col>
            {{ dateStats.averageGuesses }}
          </v-col>
          <v-col>
            {{ dateStats.averageTime }}
          </v-col>
          <v-col>
            {{ dateStats.winRate }}
          </v-col>
        </v-row>
      </v-card-text>
  </v-row>
</template>

<script lang="ts">
import {Component, Prop, Vue} from 'vue-property-decorator'

@Component({components: {}})
export default class DayStats extends Vue {
  @Prop({required: true})
  dateStats!: undefined

  mounted(){
    console.log(this.dateStats)
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
