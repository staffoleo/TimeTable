import lazyLoading from './lazyLoading'

export default {
  name: 'Folders',
  path: '/folders',
  component: lazyLoading('folders/Folder'),
  meta: {
    showInMenu: true,
    expanded: false,
    title: 'menu.folders',
    iconClass: 'fa fa-folder-open-o'
  }
}
