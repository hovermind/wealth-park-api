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
        /// Version for Open API (Swagger) doc
        /// </summary>
        public const string ApiVersion = "v1";
    }
}
