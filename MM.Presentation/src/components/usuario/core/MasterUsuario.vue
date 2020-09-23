<template>
    <div class="MasterUsuario">
        <v-app>
            <div class="background"></div>
            <div class="container card">
                <div class="row">
                    <v-card class="mx-auto my-auto" min-width="40%">
                        <div class="container">
                            <v-card-actions>
                                <div class="row">
                                    <v-btn :disabled="cadastrar" :text="!cadastrar" large color="primary" @click="clickCadastre" 
                                        class="col-lg-6 col-sm-12">CADASTRE</v-btn>
                                    <v-btn :disabled="!cadastrar" :text="cadastrar" large color="primary" @click="clickEntre" 
                                        class="col-lg-6 col-sm-12">ENTRE</v-btn>
                                </div>
                            </v-card-actions>
                            <hr>
                            <v-card-text>
                                <UsuarioInsert v-if="cadastrar"/>
                                <UsuarioLogin v-else/>
                            </v-card-text>
                        </div>
                    </v-card>
                </div>
            </div>

            
        </v-app>
    </div>
</template>

<script>
    import UsuarioInsert from '../insert/UsuarioInsert';
    import UsuarioLogin from '../login/UsuarioLogin';

    export default {
        name: 'MasterUsuario',

        beforeCreate() {
            let token = localStorage.getItem('NossoDinheiroTK');

			if (token != null){
				this.$router.push('/')
			}
        },

        data: () => ({
            cadastrar: true
        }),

        methods: {
            clickCadastre(){
                this.cadastrar = true;
            },
            clickEntre(){
                this.cadastrar = false;
            }
        },

        components: {
            UsuarioInsert,
            UsuarioLogin
        }
    }
</script>

<style scoped>
.background {
    margin-bottom: 25px;
    position: absolute;
    top: 0;
    left: 0;
    width: 100%;
    /* height: 230px; */
    height: 50%;
    background-color: #2e9e4a;
    background: linear-gradient(90deg,#2e9e4a,#3bb85a);
    z-index: 1;
}
.card {
    z-index: 2;
    margin-top: 5%;
}
</style>