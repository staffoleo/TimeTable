import lazyLoading from './lazyLoading'

export default {
  name: 'Forms',
  meta: {
    showInMenu: true,
    expanded: false,
    title: 'menu.forms',
    iconClass: 'vuestic-icon vuestic-icon-forms'
  },
  children: [
    {
      name: 'FormElements',
      path: '/forms/form-elements',
      component: lazyLoading('forms/form-elements/FormElements'),
      meta: {
        showInMenu: true,
        title: 'menu.formElements'
      }
    },
    {
      name: 'Form Wizards',
      path: '/forms/form-wizard',
      component: lazyLoading('forms/form-wizard/FormWizard'),
      meta: {
        showInMenu: true,
        title: 'menu.formWizards'
      }
    }
  ]
}

