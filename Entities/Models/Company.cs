using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Models
{
    public class Company
    {
        [Column("CompanyId")]
        public Guid Id { get; set; }

        [Required(ErrorMessage = "Compnay name is required field.")]
        [MaxLength(60, ErrorMessage = "Maximum length of Name is 60 characters.")]
        public string? Name { get; set; }

        [Required(ErrorMessage = "Compnay address is required field.")]
        [MaxLength(60, ErrorMessage = "Maximum length of Address is 60 characters.")]
        public string? Address { get; set; }

        public string? Country { get; set; }
        public ICollection<Employee>? Employees { get; set; }
    }
}
