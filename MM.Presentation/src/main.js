import Vue from 'vue';
import App from './App.vue';
import vuetify from './plugins/vuetify';
import axios from 'axios'
import VueAxios from 'vue-axios'
import Toast, { POSITION } from "vue-toastification";
import "vue-toastification/dist/index.css";

Vue.use(VueAxios, axios);
Vue.use(Toast, {position: POSITION.TOP_RIGHT});

Vue.config.productionTip = true;

axios.interceptors.request.use(config => {
    config.baseURL = "http://localhost:52690/v1/";
    return config;
});

axios.interceptors.response.use(
    configResponse => configResponse.data,
    configError => {
        if (configError.response == undefined){
            console.log(configError);
            return configError;
        }
        console.log(configError.response.data)
        return configError.response.data;
    }
);

new Vue({
    vuetify,
    render: h => h(App)
}).$mount('#app');
