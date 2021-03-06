﻿using MM.Domain.Core;
using System;
using static MM.Domain.Enum;

namespace MM.Domain
{
    public class Usuario : EntityBase
    {
        public string Nome { get; set; }
        public string Apelido { get; set; }
        public string Email { get; set; }
        public DateTime DataNascimento { get; set; }
        public string Cpf { get; set; }
        public int Telefone { get; set; }
        public EnumGenero Genero { get; set; }
        public DateTime DataCadastro { get; set; }
        public string Senha { get; set; }
        public string Salt { get; set; }
        public string Role { get; set; }
        public string Token { get; set; }

        public void SetSalt(string Salt)
        {
            this.Salt = Salt;
        }

        public void SetSenha(string Senha)
        {
            this.Senha = Senha;
        }

        public void SetDataCadastro()
        {
            this.DataCadastro = DateTime.Now;
        }

        public void SetRole(string Role)
        {
            this.Role = Role;
        }

        public void LimpaConsulta()
        {
            this.Senha = null;
            this.Salt = null;
        }
    }
}
