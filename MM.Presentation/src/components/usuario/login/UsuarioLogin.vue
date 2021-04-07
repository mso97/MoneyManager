<template>
  <div class="UsuarioLogin">
        <form>
            <v-text-field v-model="email" label="E-mail" 
                @input="$v.email.$touch()" @blur="$v.email.$touch()"
                :error-messages="errorsEmail"
                required>
            </v-text-field>
            <v-text-field v-model="senha" label="Senha"
                @input="$v.senha.$touch()" @blur="$v.senha.$touch()"
                :error-messages="errorsSenha" 
                required
                type="password">
            </v-text-field>
            <div class="row d-flex justify-center">
                <v-btn @click="submit" large depressed>ENTRAR</v-btn>
            </div>
        </form>
        <RequestHandling ref="requestHandling"/>
    </div>
</template>

<script>
    import { validationMixin } from 'vuelidate'
    import { required, email } from 'vuelidate/lib/validators'
    import RequestHandling from '../../@core/helpers/RequestHandling'

    export default {
        name: 'UsuarioLogin',

        mixins: [validationMixin],

        validations: {
            email: {required, email},
            senha: {required }
        },

        computed: {
            errorsEmail () {
                const errors = [];
                if (!this.$v.email.$dirty) return errors;
                !this.$v.email.required && errors.push('O e-mail é obrigatório.');
                !this.$v.email.email && errors.push('É necessário um e-mail válido.');
                return errors;
            },
            errorsSenha () {
                const errors = [];
                if (!this.$v.senha.$dirty) return errors;
                !this.$v.senha.required && errors.push('A senha é obrigatória.');
                return errors
            }
        },

        data: () => ({
            email: '',
            senha: ''
        }),

        methods: {
            submit () {
                this.$v.$touch()
                if(this.$v.$error) return

                this.$refs.requestHandling.post('login', this.$data, this.responseSubmit);
            },

            responseSubmit(response) {
                if (response != null){
                    if (response.data != null) {
                        localStorage.setItem('NossoDinheiroTK', response.data.token);
                        this.$toast.success("Login realizado.");
                        this.$router.push('/');
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
        },

        components: {
            RequestHandling
        }
    };
</script>
