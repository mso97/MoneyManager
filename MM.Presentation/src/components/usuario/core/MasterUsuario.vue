<template>
    <div class="MasterUsuario">
        <v-app>
            <div class="background"></div>
            <div class="container card">
                <div class="row">
                    <v-card class="mx-auto my-auto" outlined min-width="40%">
                        <div class="container">
                            <v-card-actions>
                                <div class="row">
                                    <v-btn disabled large color="primary" class="col-lg-6 col-sm-12">CADASTRE</v-btn>
                                    <v-btn text large color="primary" class="col-lg-6 col-sm-12">ENTRE</v-btn>
                                </div>
                            </v-card-actions>
                            <hr>
                            <v-card-text>
                                <UsuarioInsert/>
                            </v-card-text>
                        </div>
                    </v-card>
                </div>
            </div>

            
        </v-app>
    </div>
</template>

<script>
    import UsuarioInsert from '../insert/UsuarioInsert'

    export default {
        name: 'MasterUsuario',

        components: {
            UsuarioInsert
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
}
</style>