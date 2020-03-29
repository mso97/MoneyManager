using Google.Cloud.Firestore;
using MM.Domain.Core;

namespace MM.Domain
{
    [FirestoreData]
    public class Usuario : EntityBase<Usuario>
    {
        [FirestoreProperty]
        public string Nome { get; set; }
        [FirestoreProperty]
        public string Apelido { get; set; }
        [FirestoreProperty]
        public string Email { get; set; }
        [FirestoreProperty]
        public Timestamp DataNascimento { get; set; }
        [FirestoreProperty]
        public int Cpf { get; set; }
        [FirestoreProperty]
        public int Telefone { get; set; }
        [FirestoreProperty]
        public int Genero { get; set; }
        [FirestoreProperty]
        public Timestamp DataCadastro { get; set; }
        [FirestoreProperty]
        public string Senha { get; set; }
        [FirestoreProperty]
        public string Salt { get; set; }
    }
}
