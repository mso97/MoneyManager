using Google.Cloud.Firestore;
using System.Threading.Tasks;

namespace MM.Infra.Data.Core
{
    public abstract class DatabaseBase<T> where T : class
    {
        protected string collection;
        
        public void SetCollection(string collection)
        {
            this.collection = collection;
        }

        public async Task<string> Inserir(T entidade)
        {
            var document = DatabaseConfig.OpenConnection().Collection(collection).Document();
            var result = document.SetAsync(entidade);
            return document.Id;
        }
    }
}
