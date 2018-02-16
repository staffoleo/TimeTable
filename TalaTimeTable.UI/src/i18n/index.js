import Vue from 'vue'

// add translations directly to the application
Vue.i18n.add('en', require('./en.json'))
Vue.i18n.add('it', require('./it.json'))

// set the start locale to use
Vue.i18n.set('en')

// set fallback for non-translated strings
Vue.i18n.fallback('en')
