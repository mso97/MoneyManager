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
            GoogleCredential credential = GoogleCredential.FromFile(@"nosso-dinheiro-67b8b-852252323c5e.json");
            ChannelCredentials channelCredentials = credential.ToChannelCredentials();
            Channel channel = new Channel(FirestoreClient.DefaultEndpoint.ToString(), channelCredentials);
            FirestoreClient firestoreClient = FirestoreClient.Create(channel);
            FirestoreDb db = FirestoreDb.Create("nosso-dinheiro-67b8b", firestoreClient);
            return db;
        }
    }
}
