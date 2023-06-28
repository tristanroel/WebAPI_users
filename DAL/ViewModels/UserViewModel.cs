using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.ViewModels
{
    public class UserViewModel
    {
        public int Id { get; set; }

        public string? Alias { get; set; }

        public string? Email { get; set; }

        public string? AvatarUrl { get; set; }

        public string? Country { get; set; }

        public bool IsAdmin { get; set; }

        public int Credits { get; set; }

        public int Score { get; set; }
    }
}
