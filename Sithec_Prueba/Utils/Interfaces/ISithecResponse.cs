using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Utils.Interfaces
{
    public interface ISithecResponse<T>
    {
        bool HasError { get; set; }
        HttpStatusCode HttpCode { get; set; }
        string Message { get; set; }
        T Result { get; set; }

        SithecResponse<T> GetBadRequest(string message);
        SithecResponse<T> GetConflict(string message);
        SithecResponse<T> GetError(Exception exception);
        SithecResponse<T> GetError(string message);
        SithecResponse<T> GetNotFound(string message);
        SithecResponse<T> GetResponse<J>(SithecResponse<J> response);
        SithecResponse<T> GetSuccess(T result, string message = "OK");
        SithecResponse<T> GetUnauthorized(string message);
        void SetError(Exception exception);
        void SetError(string message);
        void SetSuccess(T result, string message = "OK");
    }
}
