import lazyLoading from './lazyLoading'

export default {
  name: 'Files',
  path: '/files',
  component: lazyLoading('files/File'),
  meta: {
    showInMenu: true,
    expanded: false,
    title: 'menu.files',
    iconClass: 'fa fa-file-o'
  }
}
