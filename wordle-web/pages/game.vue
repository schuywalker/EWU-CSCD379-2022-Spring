<template>
  <v-container fluid fill-height>
    <v-container v-if="isLoaded">
      <v-row justify="center">
        <v-col cols="5">
          <v-menu>
            <template #activator="{ on, attrs }">
              <v-btn small color="primary" v-bind="attrs" v-on="on"
              >select date
              </v-btn
              >
            </template>
            <v-date-picker
              v-model="picker"
              elevation="15"
              show-current="2022-05-20"
              @change="pickDate()"
            ></v-date-picker>
          </v-menu>
          <div>{{ picker }}</div>
        </v-col>

        <v-col cols="2" class="mt-0 mb-0 pt-0 pb-0">
          <v-tooltip bottom>
            <template #activator="{ on, attrs }">
              <v-container>
                <v-row justify="center">
                  <v-btn
                    color="primary"
                    x-small
                    nuxt
                    to="/"
                    fab
                    v-bind="attrs"
                    v-on="on"
                  >
                    <v-icon>mdi-home</v-icon>
                  </v-btn>
                </v-row>
              </v-container>
            </template>
            <span> Go Home </span>
          </v-tooltip>
        </v-col>
        <v-col cols="5" class="d-flex flex-row-reverse">
          <v-dialog v-model="dialog" justify-end persistent max-width="600px">
            <template #activator="{ on, attrs }">
              <v-btn small color="primary" dark v-bind="attrs" v-on="on">
                {{ playerName }}
              </v-btn>
            </template>
            <v-card>
              <v-card-text>
                <v-text-field
                  v-model="playerName"
                  type="text"
                  placeholder="Guest"
                ></v-text-field>
              </v-card-text>
              <v-card-actions>
                <v-spacer></v-spacer>
                <v-btn color="blue darken-1" text @click="dialog = false">
                  Close
                </v-btn>
                <v-btn
                  color="blue darken-1"
                  text
                  @click=";(dialog = false), setUserName(playerName)"
                >
                  Save
                </v-btn>
              </v-card-actions>
            </v-card>
          </v-dialog>
        </v-col>
      </v-row>
      <v-row>
        <v-col cols="3"></v-col>
        <v-col cols="6" class="mt-0 mb-0 pt-0 pb-0">
          <NotWordleLogo/>
        </v-col>
        <v-col cols="3">
          <v-card-text align="right">
            <v-icon color="blue">mdi-timer</v-icon>
            {{ displayTimer() }}
          </v-card-text>
        </v-col>
      </v-row>

      <v-row v-if="wordleGame.gameOver" justify="center" class="mt-10">
        <v-alert
          v-if="!usernameIsGuestAtGameEnd() && !dialog"
          width="80%"
          :type="gameResult.type"
        >
          {{ gameResult.text }}
          <v-btn class="ml-2" @click="resetGame"> Play Again?</v-btn>
        </v-alert>

        <v-alert v-else width="80%" :type="gameResult.type">
          {{ gameResult.text }}

          <v-btn class="ml-2" @click="resetGame">don't save results</v-btn>
          <v-btn class="ml-2" @click="dialog = true">save my results!</v-btn>
        </v-alert>
      </v-row>
    <v-card-text style="background-color: grey" class="text-center" >
      Welcome to Extreme Hard Mode Wordle!!!!!! (Custom Gamemode)<br/><br/>You will receive only 6 attempts to solve this puzzle. The game board will ignore your key presses and only reflect changes once you press guess. If you do not guess the word, you will fail and not receive any further chances.<br/>Thanks for playing!
    </v-card-text>
      <v-row justify="center">
        <game-board :wordleGame="wordleGame"/>
      </v-row>
      <v-row justify="center">
        <keyboard :wordleGame="wordleGame"/>
      </v-row>
    </v-container>
  </v-container>
</template>

