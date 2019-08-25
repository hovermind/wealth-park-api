using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WealthParkApi.Domain.Entities
{
    /// <summary>
    /// Employee entity
    /// </summary>
    [Table("Employee")]
    public class Employee
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [ConcurrencyCheck]
        public long Id { get; set; }

        [Required]
        [MaxLength(15), MinLength(3)]
        public string FirstName { get; set; }

        [Required]
        [MaxLength(15), MinLength(3)]
        public string LastName { get; set; }

        [Required]
        public string Boss { get; set; }

        [DataType(DataType.Date)]
        [Required]
        public DateTime? DateOfBirth { get; set; }

        public string Address { get; set; }

        public double Salary { get; set; }
    }
}
