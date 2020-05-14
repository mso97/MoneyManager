import Vue from 'vue';
import App from './App.vue';
import vuetify from './plugins/vuetify';
import axios from 'axios'
import VueAxios from 'vue-axios'

Vue.use(VueAxios, axios);

Vue.config.productionTip = true;

axios.interceptors.request.use(config => {
    config.baseURL = "http://localhost:52690/v1/";
    return config;
});

// const axiosResponse = (t) => {
//     return t.data;
// }

// const axiosError = (t) => {
//     return t.response.data;
// }

axios.interceptors.response.use(
    configResponse => configResponse.data,
    configError => configError.response.data
);

new Vue({
    vuetify,
    render: h => h(App)
}).$mount('#app');
