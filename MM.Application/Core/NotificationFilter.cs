using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Filters;
using MM.Domain.Notifications;
using Newtonsoft.Json;
using System.Net;
using System.Threading.Tasks;

namespace MM.Application.Core
{
	public class NotificationFilter : ApiBase, IAsyncResultFilter
	{
		private readonly NotificationContext _notificationContext;

		public NotificationFilter(NotificationContext notificationContext)
		{
			_notificationContext = notificationContext;
		}

		public async Task OnResultExecutionAsync(ResultExecutingContext context, ResultExecutionDelegate next)
		{
			if (_notificationContext.HasNotifications)
			{
				context.HttpContext.Response.StatusCode = (int)HttpStatusCode.BadRequest;
				context.HttpContext.Response.ContentType = "application/json";

				var notifications = JsonConvert.SerializeObject(RetornaJson(_notificationContext.Notifications, (int)HttpStatusCode.BadRequest));
				await context.HttpContext.Response.WriteAsync(notifications);

				return;
			}

			await next();
		}
	}
}
