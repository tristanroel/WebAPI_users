using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.DTO
{
    public class UserUpdateDTO
    {
        [Required]
        public string? Alias { get; set; }
        [Required]
        [RegularExpression(@"^[\w-\.]+@([\w-]+\.)+[\w-]{2,4}$")]
        public string? Email { get; set; }
        [Required]
        public string? Passwd { get; set; }
        [Required]
        public string? AvatarUrl { get; set; }
        [Required]
        public string? Country { get; set; }
    }
}
