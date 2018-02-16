import lazyLoading from './lazyLoading'

export default {
  name: 'Users',
  path: '/users',
  component: lazyLoading('users/User'),
  meta: {
    expanded: false,
    title: 'menu.users',
    iconClass: 'fa fa-address-book-o'
  }
}
