using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Entities
{
    public class User
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
