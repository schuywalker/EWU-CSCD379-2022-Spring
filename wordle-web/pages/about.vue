<template>
  <v-container class="pa-0">
    <v-row justify="center" no-gutters>
      <!-- Back Button -->
      <v-col>
        <v-btn
          fab
          v-bind="attrs"
          color="primary"
          v-on="on"
          @click="$router.go(-1)"
        >
          <v-icon>mdi-arrow-left</v-icon>
        </v-btn>
      </v-col>

      <!-- Game Info Card(s) -->
      <v-col cols="12">
        <v-card flat color="transparent">
          <v-card-title class="justify-center">
            <h2>!Wordle</h2>
          </v-card-title>
        </v-card>
      </v-col>

      <!-- Game Card -->
      <v-container class="ma-0 pa-0">
        <v-col cols="10">
          <!-- regular -->
          <v-card v-if="!isMobile()">
            <div class="d-flex align-center">
              <v-icon size="150" class="ma-6">mdi-file-word-box</v-icon>
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
                <v-spacer/>
                Clearly, this is not the same game, but rather a unique spin on
                the new classic written by students at
                <a href="https://www.ewu.edu">Eastern Washington University</a>
                learning .NET web application development.
              </v-card-text>
            </div>
          </v-card>
          <!-- mobile -->
          <v-card v-else>
            <div class="d-flex align-center">
              <v-row justify="center">
                <v-col cols="8">
                  <v-icon size="150px" class="ma-6">mdi-file-word-box</v-icon>
                </v-col>
                <v-col>
                  <v-card-text decoration>
                    Not Wordle (stylized as <em>!Wordle</em>), is a web
                    development course-based game <em>heavily</em> inspired by
                    <em
                    ><a href="https://en.wikipedia.org/wiki/Josh_Wardle"
                    >Josh Wardle</a
                    >'s</em
                    >
                    viral creation
                    <a href="https://www.nytimes.com/games/wordle/index.html"
                    >Wordle</a
                    >.
                    <v-spacer/>
                    Clearly, this is not the same game, but rather a unique spin
                    on the new classic written by students at
                    <a href="https://www.ewu.edu"
                    >Eastern Washington University</a
                    >
                    learning .NET web application development.
                  </v-card-text>
                </v-col>
              </v-row>
            </div>
          </v-card>
        </v-col>
      </v-container>
      <!-- Instructor Cards -->
      <v-col cols="12">
        <v-card flat color="transparent">
          <v-card-title class="justify-center">
            <h1>Instructors</h1>
          </v-card-title>
        </v-card>
      </v-col>

      <!-- Meg -->
      <v-col cols="11" class="">
        <v-card class="flex pa-0 ma-0">
          <v-card-title class="justify-left">
            Meghan Woodford
          </v-card-title>
          <div class="d-flex">
            <v-avatar size="150" class="ma-6">
              <v-img src="/meg.png"/>
            </v-avatar>
            <v-container fluid>
              <v-card flat>
                <v-card-text>
                  Meghan is very great... just ask her!
                  <v-spacer/>
                  <small
                  ><em>
                    "Create an About page that has a few sentences about this
                    class project <br/>
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
            </v-container>
          </div>
        </v-card>
      </v-col>

      <!-- Grant -->
      <v-col cols="11" class=" pt-1 mt-1">
        <v-card>
          <v-card-title class="justify-left">
            Grant Erickson
          </v-card-title>
          <div class="d-flex">
            <v-avatar size="150" class="ma-6">
              <v-img src="grant.jpg"/>
            </v-avatar>
            <v-container fluid>
              <v-card flat>
                <v-card-text>
                  Meghan is very great... just ask Grant!
                  <v-spacer/>
                  <small
                  ><em> "It's not necessarily defined as falsy." </em> — Grant
                  </small>
                </v-card-text>
                <v-card-actions>
                  <v-btn
                    color="primary"
                    href="https://github.com/GrantErickson"
                  >
                    GitHub
                  </v-btn>
                </v-card-actions>
              </v-card>
            </v-container>
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

  // credit to @dcox2005 for this awesome reactive breakpoint solution
  screenSizes() {
    const sizes = {
      'x-small': false,
      small: false,
      large: false,
      'x-large': false,
    }
    switch (this.$vuetify.breakpoint.name) {
      case 'xs':
        sizes['x-small'] = true
        break
      case 'sm':
        sizes.small = true
        break
      case 'lg':
        sizes.large = true
        break
      case 'xl':
        sizes['x-large'] = true
        break
      default:
    }
  }
}
</script>
