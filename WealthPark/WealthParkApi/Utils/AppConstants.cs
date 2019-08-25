using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WealthParkApi.Utils
{
    /// <summary>
    /// Apllication constants
    /// </summary>
    public static class AppConstants
    {
        /// <summary>
        /// Page size (pagination) - number of items per page
        /// </summary>
        public const int PageSize = 25;
        /// <summary>
        /// Global route prefix
        /// </summary>
        public const string ApiRoot = @"wealth-park/api";
        /// <summary>
        /// Title for Open API (Swagger) doc
        /// </summary>
        public const string ApiTitle = "Wealth Park API";
        /// <summary>
        /// Description for Open API (Swagger) doc
        /// </summary>
        public const string ApiDescription = @"Wealth Park Employee Management API. Developed by <a href='https://github.com/hovermind'>HASSAN MD TAREQ</a> using ASP.Net Core & Entity Framework Core";
        /// <summary>
        /// Version for Open API (Swagger) doc
        /// </summary>
        public const string ApiVersion = "v1";
        /// <summary>
        /// Developer name
        /// </summary>
        public const string DevName = "HASSAN MD TAREQ";
        /// <summary>
        /// Developer email
        /// </summary>
        public const string DevEmail = "console041@gmail.com";
        /// <summary>
        /// Developer website
        /// </summary>
        public const string DevWebsite = "hovermind.com";
    }
}
