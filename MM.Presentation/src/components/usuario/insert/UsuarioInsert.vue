<template>
    <div class="UsuarioInsert">
        <form>
            <v-text-field v-model="nome" label="Nome"
                @input="$v.nome.$touch()" @blur="$v.nome.$touch()"
                :error-messages="errorsNome"
                required>
            </v-text-field>
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
                <v-btn @click="submit" large depressed>CADASTRAR</v-btn>
            </div>
        </form>
        <RequestHandling ref="requestHandling"/>
    </div>
</template>

<script>
    import { validationMixin } from 'vuelidate'
    import { required, maxLength, email, minLength } from 'vuelidate/lib/validators'
    import RequestHandling from '../../@core/helpers/RequestHandling'

    export default {
        name: 'UsuarioInsert',

        mixins: [validationMixin],

        validations: {
            nome: {required, maxLength: maxLength(50)},
            email: {required, maxLength: maxLength(100), email},
            senha: {required, maxLength: maxLength(50), minLength: minLength(6) }
        },

        computed: {
            errorsNome () {
                const errors = [];
                if (!this.$v.nome.$dirty) return errors;
                !this.$v.nome.required && errors.push('O nome é obrigatório.');
                !this.$v.nome.maxLength && errors.push('O tamanho máximo é 50 caracteres.');
                return errors;
            },
            errorsEmail () {
                const errors = [];
                if (!this.$v.email.$dirty) return errors;
                !this.$v.email.required && errors.push('O e-mail é obrigatório.');
                !this.$v.email.maxLength && errors.push('O tamanho máximo é 100 caracteres.');
                !this.$v.email.email && errors.push('É necessário um e-mail válido.');
                return errors;
            },
            errorsSenha () {
                const errors = [];
                if (!this.$v.senha.$dirty) return errors;
                !this.$v.senha.required && errors.push('A senha é obrigatória.');
                !this.$v.senha.maxLength && errors.push('O tamanho máximo é 50 caracteres.');
                !this.$v.senha.minLength && errors.push('O tamanho minimo é 6 caracteres.');
                return errors
            }
        },

        data: () => ({
            nome: '',
            email: '',
            senha: ''
        }),

        methods: {
            submit () {
                this.$v.$touch()
                if(this.$v.$error) return;

                this.$refs.requestHandling.post('usuario', this.$data, null);
            }
        },

        components: {
            RequestHandling
        }
    };
</script>