<template>
  <v-container>
    <v-row justify="center" class="pa-2">
      <!-- Back Button -->
      <v-btn
        class="mt-2"
        fab
        v-bind="attrs"
        color="primary"
        v-on="on"
        @click="$router.go(-1)"
      >
        <v-icon>mdi-arrow-left</v-icon>
      </v-btn>

      <!-- Game Info Card(s) -->
      <v-col cols="12">
        <v-card flat color="transparent">
          <v-card-title class="justify-center">
            <h2>!Wordle</h2>
          </v-card-title>
        </v-card>
      </v-col>

      <!-- Game Card -->

      <v-col cols="11">
        <!-- regular -->
        <v-card v-if="!isMobile()" class="pa-2 pt-3">
          <v-row justify="center" class="pa-2">
            <v-icon size="80px" justify="center" class="ma-0"
              >mdi-file-word-box</v-icon
            >
          </v-row>

          <v-card-text decoration class="ma-0">
            Not Wordle (stylized as <em>!Wordle</em>), is a web development
            course-based game <em>heavily</em> inspired by
            <em
              ><a href="https://en.wikipedia.org/wiki/Josh_Wardle"
                >Josh Wardle</a
              >'s</em
            >
            viral creation
            <a href="https://www.nytimes.com/games/wordle/index.html">Wordle</a
            >.
            <v-spacer />
            Clearly, this is not the same game, but rather a unique spin on the
            new classic written by students at
            <a href="https://www.ewu.edu">Eastern Washington University</a>
            learning .NET web application development.
          </v-card-text>
        </v-card>

        <!-- mobile -->
        <v-card v-else>
          <v-row justify="center" class="pa-2">
            <v-icon size="80px" class="ma-0">mdi-file-word-box</v-icon>

            <v-card-text decoration>
              Not Wordle (stylized as <em>!Wordle</em>), is a web development
              course-based game <em>heavily</em> inspired by
              <em
                ><a href="https://en.wikipedia.org/wiki/Josh_Wardle"
                  >Josh Wardle</a
                >'s</em
              >
              viral creation
              <a href="https://www.nytimes.com/games/wordle/index.html"
                >Wordle</a
              >.
              <v-spacer />
              Clearly, this is not the same game, but rather a unique spin on
              the new classic written by students at
              <a href="https://www.ewu.edu">Eastern Washington University</a>
              learning .NET web application development.
            </v-card-text>
          </v-row>
        </v-card>
      </v-col>

      <!-- Instructor Cards -->
      <v-col cols="12">
        <v-card flat color="transparent">
          <v-card-title class="justify-center">
            <h1>Instructors</h1>
          </v-card-title>
        </v-card>
      </v-col>

      <!-- Meg -->
      <v-col cols="11" class="mx-2">
        <v-card class="flex pa-2 ma-0">
          <v-card-title class="justify-left pt-0">
            Meghan Woodford
          </v-card-title>
          <div class="d-flex">
            <v-avatar size="150" class="ma-2">
              <v-img src="/meg.png" />
            </v-avatar>

            <v-card flat>
              <v-card-text>
                Meghan is very great... just ask her!
                <v-spacer />
                <small
                  ><em>
                    "Create an About page that has a few sentences about this
                    class project <br />
                    and <strong>how great Meg is</strong> ✅"
                  </em>
                  — Meg</small
                >
              </v-card-text>
              <v-card-actions>
                <v-btn color="primary" href="https://github.com/mmwoodfo">
                  GitHub
                </v-btn>
              </v-card-actions>
            </v-card>
          </div>
        </v-card>
      </v-col>

      <!-- Grant -->
      <v-col cols="11" class="mb-2">
        <v-card class="flex pa-2 ma-0">
          <v-card-title class="justify-left pt-0">
            Grant Erickson
          </v-card-title>
          <div class="d-flex">
            <v-avatar size="150" class="ma-2">
              <v-img src="grant.jpg" />
            </v-avatar>

            <v-card flat>
              <v-card-text>
                Meghan is very great... just ask Grant!
                <v-spacer />
                <small
                  ><em> "It's not necessarily defined as falsy." </em> — Grant
                </small>
              </v-card-text>
              <v-card-actions>
                <v-btn color="primary" href="https://github.com/GrantErickson">
                  GitHub
                </v-btn>
              </v-card-actions>
            </v-card>
          </div>
        </v-card>
      </v-col>
    </v-row>
  </v-container>
</template>

<script>
import Vue from 'vue'
import Component from 'vue-class-component'

@Component
export default class AboutPage extends Vue {
  isMobile() {
    return this.$vuetify.breakpoint.xs
  }
}
</script>
