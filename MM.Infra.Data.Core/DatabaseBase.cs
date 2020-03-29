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

        public async Task<WriteResult> Inserir(T entidade)
        {
            return DatabaseConfig.OpenConnection().Collection(collection).Document().SetAsync(entidade).Result;
        }
    }
}
