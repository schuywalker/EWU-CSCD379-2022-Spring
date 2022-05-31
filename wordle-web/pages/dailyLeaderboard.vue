<template>
  <v-container fluid fill-height justify-center>
    <v-card>
      <v-card-title class="display-3 justify-center">
        Leader Board
      </v-card-title>
      <v-container v-for="dayStats in recentStats" :key="dayStats">
        <day-stats :dateStats="dayStats"></day-stats>
      </v-container>
    </v-card>
  </v-container>
</template>

<script lang="ts">
import {Component, Vue} from 'vue-property-decorator'

@Component({})
export default class PrevDayStats extends Vue {
  recentStats :any = []

  playerGuid: string = ''
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
        this.recentStats = response.data
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


