using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.DTO
{
    public class UserAliasUpdateDTO
    {
        [Required(ErrorMessage = "Alias Requis")]
        [DisplayName("ALIAS")]
        [StringLength(15, MinimumLength = 3)]
        [RegularExpression(@"^[a-zA-Z]+$", ErrorMessage = "Veuillez entrez des lettres de a à Z")]
        public string Alias { get; set; }
    }
}