<script lang="ts">
import {Component, Vue} from 'vue-property-decorator'
import {GameState, WordleGame} from '~/scripts/wordleGame'
import KeyBoard from '@/components/keyboard.vue'
import GameBoard from '@/components/game-board.vue'
import {Word} from '~/scripts/word'
import {Stopwatch} from '~/scripts/stopwatch'
// import {route} from ''

@Component({components: {KeyBoard, GameBoard}})
export default class Game extends Vue {
  stopwatch: Stopwatch = new Stopwatch()
  // ? need this for closing button
  dialog: boolean = false
  playerName: string = ''
  timeInSeconds: number = 0
  startTime: number = 0
  endTime: number = 0
  intervalID: any
  // word: string = WordsService.getRandomWord()
  gameDate: string = ''

  isLoaded: boolean = false

  // @Prop({ required: true })

  // temp :string = this.playerName
  usernameIsGuestAtGameEnd() {
    const temp = this.playerName.toLowerCase()
    return temp === 'guest' || temp === ''
  }

  picker = new Date(Date.now() - new Date().getTimezoneOffset() * 60000)
    .toISOString()
    .substr(0, 10)

  wordleGame: WordleGame | undefined

  pickDate() {
    this.getGame()
    this.wordleGame = new WordleGame(this.word)
  }

  word: string = ''
  wasPlayed: boolean = false

  getGame() {
    this.$axios
      .post('/api/DateWord', {
        date: this.picker,
        playerGuid: Guid.newGuid(), // "00000000-0000-0000-0000-000000000000",
      })
      .then((game) => {
        console.log(game.data.word);

        this.word = game.data.word
        this.wasPlayed = game.data.WasPlayed
        this.wordleGame = new WordleGame(this.word)
      })
  }

  mounted() {
    if (!this.stopwatch.isRunning) {
      this.stopwatch.Start()
    }


    this.retrieveUserName()
    // setTimeout(() => this.startTimer(), 5000) // delay is because of ad loading
    this.getGame();

    setTimeout(() => {
      this.isLoaded = true
    }, 1000)
  }

  displayTimer(): string {
    return this.stopwatch.getFormattedTime()
  }

  resetGame() {
    this.getGame()
    this.stopwatch.Start()
  }

  get gameResult() {
    this.stopwatch.Stop()
    this.timeInSeconds = Math.floor(this.endTime - this.startTime)
    if (this.wordleGame!.state === GameState.Won) {
      if (
        this.playerName.toLocaleLowerCase() !== 'guest' &&
        this.playerName !== ''
      ) {
        this.endGameSave()
      }
      return {type: 'success', text: 'You won! :^)'}
    }
    if (this.wordleGame!.state === GameState.Lost) {
      return {
        type: 'error',
        text: `\t\tYou lost... :^( The word was ${this.word} \nWould you like to make a profile and save your results?`,
      }
    }
    return {type: '', text: ''}
  }

  getLetter(row: number, index: number) {
    const word: Word = this.wordleGame!.words[row - 1]
    if (word !== undefined) {
      return word.letters[index - 1]?.char ?? ''
    }
    return ''
  }

  retrieveUserName() {
    const userName = localStorage.getItem('userName')
    if (userName == null) {
      this.playerName = 'Guest'
    } else {
      this.playerName = userName
    }
  }

  setUserName(userName: string) {
    localStorage.setItem('userName', userName)
    if (this.wordleGame!.state === GameState.Won) {
      this.endGameSave()
    }
  }

  endGameSave() {
    this.$axios.post('/api/Players', {
      name: this.playerName,
      attempts: this.wordleGame!.words.length,
      seconds: Math.round(this.stopwatch.currentTime / 1000),
    })
  }

}

class Guid {
  static newGuid() {
    return 'xxxxxxxx-xxxx-4xxx-yxxx-xxxxxxxxxxxx'.replace(/[xy]/g, function (c) {
      const r = Math.random() * 16 | 0;
      const v = c === 'x' ? r : (r & 0x3 | 0x8);
      return v.toString(16);
    });
  }
}
</script>
