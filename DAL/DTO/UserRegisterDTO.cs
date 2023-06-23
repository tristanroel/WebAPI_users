using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.DTO
{
    public class UserRegisterDTO
    {
        [Required]
        [DisplayName("Enter Your Pseudo: ")]
        [StringLength(15, MinimumLength = 3)]
        public string? Alias { get; set; }
        [Required]
        [RegularExpression(@"^[\w-\.]+@([\w-]+\.)+[\w-]{2,4}$")]
        public string? Email { get; set; }
        [Required]
        public string? Passwd { get; set; }
    }
}
