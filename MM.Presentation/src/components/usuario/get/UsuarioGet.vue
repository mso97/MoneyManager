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
                <v-text-field v-model="dataNascimento" label="Data de Nascimento" class="col-sm-12 col-md-6" type="date">
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
        <RequestHandling ref="requestHandling"/>
    </div>
</template>

<script>
    import { validationMixin } from 'vuelidate'
    import { required, maxLength, email, minLength } from 'vuelidate/lib/validators'
    import RequestHandling from '../../@core/helpers/RequestHandling'

    export default {
        name: 'UsuarioGet',

        mixins: [validationMixin],

        validations: {
            nome: {required, maxLength: maxLength(50)},
            email: {required, maxLength: maxLength(100), email},
            senha: {required, maxLength: maxLength(50), minLength: minLength(6) }
        },

        mounted() {
            this.$refs.requestHandling.get('usuario', this.responseSubmit);
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
            apelido: '',
            email: '',
            dataNascimento: '',
            cpf: '',
            telefone: '',
            genero: '',
        }),

        methods: {
            submit () {
                this.$v.$touch()
                if(this.$v.$error) return

                this.$refs.requestHandling.post('usuario', this.$data, this.responseSubmit);
            },

            responseSubmit(response) {
                if (response != null){
                    if (response.data != null) {
                        this.$data.nome = response.data.nome;
                        this.$data.apelido = response.data.apelido;
                        this.$data.email = response.data.email;
                        this.$data.dataNascimento = this.formatDate(response.data.dataNascimento);
                        this.$data.cpf = response.data.cpf;
                        this.$data.telefone = response.data.telefone;
                        this.$data.genero = response.data.genero;
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
            },

            formatDate(date){
                var data = new Date(date);
                return (data.getFullYear() + "-" + ("0" + (data.getMonth() + 1)).slice(-2) + "-" + (data.getDate()));
            }
        },

        components: {
            RequestHandling
        }
    };
</script>

<style>
    .UsuarioGet{
        font-family: 'Segoe UI', Tahoma, Geneva, Verdana, sans-serif;
    }
</style>