<template>
    <div/>
</template>
<script>
    import axios from 'axios'

    export default {
        name: 'RequestHandling',
        methods: {
            getToken(){
                return localStorage.getItem('NossoDinheiroTK');
            },

            get (endpoint, method) {
                axios.get(endpoint, {
                    headers: {
                        'Authorization': 'Bearer ' + this.getToken()
                    }
                }).then(response => {
                        
                        if (method != null) method(response);
                        else this.responseSubmit(response);
                    })
                    .catch(response => {
                        if (method != null) method(response);
                        else this.responseSubmit(response);
                    });
            },

            post (endpoint, data, method) {
                axios.post(endpoint, data, {
                    headers: {
                        'Authorization': 'Bearer ' + this.getToken()
                    }
                }).then(response => {
                        if (method != null) method(response);
                        else this.responseSubmit(response);
                    })
                    .catch(response => {
                        if (method != null) method(response);
                        else this.responseSubmit(response);
                    });
            },

            responseSubmit(response) {
                if (response != null){
                    if (response.data != null) {
                        this.$toast.success("Sucesso.");
                    }
                    else {
                        if (response.error != null){
                            response.error.forEach(element => {
                                this.$toast.warning(element.errorMessage);
                            });
                        }
                        else {
                            this.$toast.error(response.message);
                        }
                    }
                }
            }
        }
    }
</script>