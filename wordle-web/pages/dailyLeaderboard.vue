<template>
  <v-container fluid fill-height>
    <v-container v-if="!showStats" :key="showStats">
      <v-row justify="center">
        <v-card loading>
          <v-card-title class="justify-center">
            You're being exploited for ad revenue, please standby...
          </v-card-title>
          <PrerollAd />
        </v-card>
      </v-row>
    </v-container>
    <v-container v-else fill-height justify-center>
      <v-card class="pa-6">
        <v-card-title class="display-3 justify-center">
          Leader Board
        </v-card-title>
        <v-row>
          <v-col> Plays</v-col>
          <v-col> Avg. Attempts</v-col>
          <v-col> Avg. Time</v-col>
          <v-col> Win Rate</v-col>
        </v-row>
        <v-container>
          <v-row v-for="(dayStats, index) in recentStats" :key="index">
            <v-card>
              <day-stats :dateStats="dayStats"></day-stats>
            </v-card>
          </v-row>
        </v-container>
      </v-card>
    </v-container>
  </v-container>
</template>

<script lang="ts">
import { Component, Vue } from 'vue-property-decorator'

@Component({})
export default class PrevDayStats extends Vue {
  recentStats: any | null = null

  playerGuid: string = ''
  showStats: boolean = false

  mounted() {
    const playerGUID = localStorage.getItem('playerGUID')
    if (playerGUID == null) {
      this.playerGuid = Guid.newGuid()
      localStorage.setItem('playerGUID', this.playerGuid)
    } else {
      this.playerGuid = playerGUID
    }
    console.log(this.playerGuid)
    this.$axios
      .post('/api/RecentStats', {
        guid: this.playerGuid,
      })
      .then((response) => {
        this.recentStats = response.data
        this.showStats = true
        // return response.data
      })
      .catch((error) => console.log(error))
    // this.getData();
  }

  async getData() {
    // await
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
