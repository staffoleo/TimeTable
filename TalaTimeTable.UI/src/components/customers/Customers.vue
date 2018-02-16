<template>
  <div>
    <div class="row">
      <div class="col-xs-12 col-md-12">
        <widget :headerText="$t('customers.title')">
          <div class="d-flex flex-md-row flex-column justify-content-md-between align-items-center">
            <div class="form-group with-icon-left">
              <div class="input-group">
                <input id="input-icon-left" required="required" v-model="searchText" v-on:keyup.enter="loadCustomers">
                <i class="glyphicon glyphicon-search icon-left input-icon search-icon"></i>
                <label for="input-icon-left" class="control-label">Search</label>
                <i class="bar"></i>
              </div>
            </div>
            <div class="form-group">
              <button class="btn btn-primary btn-micro" v-on:click="create">
                <i class="fa fa-plus"></i>
              </button>
            </div>
          </div>
          <div class="table-responsive">
            <table class="table table-striped first-td-padding">
              <thead>
                <tr>
                  <td>{{'customers.businessName' | translate}}</td>
                  <td>{{'customers.address' | translate}}</td>
                  <td>{{'customers.email' | translate}}</td>
                  <td>{{'customers.phoneNumber' | translate}}</td>
                  <td align="right"></td>
                  <td></td>
                </tr>
              </thead>
              <tbody>
                <tr v-for="customer in customers" :key="customer.id">
                  <td>{{customer.businessName}}</td>
                  <td>{{customer.address}}</td>
                  <td>{{customer.email}}</td>
                  <td>{{customer.phoneNumber}}</td>
                  <td align="right">
                    <button class="btn btn-primary btn-micro" v-on:click="edit(customer)"><i class="fa fa-pencil"></i></button>
                    <button class="btn btn-primary btn-micro" v-on:click="trash(customer)"><i class="fa fa-trash"></i></button>
                  </td>
                  <td></td>
                </tr>
              </tbody>
            </table>
          </div>
        </widget>
      </div>
    </div>
    <!-- <single-customer v-if="selectedCustomer"></single-customer> -->
    <router-view></router-view>
  </div>
</template>
<script>
  import Widget from '../vuestic-components/vuestic-widget/VuesticWidget'
  import customerService from './customer.service.js'
  // import SingleCustomer from './Customer.vue'

  export default {
    components: {
      Widget
      // SingleCustomer
    },
    name: 'Customers',
    data () {
      return {
        searchText: '',
        customers: [],
        selectedCustomer: null
      }
    },
    created () {
      this.loadCustomers()
    },
    methods: {
      create () {
        console.log('Created')
      },
      loadCustomers () {
        var self = this
        customerService.getCustomers(self.searchText).then(data => {
          self.customers = data
        })
      },
      edit (customer) {
        console.log(this.$router.options.routes)
        this.$router.push('Customer')
        this.selectedCustomer = customer
      },
      trash (customer) {
        this.customers.splice(this.customers.indexOf(customer), 1)
        customerService.deleteCustomer(customer.id)
      }
    }
  }
</script>

