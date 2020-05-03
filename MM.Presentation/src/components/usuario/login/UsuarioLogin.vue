<template>
  <div class="UsuarioLogin">
        <form>
            <v-text-field v-model="email" label="E-mail" required></v-text-field>
            <v-text-field v-model="senha" label="Senha" required></v-text-field>
            <div class="row d-flex justify-center">
                <v-btn @click="submit" large depressed>ENTRAR</v-btn>
            </div>
        </form>
    </div>
</template>

<script>
    export default {
        name: 'UsuarioLogin',

        data: () => ({
            email: '',
            senha: ''
        }),

        methods: {
            submit () {
                alert("oi")
            }
        }
    };
</script>
