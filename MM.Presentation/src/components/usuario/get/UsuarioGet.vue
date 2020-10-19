<template>
    <div class="UsuarioGet container">
        <div class="row">
            Usuário
        </div>
        
        <form>
            <div class="row">
                <v-text-field v-model="nome" label="Nome"
                    @input="$v.nome.$touch()" @blur="$v.nome.$touch()"
                    :error-messages="errorsNome"
                    required class="col-sm-12 col-md-6">
                </v-text-field>
                <v-text-field v-model="apelido" label="Apelido" class="col-sm-12 col-md-6">
                </v-text-field>
            </div>
            <div class="row">
                <v-text-field v-model="email" label="E-mail"
                    @input="$v.email.$touch()" @blur="$v.email.$touch()"
                    :error-messages="errorsEmail"
                    required class="col-sm-12 col-md-6">
                </v-text-field>
                <v-text-field v-model="dtNascimento" label="Data de Nascimento" class="col-sm-12 col-md-6" type="date">
                </v-text-field>
            </div>
            <div class="row">
                <v-text-field v-model="cpf" label="CPF" class="col-sm-12 col-md-6">
                </v-text-field>
                <v-text-field v-model="telefone" label="Telefone" class="col-sm-12 col-md-6" type="phone">
                </v-text-field>
            </div>
            <div class="row">
                <v-text-field v-model="genero" label="Genero" class="col-sm-12 col-md-6">
                </v-text-field>
            </div>

            <div class="row d-flex justify-center">
                <v-btn @click="submit" large depressed>CADASTRAR</v-btn>
            </div>
        </form>
    </div>
</template>

<script>
    import axios from 'axios'
    import { validationMixin } from 'vuelidate'
    import { required, maxLength, email, minLength } from 'vuelidate/lib/validators'

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
                if(this.$v.$error) return

                axios.post('usuario', this.$data)
                    .then(response => {
                        this.responseSubmit(response);
                    })
                    .catch(response => {
                        this.responseSubmit(response);
                    });
            },

            responseSubmit(response) {
                if (response != null){
                    if (response.data != null) {
                        this.$toast.success("Cadastro realizado");
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
    };
</script>

<style>
    .UsuarioGet{
        font-family: 'Segoe UI', Tahoma, Geneva, Verdana, sans-serif;
    }
</style>