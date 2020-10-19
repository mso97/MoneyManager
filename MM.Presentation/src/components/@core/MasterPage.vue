<template>
    <div>
        <div class="MasterPage">
            <v-app-bar color="#2e9e4a" flat>
                <v-toolbar-title class="titulo">NossoDinheiro</v-toolbar-title>
                <v-spacer></v-spacer>
                <v-app-bar-nav-icon class="bar-content" @click.stop="drawer = !drawer"></v-app-bar-nav-icon>
            </v-app-bar>

            <v-navigation-drawer v-model="drawer" absolute right temporary dense>
                <!-- <v-list-item key="drawer"> -->
                    <v-btn @click.stop="drawer = !drawer" depressed icon><i class="fas fa-times"></i></v-btn>
                <!-- </v-list-item> -->

                <v-list class="lista-draw" dense nav>
                    <v-list-item :key="home" @click="goto('home')" link>
                        <v-list-item-content>
                            <v-list-item-title>Home</v-list-item-title>
                        </v-list-item-content>
                    </v-list-item>
                    <v-list-item :key="usuario" @click="goto('usuario')" link>
                        <v-list-item-content>
                            <v-list-item-title>Usuário</v-list-item-title>
                        </v-list-item-content>
                    </v-list-item>
                    <v-list-item :key="conta" @click="goto('/')" link>
                        <v-list-item-content>
                            <v-list-item-title>Conta</v-list-item-title>
                        </v-list-item-content>
                    </v-list-item>
                </v-list>
            </v-navigation-drawer>
        </div>
        <router-view></router-view>
    </div>
</template>

<script>
    export default {
        name: 'MasterPage',

        data: () => ({
            drawer: null
        }),

        beforeCreate() {
            let token = localStorage.getItem('NossoDinheiroTK');

            if (token == null)
                this.$router.push('login')
            else
                this.$router.push('home')
        },

        methods: {
            goto(pagina){
                this.drawer = !this.drawer;
                this.$router.push(pagina);
            }
        },
    }
</script>

<style scoped>
    .MasterPage{
        margin-bottom: 2%;
    }

    .titulo {
        font-family: 'Segoe UI', Tahoma, Geneva, Verdana, sans-serif;
        padding-left: 1rem;
        color: white;
    }

    .lista-draw {
        font-family: 'Segoe UI', Tahoma, Geneva, Verdana, sans-serif;
    }

    .icon-space {
        margin-right: 1rem;
    }
</style>