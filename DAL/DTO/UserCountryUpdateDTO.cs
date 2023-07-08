using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.DTO
{
    public class UserCountryUpdateDTO
    {
        [MaxLength(50)]
        public string? Country { get; set; }
        public string? FlagUrl { get; set; }
    }
}
