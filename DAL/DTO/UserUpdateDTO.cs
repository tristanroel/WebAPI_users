using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.DTO
{
    public class UserUpdateDTO
    {
        [StringLength(15, MinimumLength = 2)]
        public string? Alias { get; set; }
        [RegularExpression(@"^[\w-\.]+@([\w-]+\.)+[\w-]{2,4}$")]
        public string? Email { get; set; }
        [DisplayName("PASSWORD")]
        //[RegularExpression(@"^[\w-\.]+@([\w-]+\.)+[\w-]{2,4}$", ErrorMessage = "le mot de passe doit contenir des lettres et des chiffres")]
        [StringLength(30, MinimumLength = 6)]
        public string? Passwd { get; set; }
        public string? AvatarUrl { get; set; }
        public string? Country { get; set; }
        public int Score { get; set; }
        public int Credits { get; set; }
    }
}
