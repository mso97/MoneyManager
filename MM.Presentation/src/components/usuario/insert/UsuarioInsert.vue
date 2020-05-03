<template>
    <div class="UsuarioInsert">
        <form>
            <v-text-field v-model="nome" label="Nome" required></v-text-field>
            <v-text-field v-model="email" label="E-mail" required></v-text-field>
            <v-text-field v-model="senha" label="Senha" required></v-text-field>
            <div class="row d-flex justify-center">
                <v-btn @click="submit" large depressed>CADASTRAR</v-btn>
            </div>
        </form>
    </div>
</template>

<script>
    import axios from 'axios'

    export default {
        name: 'UsuarioInsert',

        data: () => ({
            nome: '',
            email: '',
            senha: ''
        }),

        methods: {
            submit () {
                // var xhr = new XMLHttpRequest();
                // xhr.open('GET', 'http://localhost:52690/v1/usuario', true);
                // xhr.send();

                console.log(this.$data)
                console.log(JSON.stringify(this.$data))

                axios.post('http://localhost:52690/v1/usuario', this.$data);
            }
        }
    };
</script>