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
        [Required(ErrorMessage = "Alias Requis")]
        [DisplayName("ALIAS")]
        //[StringLength(MaximumLength:15, MinimumLength = 3)]
        //[RegularExpression(@"^[A-z]", ErrorMessage = "Veuillez entrez des lettres de a à Z")]
        public string? Alias { get; set; }

        [Required(ErrorMessage = "Email Requis")]
        [DisplayName("EMAIL")]
        [RegularExpression(@"^[\w-\.]+@([\w-]+\.)+[\w-]{2,4}$", ErrorMessage = "Email Invalide")]
        public string? Email { get; set; }

        [Required]
        [DisplayName("PASSWORD")]
        
        [StringLength(30,MinimumLength = 6)]
        public string? Passwd { get; set; }
    }
}
