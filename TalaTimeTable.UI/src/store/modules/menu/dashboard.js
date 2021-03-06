import lazyLoading from './lazyLoading'

export default {
  name: 'Dashboard',
  path: '/dashboard',
  component: lazyLoading('dashboard/Dashboard'),
  meta: {
    showInMenu: true,
    default: true,
    title: 'menu.dashboard',
    iconClass: 'vuestic-icon vuestic-icon-dashboard'
  }
}
