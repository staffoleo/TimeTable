import * as types from '../../mutation-types'

import dashboard from './dashboard'
import auth from './auth'
import folders from './folder'
import files from './file'
import users from './user'
import ui from './ui'
import forms from './forms'
import customers from './customers'
import tables from './tables'

const state = {
  items: [
    dashboard,
    customers,
    folders,
    files,
    tables,
    users,
    auth,
    ui,
    forms
  ]
}

const mutations = {
  [types.TOGGLE_EXPAND_MENU_ITEM] (state, payload) {
    let menuItem = payload.menuItem
    let expand = payload.expand
    if (menuItem.children && menuItem.meta) {
      menuItem.meta.expanded = expand
    }
  }
}

const actions = {
  toggleExpandMenuItem ({commit}, payload) {
    commit(types.TOGGLE_EXPAND_MENU_ITEM, payload)
  }
}

export default {
  state,
  mutations,
  actions
}
