using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WealthParkApi.Models
{
    /// <summary>
    /// Search filter model
    /// </summary>
    public class EmployeeSearchModel
    {
        /// <summary>
        /// First name of the employee to search by
        /// </summary>
        public string FirstName { get; set; }
        /// <summary>
        /// Last name of the employee to search by
        /// </summary>
        public string LastName { get; set; }
    }
}
