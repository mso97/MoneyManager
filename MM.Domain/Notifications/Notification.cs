namespace MM.Domain.Notifications
{
    public class Notification
    {
		public string Key { get; }
		public string ErrorMessage { get; }

		public Notification(string key, string message)
		{
			Key = key;
			ErrorMessage = message;
		}
	}
}
