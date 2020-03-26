using MM.Domain.Core;
using System;

namespace MM.Domain
{
    public class Usuario : EntityBase
    {
        private string Nome { get; set; }
        private string Apelido { get; set; }
        private string Email { get; set; }
        private DateTime DataNascimento { get; set; }
        private int Cpf { get; set; }
        private int Telefone { get; set; }
        private int Genero { get; set; }
        private DateTime DataCadastro { get; set; }
        private string Senha { get; set; }
        private string Salt { get; set; }
    }
}
