using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Utils.Interfaces;

namespace Utils
{
    public class SithecResponse<T> : ISithecResponse<T>
    {
        public HttpStatusCode HttpCode { get; set; }
        public bool HasError { get; set; }
        public string Message { get; set; }
        public T Result { get; set; }

        public SithecResponse<T> GetSuccess(T result, string message = "OK") => new() { HttpCode = HttpStatusCode.OK, HasError = false, Message = message, Result = result };
        public SithecResponse<T> GetError(Exception exception) => new() { HttpCode = HttpStatusCode.InternalServerError, HasError = true, Message = exception.Message, Result = default };
        public SithecResponse<T> GetError(string message) => new() { HttpCode = HttpStatusCode.InternalServerError, HasError = true, Message = message, Result = default };
        public SithecResponse<T> GetBadRequest(string message) => new() { HttpCode = HttpStatusCode.BadRequest, HasError = true, Message = message, Result = default };
        public SithecResponse<T> GetConflict(string message) => new() { HttpCode = HttpStatusCode.Conflict, HasError = true, Message = message, Result = default };
        public SithecResponse<T> GetNotFound(string message) => new() { HttpCode = HttpStatusCode.NotFound, HasError = true, Message = message, Result = default };
        public SithecResponse<T> GetUnauthorized(string message) => new() { HttpCode = HttpStatusCode.Unauthorized, HasError = true, Message = message, Result = default };
        public SithecResponse<T> GetResponse<J>(SithecResponse<J> response) => new() { HttpCode = response.HttpCode, HasError = response.HasError, Message = response.Message, Result = default };

        public void SetSuccess(T result, string message = "OK")
        {
            HttpCode = HttpStatusCode.OK;
            HasError = false;
            Message = message;
            Result = result;
        }

        public void SetError(Exception exception)
        {
            HttpCode = HttpStatusCode.InternalServerError;
            HasError = true;
            Message = exception.Message;
            Result = default;
        }

        public void SetError(string message)
        {
            HttpCode = HttpStatusCode.InternalServerError;
            HasError = true;
            Message = message;
            Result = default;
        }
    }
}
