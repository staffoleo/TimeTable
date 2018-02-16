import lazyLoading from './lazyLoading'

export default {
  name: 'ui',
  meta: {
    showInMenu: true,
    expanded: false,
    title: 'menu.uiElements',
    iconClass: 'vuestic-icon vuestic-icon-ui-elements'
  },
  children: [
    {
      name: 'Typography',
      path: '/ui/typography',
      component: lazyLoading('ui/typography/Typography'),
      meta: {
        showInMenu: true,
        title: 'menu.typography'
      }
    },
    {
      name: 'Buttons',
      path: '/ui/buttons',
      component: lazyLoading('ui/buttons/Buttons'),
      meta: {
        showInMenu: true,
        title: 'menu.buttons'
      }
    },
    {
      path: '/ui/icons',
      component: lazyLoading('ui/icons/Icons'),
      meta: {
        showInMenu: true,
        title: 'menu.icons'
      },
      children: [
        {
          path: '', // Default route
          component: lazyLoading('ui/icons/SetsList'),
          meta: {
            showInMenu: true,
            title: 'menu.icons'
          }
        },
        {
          path: ':name',
          component: lazyLoading('ui/icons/Set'),
          props: true,
          meta: {
            showInMenu: true,
            title: 'Set'
          }
        }
      ]
    },
    {
      name: 'Spinners',
      path: '/ui/spinners',
      component: lazyLoading('ui/spinners/Spinners'),
      meta: {
        showInMenu: true,
        title: 'menu.spinners'
      }
    },
    {
      name: 'Grid',
      path: '/ui/grid',
      component: lazyLoading('ui/grid/Grid'),
      meta: {
        showInMenu: true,
        title: 'menu.grid'
      }
    },
    {
      name: 'Modals',
      path: '/ui/modals',
      component: lazyLoading('ui/modals/Modals'),
      meta: {
        showInMenu: true,
        title: 'menu.modals'
      }
    }
  ]
}

