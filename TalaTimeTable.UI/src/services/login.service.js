import axios from 'axios'

const loginService = {
  login (credentials) {
    var url = `${window.location.protocol}//${window.location.host}/static/login.json`
    return new Promise((resolve, reject) => {
      axios.get(url)
      .then(response => {
        resolve(response.data)
      }).catch(response => {
        reject(response.data)
      })
    })
  }
}

export default loginService
