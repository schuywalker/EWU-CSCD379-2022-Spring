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

  created() {
  this.getRecentStats()
  }

  getRecentStats() {
    return this.$axios.get('/api/Recents').then((response) => {
      this.recentStats = response.data
    });
  }
}
</script>


