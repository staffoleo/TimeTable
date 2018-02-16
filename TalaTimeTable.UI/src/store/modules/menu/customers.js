import lazyLoading from './lazyLoading'

export default {
  name: 'Customers',
  path: '/customers',
  component: lazyLoading('customers/Customers'),
  meta: {
    showInMenu: true,
    expanded: false,
    title: 'menu.customers',
    iconClass: 'fa fa-address-book-o'
  },
  children: [
    {
      name: 'Customer',
      path: 'customer/:id',
      component: lazyLoading('customers/Customer'),
      meta: {
        showInMenu: false
        // expanded: false,
        // title: 'menu.customers',
        // iconClass: 'fa fa-address-book-o'
      }
    }
  ]
}
