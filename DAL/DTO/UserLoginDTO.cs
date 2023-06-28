using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.DTO
{
    public class UserLoginDTO
    {
        [Required(ErrorMessage = "email requis")]
        [DisplayName("EMAIL")]
        [RegularExpression(@"^[\w-\.]+@([\w-]+\.)+[\w-]{2,4}$", ErrorMessage = "Email Invalide")]
        public string? Email { get; set; }

        [Required(ErrorMessage = "mot de passe requis")]
        [DisplayName("PASSWORD")]
        [RegularExpression(@"^[a-zA-Z0-9=]{8,}$", ErrorMessage = "le mot de passe doit contenir des chiffres et des lettres et contenir au moins 8 charactères ")]//accepte aussi le '='
        [StringLength(30, MinimumLength = 6)]
        public string? Passwd { get; set; }
    }
}
