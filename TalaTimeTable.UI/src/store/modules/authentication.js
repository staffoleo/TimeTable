import loginService from '../../services/login.service.js'

var checkAuth = window.localStorage.getItem('token') !== null

const moduleAutentication = {
  state: { isAuthenticated: checkAuth },
  getters: {
    isAuthenticated: (state) => {
      return state.isAuthenticated
    }
  },
  actions: {
    logout (context) {
      return new Promise((resolve) => {
        context.commit('logout')
        resolve()
      })
    },
    login (context, credentials) {
      return new Promise((resolve) => {
        loginService.login(credentials)
          .then((data) => {
            context.commit('login', data)
            resolve()
          })
          .catch((data) => console.log('Could not login'))
      })
    }
  },
  mutations: {
    logout (state) {
      if (typeof window !== 'undefined') {
        window.localStorage.removeItem('token')
      }
      state.isAuthenticated = false
    },
    login (state, token) {
      if (typeof window !== 'undefined') {
        window.localStorage.setItem('token', token.token)
      }
      state.isAuthenticated = true
    }
  }
}

export default moduleAutentication
