using Microsoft.AspNetCore.Http;
using System;

namespace WealthParkApi.Exceptions
{
    /// <summary>
    /// App realted exception
    /// </summary>
    [Serializable]
    public class ApiException : Exception
    {
        /// <summary>
        /// Http status code
        /// </summary>
        public int StatusCode { get; set; } = StatusCodes.Status500InternalServerError;

        /// <summary>
        /// Exception ctor with status code and message
        /// </summary>
        /// <param name="statusCode"></param>
        /// <param name="message"></param>
        public ApiException(int statusCode, string message) : base(message)
        {
            StatusCode = statusCode;
        }
        /// <summary>
        /// Exception ctor with message only
        /// </summary>
        /// <param name="message"></param>
        /// <param name="exception"></param>
        public ApiException(string message, Exception exception) : base(message, exception)
        {
        }
    }
}
