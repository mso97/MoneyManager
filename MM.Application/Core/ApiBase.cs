﻿using Microsoft.AspNetCore.Mvc;
using MM.Domain.Notifications;
using System.Net;

namespace MM.Application.Core
{
    public abstract class ApiBase : ControllerBase
    {
        public NotificationContext _notificationContext;

        public JsonReturn RetornaJson(object retorno, int status = (int)HttpStatusCode.OK)
        {
            JsonReturn json = new JsonReturn();

            if (_notificationContext.HasNotifications)
            {
                json.Error = _notificationContext.Notifications;
                json.StatusCode = (int)HttpStatusCode.InternalServerError;
                json.Success = false;
            }
            else
            {
                if (status == (int)HttpStatusCode.OK)
                {
                    json.Data = retorno;
                    json.StatusCode = (int)HttpStatusCode.OK;
                    json.Success = true;
                }
                else
                {
                    json.Error = retorno;
                    json.StatusCode = status;
                    json.Success = false;
                }
            }

            return json;
        }
    }
}
