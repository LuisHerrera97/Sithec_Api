using Sithec_Prueba.Utils.Interfaces;
using System.Net;

namespace Sithec_Prueba.Utils
{
    public class SithecResponse<T>:ISithecResponse<T>
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
