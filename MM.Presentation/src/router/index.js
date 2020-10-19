import Vue from 'vue'
import VueRouter from 'vue-router'

Vue.use(VueRouter)

const routes = [
  {
    path: '/',
    name: 'MasterPage',
    component: () => import( '../components/@core/MasterPage.vue'),
    children: [
      {
        path: 'home',
        name: 'Home',
        component: () => import( '../components/home/Home.vue'),
      },
      {
        path: 'usuario',
        name: 'Usuario',
        component: () => import( '../components/usuario/get/UsuarioGet.vue'),
      }
    ]
  },
  {
    path: '/login',
    name: 'Login',
    component: () => import( '../components/usuario/core/MasterUsuario.vue')
  }
]

const router = new VueRouter({
  mode: 'history',
  base: process.env.BASE_URL,
  routes
})

export default router
