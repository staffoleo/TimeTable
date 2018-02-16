import axios from 'axios'

// axios.defaults.headers.common['Access-Control-Allow-Origin'] = '*'

const customerService = {
  getCustomers (search) {
    return new Promise((resolve) => {
      axios.get(`http://localhost:50605/api/customers?search=${search}`)
        .then(response => {
          resolve(response.data)
        })
        .catch(function (error) {
          console.log(error)
        })
    })
  },
  deleteCustomer (customerId) {
    return new Promise(() => {
      axios.delete(`http://localhost:50605/api/customers/${customerId}`)
        .catch(function (error) {
          console.log(error)
        })
    })
  }
}

export default customerService
