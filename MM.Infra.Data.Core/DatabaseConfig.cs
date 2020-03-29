using Google.Cloud.Firestore;
using Google.Apis.Auth.OAuth2;
using Grpc.Core;
using Grpc.Auth;
using Google.Cloud.Firestore.V1;

namespace MM.Infra.Data.Core
{
    public class DatabaseConfig
    {
        public static FirestoreDb OpenConnection()
        {
            GoogleCredential credential = GoogleCredential.FromFile(@"nosso-dinheiro-44623-a014cfec215e.json");
            ChannelCredentials channelCredentials = credential.ToChannelCredentials();
            Channel channel = new Channel(FirestoreClient.DefaultEndpoint.ToString(), channelCredentials);
            FirestoreClient firestoreClient = FirestoreClient.Create(channel);
            FirestoreDb db = FirestoreDb.Create("nosso-dinheiro-44623", firestoreClient);
            return db;
        }
    }
}
